using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Stytch.net.Clients;

public static class Utility
{
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

        return new AuthenticateJwtResult()
        {
            Subject = (string)result.Claims[ClaimTypes.NameIdentifier],
            CustomClaims = customClaims
        };
    }

    private static async Task<JsonWebKeySet> GetJwksFromUrl(HttpClient client, string jwksUrl)
    {
        if (_cachedJwks == null || DateTime.UtcNow - _jwksLastFetched > _jwksRefreshInterval)
        {
            string jwksJson = await client.GetStringAsync(jwksUrl);
            _cachedJwks = new JsonWebKeySet(jwksJson);
            _jwksLastFetched = DateTime.UtcNow;
        }

        return _cachedJwks;
    }
}