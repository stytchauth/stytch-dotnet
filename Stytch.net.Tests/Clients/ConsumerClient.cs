using System.Reflection;
using System.Text.Json;
using Newtonsoft.Json;
using Stytch.net.Clients;
using Stytch.net.Exceptions;
using Stytch.net.Models;
using Stytch.net.Tests.Clients;

public class ConsumerClient : ConsumerTestBase
{
    [Fact]
    public void ApiClient_Sets_BasicAuthHeader_Correctly()
    {
        // Arrange
        var expectedUserAgent = $"stytch-dotnet/";
        var expectedBaseAddress = $"https://test.stytch.com/";
        var httpClient = (HttpClient)typeof(Stytch.net.Clients.ConsumerClient)
            .GetField("_httpClient", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.GetValue(consumerClient)!;

        // Assert
        Assert.NotNull(httpClient);
        // Authorization header
        Assert.NotNull(httpClient.DefaultRequestHeaders.Authorization);
        Assert.Equal("Basic", httpClient.DefaultRequestHeaders.Authorization.Scheme);
        Assert.NotNull(httpClient.DefaultRequestHeaders.Authorization.Parameter);

        // User Agent Header
        Assert.StartsWith(expectedUserAgent, httpClient.DefaultRequestHeaders.UserAgent.ToString());

        // Environment
        Assert.Equal(httpClient.BaseAddress?.ToString(), expectedBaseAddress);
    }


    [Fact]
    public async Task MagicLinksEmailSend_ShouldReturnSandboxResponse()
    {
        // Arrange
        var request = new MagicLinksEmailSendRequest(email: "sandbox@stytch.com");

        // Act
        var response = await consumerClient.MagicLinks.Email.Send(request);

        // Assert
        Assert.Equal(200, response.StatusCode);
        Assert.Equal("user-test-e3795c81-f849-4167-bfda-e4a6e9c280fd", response.UserId);
    }

    [Fact]
    public async Task MagicLinksAuthenticate_ShouldReturnSandboxResponse()
    {
        // Arrange
        var request = new MagicLinksAuthenticateRequest(token: "DOYoip3rvIMMW5lgItikFK-Ak1CfMsgjuiCyI7uuU94=");

        // Act
        var response = await consumerClient.MagicLinks.Authenticate(request);

        // Assert
        Assert.Equal(200, response.StatusCode);
        Assert.Equal("user-test-e3795c81-f849-4167-bfda-e4a6e9c280fd", response.UserId);
        Assert.Empty(response.SessionJwt);
        Assert.Empty(response.SessionToken);
        Assert.Null(response.Session);
    }


    [Fact]
    public async Task MagicLinksAuthenticate_ShouldReturnSandboxResponseWithSession()
    {
        // Arrange
        var request = new MagicLinksAuthenticateRequest(token: "DOYoip3rvIMMW5lgItikFK-Ak1CfMsgjuiCyI7uuU94=")
        {
            SessionDurationMinutes = 60
        };

        // Act
        var response = await consumerClient.MagicLinks.Authenticate(request);

        // Assert
        Assert.NotNull(response.Session);
        Assert.NotNull(response.SessionJwt);
        Assert.NotNull(response.SessionToken);
        Assert.Equal("sandbox@stytch.com", response.Session.AuthenticationFactors[0].EmailFactor.EmailAddress);
    }

    [Fact]
    public async Task MagicLinksAuthenticate_ShouldReturnSandboxNotAuthorizedError()
    {
        // Arrange
        var request = new MagicLinksAuthenticateRequest(token: "3pzjQpgksDlGKWEwUq2Up--hCHC_0oamfLHyfspKDFU=");


        // Act
        var exception = await Assert.ThrowsAsync<StytchApiException>(() =>
        {
            return consumerClient.MagicLinks.Authenticate(request);
        });

        // Assert
        Assert.Equal(401, exception.StatusCode);
        Assert.Equal("unable_to_auth_magic_link", exception.ErrorType);
        Assert.Equal(
            "The magic link could not be authenticated because it was either already used or expired. Send another magic link to this user.",
            exception.ErrorMessage
        );
        Assert.Equal("https://stytch.com/docs/api/errors/401#unable_to_auth_magic_link", exception.ErrorUrl);
    }

    [Fact]
    public async Task SessionsGet_ShouldReturnSandboxNotAuthorizedError()
    {
        // Arrange
        var request = new SessionsGetRequest(userId: "user-test-e3795c81-f849-4167-bfda-e4a6e9c280fd");

        // Act
        var exception = await Assert.ThrowsAsync<StytchApiException>(() =>
        {
            return consumerClient.Sessions.Get(request);
        });

        // Assert
        Assert.Equal(404, exception.StatusCode);
        Assert.Equal("user_not_found", exception.ErrorType);
    }


    [Fact]
    public async Task UsersSearch_SerializesSuccessfully()
    {
        // Arrange
        var request = new UsersSearchRequest()
        {
            Limit = 3,
            Query = new SearchUsersQuery()
            {
                Operands = new List<SearchUsersQueryOperand>()
                {
                    new UserIdFilter()
                    {
                        FilterValue = new List<string> { "user-test-e3795c81-f849-4167-bfda-e4a6e9c280fd" },
                    },
                }
            }
        };

        // Act
        var res = await consumerClient.Users.Search(request);

        // Assert
        Assert.Equal(200, res.StatusCode);
        Assert.Null(res.ResultsMetadata.NextCursor);
    }

    [Fact]
    public async Task SessionsAuthenticate_SerializesDateTimesSuccessfully()
    {
        // Arrange
        var request = new SessionsAuthenticateRequest()
        {
            SessionToken = "WJtR5BCy38Szd5AfoDpf0iqFKEt4EE5JhjlWUY7l3FtY"
        };

        // Act
        var res = await consumerClient.Sessions.Authenticate(request);

        // Assert
        // All Sandbox Sessions started at the same time
        AssertEqualTimestamps(new DateTime(2021, 8, 28, 0, 41, 59), res.Session.StartedAt);
    }

    [Fact]
    public void Deserializes_WithNullRuleMatchType_ShouldSucceed()
    {
        // Sample JSON with rule_match_type as null
        var json = @"
            {
                ""request_id"": ""req_12345"",
                ""telemetry_id"": ""telemetry_abc123"",
                ""fingerprints"": {},
                ""verdict"": {
                    ""rule_match_type"": null
                },
                ""external_metadata"": {
                    ""user_action"": ""login_attempt"",
                    ""external_id"": ""user_001""
                },
                ""created_at"": ""2025-08-06T12:00:00Z"",
                ""expires_at"": ""2025-08-07T12:00:00Z"",
                ""status_code"": 200,
                ""properties"": {}
            }";

        // Act
        var response = JsonConvert.DeserializeObject<FraudFingerprintLookupResponse>(json);

        // Assert
        Assert.NotNull(response);
        Assert.NotNull(response.Verdict);
        Assert.Null(response.Verdict.RuleMatchType); // Key assertion
        Assert.Equal("telemetry_abc123", response.TelemetryId);
        Assert.Equal(200, response.StatusCode);
    }
}
