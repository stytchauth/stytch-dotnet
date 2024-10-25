using System.Text.Json;
using Microsoft.IdentityModel.Tokens;
using Stytch.net.Exceptions;
using Stytch.net.Models.Consumer;

namespace Stytch.net.Tests.Clients;

public class M2M : TestBase
{
    [Fact]
    public async Task M2MToken_Success()
    {
        // Arrange
        var client = new Stytch.net.Clients.ConsumerClient(_clientConfig);

        // Act
        // A (temporary) hack - we do not support sandbox values for M2M so we provisioned a client 
        // that reuses the Project ID and Project Secret values we already have saved in CI 
        var res = await client.M2M.Token(new M2MTokenRequest(_clientConfig.ProjectId, _clientConfig.ProjectSecret));

        // Assert
        Assert.NotEmpty(res.AccessToken);
        Assert.Equal("bearer", res.TokenType);
        Assert.Equal(3600, res.ExpiresIn);
    }

    [Fact]
    public async Task M2MAuthenticateToken_Success()
    {
        // Arrange
        var client = new Stytch.net.Clients.ConsumerClient(_clientConfig);

        // Act
        var tokenRes = await client.M2M.Token(new M2MTokenRequest(_clientConfig.ProjectId, _clientConfig.ProjectSecret));

        var authRes = await client.M2M.AuthenticateToken(new M2MAuthenticateTokenRequest(tokenRes.AccessToken));

        // Assert
        Assert.NotNull(authRes);
        Assert.Equal(_clientConfig.ProjectId, authRes.ClientId);
        Assert.Equal(new List<string> { "read:users", "write:members" }, authRes.Scopes);
        Assert.Equivalent(JsonDocument.Parse("{\"set\":true}").RootElement, authRes.CustomClaims["custom_value"]);
    }

    [Fact]
    public async Task M2MAuthenticateToken_FailureInvalidSignature()
    {
        // Arrange
        var client = new Stytch.net.Clients.ConsumerClient(_clientConfig);

        // Act
        var tokenRes = await client.M2M.Token(new M2MTokenRequest(_clientConfig.ProjectId, _clientConfig.ProjectSecret));

        // Assert
        await Assert.ThrowsAsync<SecurityTokenInvalidSignatureException>(() =>
        {
            return client.M2M.AuthenticateToken(new M2MAuthenticateTokenRequest($"{tokenRes.AccessToken}garbage"));
        });
    }

    [Fact]
    public async Task M2MAuthenticateToken_SuccessWithRequiredScopes()
    {
        // Arrange
        var client = new Stytch.net.Clients.ConsumerClient(_clientConfig);

        // Act
        var tokenRes = await client.M2M.Token(new M2MTokenRequest(_clientConfig.ProjectId, _clientConfig.ProjectSecret));

        var authRes = await client.M2M.AuthenticateToken(new M2MAuthenticateTokenRequest(tokenRes.AccessToken)
        {
            RequiredScopes = new List<string> { "read:users" }
        });

        // Assert
        Assert.NotNull(authRes);
    }

    [Fact]
    public async Task M2MAuthenticateToken_FailureOnMissingScopes()
    {
        // Arrange
        var client = new Stytch.net.Clients.ConsumerClient(_clientConfig);

        // Act
        var tokenRes = await client.M2M.Token(new M2MTokenRequest(_clientConfig.ProjectId, _clientConfig.ProjectSecret));

        // Act
        var exception = await Assert.ThrowsAsync<StytchMissingScopesException>(() =>
        {
            return client.M2M.AuthenticateToken(new M2MAuthenticateTokenRequest(tokenRes.AccessToken)
            {
                RequiredScopes = new List<string> { "read:users", "superadmin" }
            });
        });

        // Assert
        Assert.Equal("superadmin", exception.RequiredScope);
        Assert.Equal(exception.ClientId, _clientConfig.ProjectId);
    }

    [Fact]
    public async Task M2MAuthenticateToken_SuccessWithLifetimeValidation()
    {
        // Arrange
        var client = new Stytch.net.Clients.ConsumerClient(_clientConfig);

        // Act
        var tokenRes = await client.M2M.Token(new M2MTokenRequest(_clientConfig.ProjectId, _clientConfig.ProjectSecret));

        bool LifetimeValidator(DateTime? notbefore, DateTime? expires, SecurityToken securitytoken,
            TokenValidationParameters validationparameters)
        {
            return DateTime.UtcNow > notbefore && DateTime.UtcNow < expires;
        }

        var authRes = await client.M2M.AuthenticateToken(new M2MAuthenticateTokenRequest(tokenRes.AccessToken)
        {
            LifetimeValidator = LifetimeValidator
        });

        // Assert
        Assert.NotNull(authRes);
    }


    [Fact]
    public async Task M2MAuthenticateToken_FailureOnLifetimeValidation()
    {
        // Arrange
        var client = new Stytch.net.Clients.ConsumerClient(_clientConfig);

        // Act
        var tokenRes = await client.M2M.Token(new M2MTokenRequest(_clientConfig.ProjectId, _clientConfig.ProjectSecret));

        // Act
        var exception = await Assert.ThrowsAsync<SecurityTokenInvalidLifetimeException>(() =>
        {
            bool LifetimeValidator(DateTime? notbefore, DateTime? expires, SecurityToken securitytoken,
                TokenValidationParameters validationparameters)
            {
                return false;
            }

            return client.M2M.AuthenticateToken(new M2MAuthenticateTokenRequest(tokenRes.AccessToken)
            {
                RequiredScopes = new List<string> { "read:users", "superadmin" },
                LifetimeValidator = LifetimeValidator
            });
        });

        // Assert
        Assert.NotNull(exception);
    }
}