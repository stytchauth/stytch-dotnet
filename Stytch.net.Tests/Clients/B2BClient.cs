using Stytch.net.Models;

namespace Stytch.net.Tests.Clients;

public class B2BClient : B2BTestBase
{
    [Fact]
    public async void GetJwks_ShouldSucceed()
    {
        var jwksRes = await b2bClient.Sessions.GetJWKS(new B2BSessionsGetJWKSRequest(_clientConfig.ProjectId));
        Assert.NotEmpty(jwksRes.Keys);
    }
}
