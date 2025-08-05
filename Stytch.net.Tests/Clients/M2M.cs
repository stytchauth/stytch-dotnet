using System.Text.Json;
using Microsoft.IdentityModel.Tokens;
using Stytch.net.Exceptions;
using Stytch.net.Models;

namespace Stytch.net.Tests.Clients;

public class M2M : ConsumerTestBase, IAsyncLifetime
{

    private M2MClientsCreateResponse createRes = null!;
    private M2MTokenResponse tokenRes = null!;
    public M2M() : base()
    {
    }

    public async Task InitializeAsync()
    {
        // Ensure the client is created before running tests
        var req = new M2MClientsCreateRequest(new List<string> { "read:users", "write:members" });
        createRes = await consumerClient.M2M.Clients.Create(req);
        Assert.NotNull(createRes);
        Assert.NotNull(createRes.M2MClient);
        tokenRes = await consumerClient.M2M.Token(new M2MTokenRequest(createRes.M2MClient.ClientId, createRes.M2MClient.ClientSecret));
    }

    public async Task DisposeAsync()
    {
        await consumerClient.M2M.Clients.Delete(new M2MClientsDeleteRequest(createRes.M2MClient.ClientId));
    }

    [Fact]
    public void M2MToken_Success()
    {
        // Arrange
        var res = tokenRes;

        // Assert
        Assert.NotEmpty(res.AccessToken);
        Assert.Equal("bearer", res.TokenType);
        Assert.Equal(3600, res.ExpiresIn);
    }

    [Fact]
    public async Task M2MAuthenticateToken_Success()
    {
        // Act
        var authRes = await consumerClient.M2M.AuthenticateToken(new M2MAuthenticateTokenRequest(tokenRes.AccessToken));

        // Assert
        Assert.NotNull(authRes);
        Assert.Equal(createRes.M2MClient.ClientId, authRes.ClientId);
        Assert.Equal(new List<string> { "read:users", "write:members" }, authRes.Scopes);
    }

    [Fact]
    public async Task M2MAuthenticateToken_FailureInvalidSignature()
    {
        // Assert
        await Assert.ThrowsAsync<SecurityTokenInvalidSignatureException>(() =>
        {
            return consumerClient.M2M.AuthenticateToken(new M2MAuthenticateTokenRequest($"{tokenRes.AccessToken}garbage"));
        });
    }

    [Fact]
    public async Task M2MAuthenticateToken_SuccessWithRequiredScopes()
    {
        // Act
        var authRes = await consumerClient.M2M.AuthenticateToken(new M2MAuthenticateTokenRequest(tokenRes.AccessToken)
        {
            RequiredScopes = new List<string> { "read:users" }
        });

        // Assert
        Assert.NotNull(authRes);
    }

    [Fact]
    public async Task M2MAuthenticateToken_FailureOnMissingScopes()
    {
        // Act
        var exception = await Assert.ThrowsAsync<StytchMissingScopesException>(() =>
        {
            return consumerClient.M2M.AuthenticateToken(new M2MAuthenticateTokenRequest(tokenRes.AccessToken)
            {
                RequiredScopes = new List<string> { "read:users", "superadmin" }
            });
        });

        // Assert
        Assert.Equal("superadmin", exception.RequiredScope);
        Assert.Equal(exception.ClientId, createRes.M2MClient.ClientId);
    }

    [Fact]
    public async Task M2MAuthenticateToken_SuccessWithLifetimeValidation()
    {
        // Act
        bool LifetimeValidator(DateTime? notbefore, DateTime? expires, SecurityToken securitytoken,
            TokenValidationParameters validationparameters)
        {
            return DateTime.UtcNow > notbefore && DateTime.UtcNow < expires;
        }

        var authRes = await consumerClient.M2M.AuthenticateToken(new M2MAuthenticateTokenRequest(tokenRes.AccessToken)
        {
            LifetimeValidator = LifetimeValidator
        });

        // Assert
        Assert.NotNull(authRes);
    }


    [Fact]
    public async Task M2MAuthenticateToken_FailureOnLifetimeValidation()
    {
        // Act
        var exception = await Assert.ThrowsAsync<SecurityTokenInvalidLifetimeException>(() =>
        {
            bool LifetimeValidator(DateTime? notbefore, DateTime? expires, SecurityToken securitytoken,
                TokenValidationParameters validationparameters)
            {
                return false;
            }

            return consumerClient.M2M.AuthenticateToken(new M2MAuthenticateTokenRequest(tokenRes.AccessToken)
            {
                RequiredScopes = new List<string> { "read:users", "superadmin" },
                LifetimeValidator = LifetimeValidator
            });
        });

        // Assert
        Assert.NotNull(exception);
    }
}
