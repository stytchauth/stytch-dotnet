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
            var validationParameters = new TokenValidationParameters
            {
                IssuerSigningKeys = jwks.Keys,
                ValidateIssuer = true,
                ValidIssuer = $"stytch.com/{config.ProjectId}",
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
        private static DateTime _b2bRbacPolicyLastFetched;
        private static TimeSpan _b2bRbacRefreshInterval = TimeSpan.FromMinutes(5);
        private static Timer _b2bRbacRefreshTimer;
        private static IB2BPolicyGetter _b2bPolicyGetter;
        private static readonly object _b2bRbacLock = new object();

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

        private static Task<B2BRbacPolicy> GetB2BRbacPolicy(IB2BPolicyGetter policyGetter)
        {
            if (_cachedB2BRbacPolicy == null)
            {
                lock (_b2bRbacLock)
                {
                    if (_cachedB2BRbacPolicy == null)
                    {
                        var policyRes = policyGetter.Policy(new B2BRBACPolicyRequest()).Result;
                        _cachedB2BRbacPolicy = new B2BRbacPolicy(policyRes.Policy);
                        _b2bRbacPolicyLastFetched = DateTime.UtcNow;
                        _b2bPolicyGetter = policyGetter;
                        StartB2BRbacBackgroundRefresh();
                    }
                }
            }

            return Task.FromResult(_cachedB2BRbacPolicy);
        }

        private static void StartB2BRbacBackgroundRefresh()
        {
            if (_b2bRbacRefreshTimer == null)
            {
                _b2bRbacRefreshTimer = new Timer(async _ => await RefreshB2BRbacPolicyBackground(),
                    null, _b2bRbacRefreshInterval, _b2bRbacRefreshInterval);
            }
        }

        private static async Task RefreshB2BRbacPolicyBackground()
        {
            if (_b2bPolicyGetter == null) return;

            try
            {
                var policyRes = await _b2bPolicyGetter.Policy(new B2BRBACPolicyRequest());
                lock (_b2bRbacLock)
                {
                    _cachedB2BRbacPolicy = new B2BRbacPolicy(policyRes.Policy);
                    _b2bRbacPolicyLastFetched = DateTime.UtcNow;
                }
            }
            catch
            {
            }
        }

        private static RbacPolicy _cachedRbacPolicy;
        private static DateTime _rbacPolicyLastFetched;
        private static TimeSpan _rbacRefreshInterval = TimeSpan.FromMinutes(5);
        private static Timer _rbacRefreshTimer;
        private static IPolicyGetter _policyGetter;
        private static readonly object _rbacLock = new object();

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

        private static Task<RbacPolicy> GetRbacPolicy(IPolicyGetter policyGetter)
        {
            if (_cachedRbacPolicy == null)
            {
                lock (_rbacLock)
                {
                    if (_cachedRbacPolicy == null)
                    {
                        var policyRes = policyGetter.Policy(new RBACPolicyRequest()).Result;
                        _cachedRbacPolicy = new RbacPolicy(policyRes.Policy);
                        _rbacPolicyLastFetched = DateTime.UtcNow;
                        _policyGetter = policyGetter;
                        StartRbacBackgroundRefresh();
                    }
                }
            }

            return Task.FromResult(_cachedRbacPolicy);
        }

        private static void StartRbacBackgroundRefresh()
        {
            if (_rbacRefreshTimer == null)
            {
                _rbacRefreshTimer = new Timer(async _ => await RefreshRbacPolicyBackground(),
                    null, _rbacRefreshInterval, _rbacRefreshInterval);
            }
        }

        private static async Task RefreshRbacPolicyBackground()
        {
            if (_policyGetter == null) return;

            try
            {
                var policyRes = await _policyGetter.Policy(new RBACPolicyRequest());
                lock (_rbacLock)
                {
                    _cachedRbacPolicy = new RbacPolicy(policyRes.Policy);
                    _rbacPolicyLastFetched = DateTime.UtcNow;
                }
            }
            catch
            {
            }
        }

    }
}
