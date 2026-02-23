using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Stytch.net.Clients;
using Stytch.net.Models;

namespace Stytch.net
{
    public static class Utility
    {
        public const string SessionClaimKey = "https://stytch.com/session";
        public const string OrganizationClaimKey = "https://stytch.com/organization";

        public static string BuildQueryString(Dictionary<string, string> parameters)
        {
            var queryString = new List<string>();

            foreach (var param in parameters)
            {
                if (string.IsNullOrEmpty(param.Value))
                {
                    continue;
                }

                string encodedKey = Uri.EscapeDataString(param.Key);
                string encodedValue = Uri.EscapeDataString(param.Value);

                queryString.Add($"{encodedKey}={encodedValue}");
            }

            return string.Join("&", queryString);
        }

        private static JsonWebKeySet _cachedJwks;
        private static string _cachedJwksUrl;
        private static DateTime _jwksLastFetched;
        private static TimeSpan _jwksRefreshInterval = TimeSpan.FromMinutes(15);

        private static string[] _jwtClaimKeysToRemove =
        {
            "aud", "exp", "iat", "iss", "jti", "nbf", "sub",
            ClaimTypes.NameIdentifier,
        };

        public class AuthenticateJwtResult
        {
            public string Subject { get; set; }
            public Dictionary<string, object> CustomClaims { get; set; }
        }

        public class AuthenticateJwtParams
        {
            public string Jwt { get; set; }
            public TimeSpan ClockSkew { get; set; } = TimeSpan.FromMinutes(1);
            public LifetimeValidator LifetimeValidator { get; set; }
        }

        public static async Task<AuthenticateJwtResult> AuthenticateJwtLocal(HttpClient client, ClientConfig config,
            AuthenticateJwtParams requestParams)
        {
            var jwks = await GetJwksFromUrl(client, config.JwksUri);

            // Build list of allowed issuers: default issuer and custom base URL (if provided)
            var allowedIssuers = new List<string> { $"stytch.com/{config.ProjectId}" };
            if (!string.IsNullOrEmpty(config.CustomBaseUrl))
            {
                // Remove trailing slash - our issuers will never have a trailing slash
                allowedIssuers.Add(config.CustomBaseUrl.TrimEnd('/'));
            }

            var validationParameters = new TokenValidationParameters
            {
                IssuerSigningKeys = jwks.Keys,
                ValidateIssuer = true,
                ValidIssuers = allowedIssuers,
                ValidateAudience = true,
                ValidAudience = config.ProjectId,
                ValidateLifetime = true,
                ValidAlgorithms = new[] { "RS256" },
                ClockSkew = requestParams.ClockSkew,
                LifetimeValidator = requestParams.LifetimeValidator
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var result = await tokenHandler.ValidateTokenAsync(requestParams.Jwt, validationParameters);
            if (!result.IsValid)
            {
                throw result.Exception;
            }

            var customClaims = new Dictionary<string, object>(result.Claims);

            foreach (var claim in _jwtClaimKeysToRemove)
            {
                customClaims.Remove(claim);
            }

            string subject = null;
            if (result.Claims.TryGetValue(ClaimTypes.NameIdentifier, out object subjectClaim))
            {
                subject = subjectClaim.ToString();
            }
            else if (result.Claims.TryGetValue("name", out object subClaim))
            {
                subject = subClaim.ToString();
            }

            return new AuthenticateJwtResult()
            {
                Subject = subject,
                CustomClaims = customClaims
            };
        }

        private static async Task<JsonWebKeySet> GetJwksFromUrl(HttpClient client, string jwksUrl)
        {
            if (_cachedJwks == null || _cachedJwksUrl != jwksUrl || DateTime.UtcNow - _jwksLastFetched > _jwksRefreshInterval)
            {
                string jwksJson = await client.GetStringAsync(jwksUrl);
                _cachedJwks = new JsonWebKeySet(jwksJson);
                _cachedJwksUrl = jwksUrl;
                _jwksLastFetched = DateTime.UtcNow;
            }

            return _cachedJwks;
        }

        private static B2BRbacPolicy _cachedB2BRbacPolicy;
        private static TimeSpan _b2bRbacRefreshInterval = TimeSpan.FromMinutes(5);
        private static Timer _b2bRbacRefreshTimer;
        private static IB2BPolicyGetter _b2bPolicyGetter;
        private static readonly SemaphoreSlim _b2bRbacSemaphore = new SemaphoreSlim(1, 1);
        private static volatile bool _b2bRbacRefreshInProgress;

        public interface IB2BPolicyGetter
        {
            Task<B2BRBACPolicyResponse> Policy(B2BRBACPolicyRequest request);
        }

        public static async Task<bool> AuthorizeRbacRoles(IB2BPolicyGetter policyGetter,
            AuthorizationParams authorizationParams)
        {
            var policy = await GetB2BRbacPolicy(policyGetter);
            return policy.IsAuthorized(authorizationParams);
        }

        private static async Task<B2BRbacPolicy> GetB2BRbacPolicy(IB2BPolicyGetter policyGetter)
        {
            if (_cachedB2BRbacPolicy == null)
            {
                await _b2bRbacSemaphore.WaitAsync();
                try
                {
                    if (_cachedB2BRbacPolicy == null)
                    {
                        var policyRes = await policyGetter.Policy(new B2BRBACPolicyRequest());
                        _cachedB2BRbacPolicy = new B2BRbacPolicy(policyRes.Policy);
                        _b2bPolicyGetter = policyGetter;
                        StartB2BRbacBackgroundRefresh();
                    }
                }
                finally
                {
                    _b2bRbacSemaphore.Release();
                }
            }

            return _cachedB2BRbacPolicy;
        }

        private static void StartB2BRbacBackgroundRefresh()
        {
            if (_b2bRbacRefreshTimer == null)
            {
                _b2bRbacRefreshTimer = new Timer(RefreshB2BRbacPolicyBackgroundSync,
                    null, _b2bRbacRefreshInterval, _b2bRbacRefreshInterval);
            }
        }

        private static void RefreshB2BRbacPolicyBackgroundSync(object state)
        {
            _ = Task.Run(async () =>
            {
                try
                {
                    await RefreshB2BRbacPolicyBackground();
                }
                catch
                {
                    // Silently handle exceptions in background refresh
                }
            });
        }

        private static async Task RefreshB2BRbacPolicyBackground()
        {
            if (_b2bPolicyGetter == null || _b2bRbacRefreshInProgress) return;

            _b2bRbacRefreshInProgress = true;
            try
            {
                var policyRes = await _b2bPolicyGetter.Policy(new B2BRBACPolicyRequest());

                await _b2bRbacSemaphore.WaitAsync();
                try
                {
                    _cachedB2BRbacPolicy = new B2BRbacPolicy(policyRes.Policy);
                }
                finally
                {
                    _b2bRbacSemaphore.Release();
                }
            }
            catch
            {
                // Silently handle exceptions in background refresh
            }
            finally
            {
                _b2bRbacRefreshInProgress = false;
            }
        }

        private static RbacPolicy _cachedRbacPolicy;
        private static TimeSpan _rbacRefreshInterval = TimeSpan.FromMinutes(5);
        private static Timer _rbacRefreshTimer;
        private static IPolicyGetter _policyGetter;
        private static readonly SemaphoreSlim _rbacSemaphore = new SemaphoreSlim(1, 1);
        private static volatile bool _rbacRefreshInProgress;

        public interface IPolicyGetter
        {
            Task<RBACPolicyResponse> Policy(RBACPolicyRequest request);
        }

        public static async Task<bool> AuthorizeRbacRoles(IPolicyGetter policyGetter,
            AuthorizationParams authorizationParams)
        {
            var policy = await GetRbacPolicy(policyGetter);
            return policy.IsAuthorized(authorizationParams);
        }

        private static async Task<RbacPolicy> GetRbacPolicy(IPolicyGetter policyGetter)
        {
            if (_cachedRbacPolicy == null)
            {
                await _rbacSemaphore.WaitAsync();
                try
                {
                    if (_cachedRbacPolicy == null)
                    {
                        var policyRes = await policyGetter.Policy(new RBACPolicyRequest());
                        _cachedRbacPolicy = new RbacPolicy(policyRes.Policy);
                        _policyGetter = policyGetter;
                        StartRbacBackgroundRefresh();
                    }
                }
                finally
                {
                    _rbacSemaphore.Release();
                }
            }

            return _cachedRbacPolicy;
        }

        private static void StartRbacBackgroundRefresh()
        {
            if (_rbacRefreshTimer == null)
            {
                _rbacRefreshTimer = new Timer(RefreshRbacPolicyBackgroundSync,
                    null, _rbacRefreshInterval, _rbacRefreshInterval);
            }
        }

        private static void RefreshRbacPolicyBackgroundSync(object state)
        {
            _ = Task.Run(async () =>
            {
                try
                {
                    await RefreshRbacPolicyBackground();
                }
                catch
                {
                    // Silently handle exceptions in background refresh
                }
            });
        }

        private static async Task RefreshRbacPolicyBackground()
        {
            if (_policyGetter == null || _rbacRefreshInProgress) return;

            _rbacRefreshInProgress = true;
            try
            {
                var policyRes = await _policyGetter.Policy(new RBACPolicyRequest());

                await _rbacSemaphore.WaitAsync();
                try
                {
                    _cachedRbacPolicy = new RbacPolicy(policyRes.Policy);
                }
                finally
                {
                    _rbacSemaphore.Release();
                }
            }
            catch
            {
                // Silently handle exceptions in background refresh
            }
            finally
            {
                _rbacRefreshInProgress = false;
            }
        }
    }
}
