using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
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

            var tokenHandler = new JwtSecurityTokenHandler { MapInboundClaims = false };
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
        private static TimeSpan _b2bRbacRefreshInterval = TimeSpan.FromMinutes(15);

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
            if (_cachedB2BRbacPolicy == null || DateTime.UtcNow - _b2bRbacPolicyLastFetched > _b2bRbacRefreshInterval)
            {
                var policyRes = await policyGetter.Policy(new B2BRBACPolicyRequest());
                _cachedB2BRbacPolicy = new B2BRbacPolicy(policyRes.Policy);
                _b2bRbacPolicyLastFetched = DateTime.UtcNow;
            }

            return _cachedB2BRbacPolicy;
        }

        private static RbacPolicy _cachedRbacPolicy;
        private static DateTime _rbacPolicyLastFetched;
        private static TimeSpan _rbacRefreshInterval = TimeSpan.FromMinutes(15);

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
            if (_cachedRbacPolicy == null || DateTime.UtcNow - _rbacPolicyLastFetched > _rbacRefreshInterval)
            {
                var policyRes = await policyGetter.Policy(new RBACPolicyRequest());
                _cachedRbacPolicy = new RbacPolicy(policyRes.Policy);
                _rbacPolicyLastFetched = DateTime.UtcNow;
            }

            return _cachedRbacPolicy;
        }

    }
}
