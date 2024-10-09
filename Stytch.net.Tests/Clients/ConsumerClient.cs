using Stytch.net.Clients;
using System.Reflection;
using Stytch.net.Exceptions;
using Stytch.net.Models.Consumer;

public class ConsumerClient
{
    private readonly ClientConfig _clientConfig;

    public ConsumerClient()
    {
        string? projectId = "project-test-41fc674f-77f6-43e8-bba2-65ac5a3cd7dd";
        if (string.IsNullOrEmpty(projectId))
        {
            throw new InvalidOperationException("Required environment variable PROJECT_ID is not set.");
        }

        string? projectSecret = "secret-test-VHtZKBgk_tGQ0fohzOrLklEhJTg7x8uNmd0=";
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

    // [Fact]
    // public void ApiClient_Sets_BasicAuthHeader_Correctly()
    // {
    //     // Arrange
    //     var client = new Stytch.net.Clients.ConsumerClient(_clientConfig);
    //
    //     var sdkVersion = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1.0.0";
    //     var expectedUserAgent = $"stytch-dotnet/{sdkVersion}";
    //
    //     var expectedAuthValue = "cHJvamVjdC10ZXN0LWI5NmRhYmIzLWZjNjQtNDFmMC1hMDY0LWUyM2RmODZmZmUyYTpzaGhoaA==";
    //
    //     var expectedBaseAddress = $"https://test.stytch.com/";
    //
    //     // Act
    //     var httpClient = (HttpClient)typeof(Stytch.net.Clients.ConsumerClient)
    //         .GetField("_httpClient", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
    //         ?.GetValue(client)!;
    //
    //     // Assert
    //     Assert.NotNull(httpClient);
    //     // Authorization header
    //     Assert.NotNull(httpClient.DefaultRequestHeaders.Authorization);
    //     Assert.Equal("Basic", httpClient.DefaultRequestHeaders.Authorization.Scheme);
    //     Assert.NotNull(httpClient.DefaultRequestHeaders.Authorization.Parameter);
    //
    //     // User Agent Header
    //     Assert.Equal(httpClient.DefaultRequestHeaders.UserAgent.ToString(), expectedUserAgent);
    //
    //     // Environment
    //     Assert.Equal(httpClient.BaseAddress?.ToString(), expectedBaseAddress);
    // }


    [Fact]
    public async Task MagicLinksEmailSend_ShouldReturnSandboxResponse()
    {
        // Arrange
        var client = new Stytch.net.Clients.ConsumerClient(_clientConfig);

        var request = new MagicLinksEmailSendRequest(email: "sandbox@stytch.com")
        {
            //            Email = "sandbox@stytch.com",
            UserId = "sdd",
            //  SignupExpirationMinutes = 12,
        };

        // Act
        var response = await client.MagicLinks.Email.Send(request);

        // Assert
        Assert.Equal(200, response.StatusCode);
        Assert.Equal("user-test-e3795c81-f849-4167-bfda-e4a6e9c280fd", response.UserId);
    }

    /*[Fact]
    public async Task MagicLinksAuthenticate_ShouldReturnSandboxResponse()
    {
        // Arrange
        var client = new Stytch.net.Clients.ConsumerClient(_clientConfig);

        // Act
        var response = await client.MagicLinks.Authenticate(new MagicLinksAuthenticateRequest()
        {
            Token = "DOYoip3rvIMMW5lgItikFK-Ak1CfMsgjuiCyI7uuU94="
        });

        // Assert
        Assert.Equal(200, response.StatusCode);
        Assert.Equal("user-test-e3795c81-f849-4167-bfda-e4a6e9c280fd", response.UserId);
    }

    [Fact]
    public async Task MagicLinksAuthenticate_ShouldReturnSandboxNotAuthorizedError()
    {
        // Arrange
        var client = new Stytch.net.Clients.ConsumerClient(_clientConfig);

        // Act
        var exception = await Assert.ThrowsAsync<StytchApiException>(() =>
        {
            return client.MagicLinks.Authenticate(new MagicLinksAuthenticateRequest()
            {
                Token = "3pzjQpgksDlGKWEwUq2Up--hCHC_0oamfLHyfspKDFU="
            });
        });

        // Assert
        Assert.Equal(401, exception.StatusCode);
        Assert.Equal("unable_to_auth_magic_link", exception.ErrorType);
        Assert.Equal(
            "The magic link could not be authenticated because it was either already used or expired. Send another magic link to this user.",
            exception.ErrorMessage
        );
        Assert.Equal("https://stytch.com/docs/api/errors/401#unable_to_auth_magic_link", exception.ErrorUrl);
    }*/
}