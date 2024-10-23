using Stytch.net.Clients;
using System.Reflection;
using Stytch.net.Exceptions;
using Stytch.net.Models.Consumer;

public class ConsumerClient
{
    private readonly ClientConfig _clientConfig;

    public ConsumerClient()
    {
        string? projectId = Environment.GetEnvironmentVariable("PROJECT_ID");
        if (string.IsNullOrEmpty(projectId))
        {
            throw new InvalidOperationException("Required environment variable PROJECT_ID is not set.");
        }

        string? projectSecret = Environment.GetEnvironmentVariable("PROJECT_SECRET");
        if (string.IsNullOrEmpty(projectId))
        {
            throw new InvalidOperationException("Required environment variable PROJECT_SECRET is not set.");
        }

        _clientConfig = new ClientConfig
        {
            ProjectId = projectId,
            ProjectSecret = projectSecret,
        };
    }

    [Fact]
    public void ApiClient_Sets_BasicAuthHeader_Correctly()
    {
        // Arrange
        var client = new Stytch.net.Clients.ConsumerClient(_clientConfig);

        var expectedUserAgent = $"stytch-dotnet/";
        var expectedBaseAddress = $"https://test.stytch.com/";

        // Act
        var httpClient = (HttpClient)typeof(Stytch.net.Clients.ConsumerClient)
            .GetField("_httpClient", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.GetValue(client)!;

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
        var client = new Stytch.net.Clients.ConsumerClient(_clientConfig);

        var request = new MagicLinksEmailSendRequest(email: "sandbox@stytch.com");

        // Act
        var response = await client.MagicLinks.Email.Send(request);

        // Assert
        Assert.Equal(200, response.StatusCode);
        Assert.Equal("user-test-e3795c81-f849-4167-bfda-e4a6e9c280fd", response.UserId);
    }

    [Fact]
    public async Task MagicLinksAuthenticate_ShouldReturnSandboxResponse()
    {
        // Arrange
        var client = new Stytch.net.Clients.ConsumerClient(_clientConfig);

        // Act
        var response =
            await client.MagicLinks.Authenticate(
                new MagicLinksAuthenticateRequest(token: "DOYoip3rvIMMW5lgItikFK-Ak1CfMsgjuiCyI7uuU94="));

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
        var client = new Stytch.net.Clients.ConsumerClient(_clientConfig);

        // Act
        var response = await client.MagicLinks.Authenticate(
            new MagicLinksAuthenticateRequest(token: "DOYoip3rvIMMW5lgItikFK-Ak1CfMsgjuiCyI7uuU94=")
            {
                SessionDurationMinutes = 60
            });

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
        var client = new Stytch.net.Clients.ConsumerClient(_clientConfig);

        // Act
        var exception = await Assert.ThrowsAsync<StytchApiException>(() =>
        {
            return client.MagicLinks.Authenticate(
                new MagicLinksAuthenticateRequest(token: "3pzjQpgksDlGKWEwUq2Up--hCHC_0oamfLHyfspKDFU="));
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
        var client = new Stytch.net.Clients.ConsumerClient(_clientConfig);

        // Act
        var exception = await Assert.ThrowsAsync<StytchApiException>(() =>
        {
            return client.Sessions.Get(
                new SessionsGetRequest(userId: "user-test-e3795c81-f849-4167-bfda-e4a6e9c280fd"));
        });

        // Assert
        Assert.Equal(404, exception.StatusCode);
        Assert.Equal("user_not_found", exception.ErrorType);
    }


    [Fact]
    public async Task UsersSearch_SerializesSuccessfully()
    {
        // Arrange
        var client = new Stytch.net.Clients.ConsumerClient(_clientConfig);

        // Act
        var res = await client.Users.Search(new UsersSearchRequest()
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
        });

        // Assert
        Assert.Equal(200, res.StatusCode);
        Assert.Null(res.ResultsMetadata.NextCursor);
    }

    [Fact]
    public async Task SessionsAuthenticate_SerializesDateTimesSuccessfully()
    {
        // Arrange
        var client = new Stytch.net.Clients.ConsumerClient(_clientConfig);

        // Act
        var res = await client.Sessions.Authenticate(new SessionsAuthenticateRequest()
        {
            SessionToken = "WJtR5BCy38Szd5AfoDpf0iqFKEt4EE5JhjlWUY7l3FtY"
        });

        // Assert
        DateTime startedAt = Assert.NotNull(res.Session.StartedAt);
        // All Sandbox Sessions started at the same time
        Assert.Equal(
            new DateTime(2021, 8, 28, 0, 41, 59),
            startedAt,
            new TimeSpan(0, 0, 1)
        );
    }
}