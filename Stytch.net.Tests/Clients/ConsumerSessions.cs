using Microsoft.IdentityModel.Tokens;
using Stytch.net.Models.Consumer;

namespace Stytch.net.Tests.Clients;

public class ConsumerSessions : TestBase
{
    private readonly Task<SessionsAuthenticateResponse> sessionResTask;

    public ConsumerSessions() : base()
    {
        sessionResTask = consumerClient.Sessions.Authenticate(new SessionsAuthenticateRequest()
        {
            SessionToken = "WJtR5BCy38Szd5AfoDpf0iqFKEt4EE5JhjlWUY7l3FtY"
        });
    }

    [Fact]
    public async Task AuthenticateJwtLocal_ShouldReturnSession()
    {
        // Arrange
        var sessionRes = await sessionResTask;

        // Act
        var localSession =
            await consumerClient.Sessions.AuthenticateJwtLocal(new AuthenticateJwtLocalRequest(sessionRes.SessionJwt));

        // Assert
        Assert.Equal(sessionRes.Session.SessionId, localSession.SessionId);
        Assert.Equal(sessionRes.Session.UserId, localSession.UserId);
        AssertEqualTimestamps(sessionRes.Session.StartedAt, localSession.StartedAt);
        AssertEqualTimestamps(sessionRes.Session.LastAccessedAt, localSession.LastAccessedAt);
        AssertEqualTimestamps(sessionRes.Session.ExpiresAt, localSession.ExpiresAt);
        Assert.Equal(sessionRes.Session.AuthenticationFactors.Count, localSession.AuthenticationFactors.Count);
        Assert.Equal(sessionRes.Session.AuthenticationFactors[0].EmailFactor.EmailAddress,
            localSession.AuthenticationFactors[0].EmailFactor.EmailAddress);
        Assert.Equal(sessionRes.Session.AuthenticationFactors[0].EmailFactor.EmailId,
            localSession.AuthenticationFactors[0].EmailFactor.EmailId);
        Assert.Equal(sessionRes.Session.CustomClaims, localSession.CustomClaims);
    }

    [Fact]
    public async Task AuthenticateJwtLocal_FailsWithInvalidSignature()
    {
        // Arrange
        var sessionRes = await sessionResTask;
        var request = new AuthenticateJwtLocalRequest($"{sessionRes.SessionJwt}invalid");

        // Act
        await Assert.ThrowsAsync<SecurityTokenInvalidSignatureException>(() =>
            consumerClient.Sessions.AuthenticateJwtLocal(request));
    }

    [Fact]
    public async Task AuthenticateJwtLocal_FailsWithInvalidLifetimeValidation()
    {
        // Arrange
        var sessionRes = await sessionResTask;
        var request = new AuthenticateJwtLocalRequest(sessionRes.SessionJwt)
        {
            LifetimeValidator = bool (DateTime? notbefore, DateTime? expires, SecurityToken securitytoken,
                TokenValidationParameters validationparameters) =>
            {
                return false;
            }
        };

        // Act
        await Assert.ThrowsAsync<SecurityTokenInvalidLifetimeException>(() =>
            consumerClient.Sessions.AuthenticateJwtLocal(request));
    }

}