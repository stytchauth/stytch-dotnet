using System;
using System.Net.Http;
using System.Text;
using Xunit;
using Stytch.net.Clients;
using Stytch.net.Models;

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
        var client = new ApiClient(baseUrl, projectID, projectSecret);

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

        var apiClient = new ApiClient("https://test.stytch.com", "project-test-TODO", "secret-test-TODO");

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
}
