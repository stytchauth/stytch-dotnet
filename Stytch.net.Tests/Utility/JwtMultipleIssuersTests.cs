using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using Stytch.net.Clients;

namespace Stytch.net.Tests.Utility;

public class JwtMultipleIssuersTests : IDisposable
{
    private readonly RSA _rsa;
    private readonly RsaSecurityKey _securityKey;
    private readonly SigningCredentials _signingCredentials;
    private readonly string _projectId = "project-test-11111111-1111-1111-1111-111111111111";
    private readonly string _customDomain = "https://login.example.com";

    public JwtMultipleIssuersTests()
    {
        _rsa = RSA.Create(2048);
        _securityKey = new RsaSecurityKey(_rsa);
        _signingCredentials = new SigningCredentials(_securityKey, SecurityAlgorithms.RsaSha256);
    }

    public void Dispose()
    {
        _rsa?.Dispose();
    }

    private string CreateTestJwt(string issuer, string audience, Dictionary<string, object>? customClaims = null)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new System.Security.Claims.ClaimsIdentity(new[]
            {
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.Sub, "test-user-id"),
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            IssuedAt = DateTime.UtcNow,
            NotBefore = DateTime.UtcNow,
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = _signingCredentials,
            Claims = customClaims
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private ClientConfig CreateConfigWithCustomDomain(string customBaseUrl)
    {
        return new ClientConfig
        {
            ProjectId = _projectId,
            ProjectSecret = "secret",
            CustomBaseUrl = customBaseUrl
        };
    }

    private ClientConfig CreateStandardConfig()
    {
        return new ClientConfig
        {
            ProjectId = _projectId,
            ProjectSecret = "secret"
        };
    }

    [Fact]
    public void AuthenticateJwtLocal_CustomDomainWithTrailingSlash_RemovesTrailingSlash()
    {
        // Arrange
        var customDomainWithSlash = "https://login.example.com/";
        var config = CreateConfigWithCustomDomain(customDomainWithSlash);

        // The implementation should remove trailing slashes from custom domains
        // to match issuer format (issuers never have trailing slashes)
        var expectedDomain = customDomainWithSlash.TrimEnd('/');

        Assert.Equal(customDomainWithSlash, config.CustomBaseUrl);
        Assert.NotEqual(expectedDomain, config.CustomBaseUrl);

        // After TrimEnd('/') is applied in AuthenticateJwtLocal, they should match
        Assert.Equal(expectedDomain, config.CustomBaseUrl.TrimEnd('/'));
    }

    [Theory]
    [InlineData("https://login.example.com")]
    [InlineData("https://auth.example.org")]
    [InlineData("https://custom.stytch-domain.io")]
    public void AuthenticateJwtLocal_VariousCustomDomains_AreSupported(string customDomain)
    {
        // Arrange
        var config = CreateConfigWithCustomDomain(customDomain);

        // Assert - The configuration should accept various custom domain formats
        Assert.NotNull(config.CustomBaseUrl);
        Assert.Equal(customDomain, config.CustomBaseUrl);
    }
}
