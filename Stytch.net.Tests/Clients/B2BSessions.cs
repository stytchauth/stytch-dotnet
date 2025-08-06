using Microsoft.IdentityModel.Tokens;
using Stytch.net.Exceptions;
using Stytch.net.Models;

namespace Stytch.net.Tests.Clients;

public class B2BSessions : B2BTestBase
{
    private readonly Task<B2BMagicLinksAuthenticateResponse> authenticateResponseTask;

    public B2BSessions() : base()
    {
        // This is the only way to get a B2B Session JWT from the sandbox API at the moment
        var request =
            new B2BMagicLinksAuthenticateRequest(magicLinksToken: "DOYoip3rvIMMW5lgItikFK-Ak1CfMsgjuiCyI7uuU94=")
            {
                SessionDurationMinutes = 60,
            };

        authenticateResponseTask = b2bClient.MagicLinks.Authenticate(request);
    }

    [Fact]
    public async Task AuthenticateJwtLocal_ShouldReturnSession()
    {
        // Arrange
        var magicLinkRes = await authenticateResponseTask;
        var memberSession = magicLinkRes.MemberSession;

        // Act
        var localSession =
            await b2bClient.Sessions.AuthenticateJwtLocal(new B2BAuthenticateJwtLocalRequest(magicLinkRes.SessionJwt));

        // Assert
        Assert.Equal(memberSession.MemberSessionId, localSession.MemberSessionId);
        Assert.Equal(memberSession.MemberId, localSession.MemberId);
        Assert.Equal(memberSession.OrganizationId, localSession.OrganizationId);
        AssertEqualTimestamps(memberSession.StartedAt, localSession.StartedAt);
        AssertEqualTimestamps(memberSession.LastAccessedAt, localSession.LastAccessedAt);
        AssertEqualTimestamps(memberSession.ExpiresAt, localSession.ExpiresAt);
        Assert.Equal(memberSession.AuthenticationFactors[0].EmailFactor.EmailAddress,
            localSession.AuthenticationFactors[0].EmailFactor.EmailAddress);
        Assert.Equal(memberSession.AuthenticationFactors[0].EmailFactor.EmailId,
            localSession.AuthenticationFactors[0].EmailFactor.EmailId);
        Assert.Equal(memberSession.CustomClaims, localSession.CustomClaims);
        Assert.Equal(memberSession.Roles, localSession.Roles);
    }

    [Fact]
    public async Task AuthenticateJwtLocal_FailsWithInvalidSignature()
    {
        // Arrange
        var magicLinkRes = await authenticateResponseTask;
        var request = new B2BAuthenticateJwtLocalRequest($"{magicLinkRes.SessionJwt}invalid");

        // Act
        await Assert.ThrowsAsync<SecurityTokenInvalidSignatureException>(() =>
            b2bClient.Sessions.AuthenticateJwtLocal(request));
    }

    [Fact]
    public async Task AuthenticateJwtLocal_FailsWithInvalidLifetimeValidation()
    {
        // Arrange
        var magicLinkRes = await authenticateResponseTask;
        var request = new B2BAuthenticateJwtLocalRequest(magicLinkRes.SessionJwt)
        {
            LifetimeValidator = bool (DateTime? notbefore, DateTime? expires, SecurityToken securitytoken,
                TokenValidationParameters validationparameters) => false
        };

        // Act
        await Assert.ThrowsAsync<SecurityTokenInvalidLifetimeException>(() =>
            b2bClient.Sessions.AuthenticateJwtLocal(request));
    }

    [Fact(Skip = "Missing roles in Sandbox Session Response")]
    public async Task AuthenticateJwtLocal_PerformsAuthorizationCheckSuccessfully()
    {
        // Arrange
        var magicLinkRes = await authenticateResponseTask;
        var request = new B2BAuthenticateJwtLocalRequest(magicLinkRes.SessionJwt)
        {
            AuthorizationCheck = new B2BSessionsAuthorizationCheck
            {
                OrganizationId = null,
                ResourceId = null,
                Action = null
            }
        };

        // Act
        await b2bClient.Sessions.AuthenticateJwtLocal(request);
    }

    [Fact]
    public async Task AuthenticateJwtLocal_PerformsAuthorizationCheckWithFailedTenancy()
    {
        // Arrange
        var magicLinkRes = await authenticateResponseTask;
        var request = new B2BAuthenticateJwtLocalRequest(magicLinkRes.SessionJwt)
        {
            AuthorizationCheck = new B2BSessionsAuthorizationCheck
            {
                OrganizationId = "some-other-organization-id",
                ResourceId = "stytch.self",
                Action = "delete"
            }
        };

        // Act
        await Assert.ThrowsAsync<StytchTenancyMismatchException>(() => b2bClient.Sessions.AuthenticateJwtLocal(request));
    }

    [Fact]
    public async Task AuthenticateJwtLocal_PerformsAuthorizationCheckWithFailedPermissions()
    {
        // Arrange
        var magicLinkRes = await authenticateResponseTask;
        var request = new B2BAuthenticateJwtLocalRequest(magicLinkRes.SessionJwt)
        {
            AuthorizationCheck = new B2BSessionsAuthorizationCheck
            {
                OrganizationId = "organization-test-007d9d4a-deac-4a87-ba0a-e6e8afba4d4b",
                ResourceId = "stytch.self",
                Action = "delete"
            }
        };

        // Act
        await Assert.ThrowsAsync<StytchInvalidPermissionsException>(() => b2bClient.Sessions.AuthenticateJwtLocal(request));
    }
}
