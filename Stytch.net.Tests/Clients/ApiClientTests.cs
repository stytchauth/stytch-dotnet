using System;
using System.Net.Http;
using System.Text;
using Xunit;
using Stytch.net.Clients;
using Stytch.net.Models;
using System.Reflection;
using System.Net.Http.Headers;
using Stytch.net.Models.Consumer;

public class ApiClientTests
{
    [Fact]
    public void ApiClient_Sets_BasicAuthHeader_Correctly()
    {
        // Arrange
        var client = new ConsumerClient(new ClientConfig
        {
            ProjectId = "project-test-b96dabb3-fc64-41f0-a064-e23df86ffe2a",
            ProjectSecret = "shhhh",
            Environment = "https://api.example.com/"
        });


        var sdkVersion = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1.0.0";
        var expectedUserAgent = $"stytch-dotnet/{sdkVersion}";

        var expectedAuthValue = "cHJvamVjdC10ZXN0LWI5NmRhYmIzLWZjNjQtNDFmMC1hMDY0LWUyM2RmODZmZmUyYTpzaGhoaA==";

        var expectedBaseAddress = $"https://api.example.com/";

        // Act
        var httpClient = (HttpClient)typeof(ConsumerClient)
            .GetField("_httpClient", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.GetValue(client)!;

        // Assert
        Assert.NotNull(httpClient);
        // Authorization header
        Assert.NotNull(httpClient.DefaultRequestHeaders.Authorization);
        Assert.Equal("Basic", httpClient.DefaultRequestHeaders.Authorization.Scheme);
        Assert.Equal(expectedAuthValue, httpClient.DefaultRequestHeaders.Authorization.Parameter);

        // User Agent Header
        Assert.Equal(httpClient.DefaultRequestHeaders.UserAgent.ToString(), expectedUserAgent);

        // Environment
        Assert.Equal(httpClient.BaseAddress?.ToString(), expectedBaseAddress);
    }


    [Fact]
    public async Task SendMagicLink_ShouldReturnSuccessResponse()
    {
        // Arrange
        var client = new ConsumerClient(new ClientConfig
        {
            ProjectId = "project-test-27c9b831-3414-44b4-a1ca-cb507478ffe3",
            ProjectSecret = "secret-test-9BvxyAdbrTCvySEPHEW6inledt8VxkNUTz8=",
        });

        var request = new MagicLinksEmailSendRequest()
        {
            Email = "sandbox@stytch.com",
        };

        // Act
        var response = await client.MagicLinks.Email.Send(request);

        // Assert
        Assert.NotNull(response);
        Assert.NotEmpty(response.RequestId);
        Assert.NotEmpty(response.UserId);
    }
}