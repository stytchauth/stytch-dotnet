using System;
using System.Net.Http;
using System.Text;
using Xunit;
using Stytch.net.Clients;
using Stytch.net.Models;
using System.Reflection;
using System.Net.Http.Headers;

public class ApiClientTests
{
    [Fact]
    public void ApiClient_Sets_BasicAuthHeader_Correctly()
    {
        // Arrange
        var projectID = "myProjectID";
        var projectSecret = "myProjectSecret";
        var baseUrl = "https://api.example.com/";

        var expectedAuthValue = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{projectID}:{projectSecret}"));

        // Act
        var client = new ApiClient(new ClientConfig{
            projectID: "project-test-b96dabb3-fc64-41f0-a064-e23df86ffe2a", 
            projectSecret: "project-test-b96dabb3-fc64-41f0-a064-e23df86ffe2a", 
            Environment:"https://api.example.com/"}
        );

        // Access the _httpClient field using reflection to check the headers
        var httpClient = (HttpClient)typeof(ApiClient)
            .GetField("_httpClient", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.GetValue(client);

        // Assert
        Assert.NotNull(httpClient);
        Assert.NotNull(httpClient.DefaultRequestHeaders.Authorization);
        Assert.Equal("Basic", httpClient.DefaultRequestHeaders.Authorization.Scheme);
        Assert.Equal(expectedAuthValue, httpClient.DefaultRequestHeaders.Authorization.Parameter);
    }


    [Fact]
    public async Task SendMagicLink_ShouldReturnSuccessResponse()
    {
        // Arrange: set up a mock HttpClient and ApiClient here

        var apiClient = new ApiClient("https://test.stytch.com", "project-test-b96dabb3-fc64-41f0-a064-e23df86ffe2a", "secret-test-f_jNTikk_lVHgxqhDfx9zoboC8KCaORVG5E=");

        var request = new MagicLinkRequest
        {
            Email = "sandbox@stytch.com",
        };

        // Act
        var response = await apiClient.SendMagicLinkAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.NotEmpty(response.RequestId);
        Assert.NotEmpty(response.UserId);
    }

    [Fact]
    public void ApiClient_Sets_UserAgentHeader_Correctly()
    {
        // Arrange
        var baseUrl = "https://api.example.com/";
        var projectID = "myProjectID";
        var projectSecret = "myProjectSecret";

        // Act
        var client = new ApiClient(baseUrl, projectID, projectSecret);
        var httpClient = (HttpClient)typeof(ApiClient)
            .GetField("_httpClient", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.GetValue(client);

        // Retrieve the version from the assembly
        var sdkVersion = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1.0.0";
        var expectedUserAgent = $"Stytch-dotnet/{sdkVersion}";

        // Assert
        Assert.NotNull(httpClient);
        Assert.Equal(httpClient.DefaultRequestHeaders.UserAgent.ToString(),expectedUserAgent);
    }
}
