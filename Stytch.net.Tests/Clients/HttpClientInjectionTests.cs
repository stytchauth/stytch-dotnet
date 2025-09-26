using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using Stytch.net.Clients;
using Stytch.net.Models;

namespace Stytch.net.Tests.Clients;

public class HttpClientInjectionTests : IDisposable
{
    private readonly ClientConfig _testConfig;
    private readonly List<IDisposable> _disposables = new();

    public HttpClientInjectionTests()
    {
        _testConfig = new ClientConfig
        {
            ProjectId = "project-test-example",
            ProjectSecret = "secret-test-example"
        };
    }

    public void Dispose()
    {
        foreach (var disposable in _disposables)
        {
            disposable?.Dispose();
        }
        _disposables.Clear();
    }

    [Fact]
    public void ConsumerClient_DefaultBehavior_CreatesInternalHttpClients()
    {
        // Arrange & Act
        var client = new Stytch.net.Clients.ConsumerClient(_testConfig);
        _disposables.Add(client);

        // Assert
        // The client should be created successfully without throwing exceptions
        Assert.NotNull(client);
    }

    [Fact]
    public void B2BClient_DefaultBehavior_CreatesInternalHttpClients()
    {
        // Arrange & Act
        var client = new Stytch.net.Clients.B2BClient(_testConfig);
        _disposables.Add(client);

        // Assert
        // The client should be created successfully without throwing exceptions
        Assert.NotNull(client);
    }

    [Fact]
    public void ConsumerClient_CustomHttpClient_UsesProvidedClient()
    {
        // Arrange
        var customHttpClient = new HttpClient();
        var customFraudClient = new HttpClient();
        _disposables.Add(customHttpClient);
        _disposables.Add(customFraudClient);

        customHttpClient.DefaultRequestHeaders.Add("X-Custom-Header", "test-value");
        customFraudClient.DefaultRequestHeaders.Add("X-Custom-Fraud-Header", "fraud-test-value");

        var config = new ClientConfig
        {
            ProjectId = _testConfig.ProjectId,
            ProjectSecret = _testConfig.ProjectSecret,
            HttpClient = customHttpClient,
            FraudHttpClient = customFraudClient
        };

        // Act
        var client = new Stytch.net.Clients.ConsumerClient(config);
        _disposables.Add(client);

        // Assert
        Assert.NotNull(client);
        Assert.True(customHttpClient.DefaultRequestHeaders.Contains("X-Custom-Header"));
        Assert.True(customFraudClient.DefaultRequestHeaders.Contains("X-Custom-Fraud-Header"));
    }

    [Fact]
    public void B2BClient_CustomHttpClient_UsesProvidedClient()
    {
        // Arrange
        var customHttpClient = new HttpClient();
        var customFraudClient = new HttpClient();
        _disposables.Add(customHttpClient);
        _disposables.Add(customFraudClient);

        customHttpClient.DefaultRequestHeaders.Add("X-Custom-Header", "test-value");
        customFraudClient.DefaultRequestHeaders.Add("X-Custom-Fraud-Header", "fraud-test-value");

        var config = new ClientConfig
        {
            ProjectId = _testConfig.ProjectId,
            ProjectSecret = _testConfig.ProjectSecret,
            HttpClient = customHttpClient,
            FraudHttpClient = customFraudClient
        };

        // Act
        var client = new Stytch.net.Clients.B2BClient(config);
        _disposables.Add(client);

        // Assert
        Assert.NotNull(client);
        Assert.True(customHttpClient.DefaultRequestHeaders.Contains("X-Custom-Header"));
        Assert.True(customFraudClient.DefaultRequestHeaders.Contains("X-Custom-Fraud-Header"));
    }

    [Fact]
    public void BaseClient_CustomHttpClient_PreservesCustomHeaders()
    {
        // Arrange
        var customHttpClient = new HttpClient();
        _disposables.Add(customHttpClient);

        customHttpClient.DefaultRequestHeaders.Add("X-Custom-Header", "test-value");
        customHttpClient.DefaultRequestHeaders.Add("X-Another-Header", "another-value");

        var config = new ClientConfig
        {
            ProjectId = _testConfig.ProjectId,
            ProjectSecret = _testConfig.ProjectSecret,
            HttpClient = customHttpClient
        };

        // Act
        var client = new Stytch.net.Clients.ConsumerClient(config);
        _disposables.Add(client);

        // Assert
        Assert.True(customHttpClient.DefaultRequestHeaders.Contains("X-Custom-Header"));
        Assert.True(customHttpClient.DefaultRequestHeaders.Contains("X-Another-Header"));
        Assert.Equal("test-value", customHttpClient.DefaultRequestHeaders.GetValues("X-Custom-Header").First());
        Assert.Equal("another-value", customHttpClient.DefaultRequestHeaders.GetValues("X-Another-Header").First());
    }

    [Fact]
    public void BaseClient_CustomHttpClient_AddsRequiredHeaders()
    {
        // Arrange
        var customHttpClient = new HttpClient();
        var customFraudClient = new HttpClient();
        _disposables.Add(customHttpClient);
        _disposables.Add(customFraudClient);

        var config = new ClientConfig
        {
            ProjectId = _testConfig.ProjectId,
            ProjectSecret = _testConfig.ProjectSecret,
            HttpClient = customHttpClient,
            FraudHttpClient = customFraudClient
        };

        // Act
        var client = new Stytch.net.Clients.ConsumerClient(config);
        _disposables.Add(client);

        // Assert - Check that SDK headers were added
        Assert.NotNull(customHttpClient.DefaultRequestHeaders.Authorization);
        Assert.Equal("Basic", customHttpClient.DefaultRequestHeaders.Authorization.Scheme);
        Assert.True(customHttpClient.DefaultRequestHeaders.UserAgent.Any());

        Assert.NotNull(customFraudClient.DefaultRequestHeaders.Authorization);
        Assert.Equal("Basic", customFraudClient.DefaultRequestHeaders.Authorization.Scheme);
        Assert.True(customFraudClient.DefaultRequestHeaders.UserAgent.Any());
    }

    [Fact]
    public void BaseClient_CustomHttpClientWithBaseAddress_PreservesBaseAddress()
    {
        // Arrange
        var customUri = new Uri("https://custom.example.com");
        var customHttpClient = new HttpClient { BaseAddress = customUri };
        _disposables.Add(customHttpClient);

        var config = new ClientConfig
        {
            ProjectId = _testConfig.ProjectId,
            ProjectSecret = _testConfig.ProjectSecret,
            HttpClient = customHttpClient
        };

        // Act
        var client = new Stytch.net.Clients.ConsumerClient(config);
        _disposables.Add(client);

        // Assert
        Assert.Equal(customUri, customHttpClient.BaseAddress);
    }

    [Fact]
    public void BaseClient_CustomHttpClientWithoutBaseAddress_SetsEnvironmentBaseAddress()
    {
        // Arrange
        var customHttpClient = new HttpClient();
        _disposables.Add(customHttpClient);

        var config = new ClientConfig
        {
            ProjectId = _testConfig.ProjectId,
            ProjectSecret = _testConfig.ProjectSecret,
            HttpClient = customHttpClient,
            Environment = "https://test.stytch.com"
        };

        // Act
        var client = new Stytch.net.Clients.ConsumerClient(config);
        _disposables.Add(client);

        // Assert
        Assert.NotNull(customHttpClient.BaseAddress);
        Assert.Equal("https://test.stytch.com", customHttpClient.BaseAddress.ToString().TrimEnd('/'));
    }

    [Fact]
    public void BaseClient_DisposesInternalHttpClients_DoesNotDisposeCustomClients()
    {
        // Arrange
        var customHttpClient = new HttpClient();
        _disposables.Add(customHttpClient); // We'll dispose this ourselves

        customHttpClient.DefaultRequestHeaders.Add("X-Test-Header", "test-value");

        var config = new ClientConfig
        {
            ProjectId = _testConfig.ProjectId,
            ProjectSecret = _testConfig.ProjectSecret,
            HttpClient = customHttpClient
        };

        // Act - Create and dispose client in a scope
        Stytch.net.Clients.ConsumerClient client;
        {
            client = new Stytch.net.Clients.ConsumerClient(config);
            client.Dispose(); // Explicitly dispose the client
        }

        // Assert - Custom HttpClient should still be usable
        Assert.True(customHttpClient.DefaultRequestHeaders.Contains("X-Test-Header"));

        // Try to access headers - should not throw if not disposed
        var headerValues = customHttpClient.DefaultRequestHeaders.GetValues("X-Test-Header");
        Assert.Equal("test-value", headerValues.First());
    }

    [Fact]
    public void BaseClient_PartialCustomHttpClient_OnlyMainClient()
    {
        // Arrange
        var customHttpClient = new HttpClient();
        _disposables.Add(customHttpClient);

        customHttpClient.DefaultRequestHeaders.Add("X-Main-Client", "main-value");

        var config = new ClientConfig
        {
            ProjectId = _testConfig.ProjectId,
            ProjectSecret = _testConfig.ProjectSecret,
            HttpClient = customHttpClient
            // No FraudHttpClient specified - should create internal one
        };

        // Act
        var client = new Stytch.net.Clients.ConsumerClient(config);
        _disposables.Add(client);

        // Assert
        Assert.NotNull(client);
        Assert.True(customHttpClient.DefaultRequestHeaders.Contains("X-Main-Client"));
    }

    [Fact]
    public void BaseClient_PartialCustomHttpClient_OnlyFraudClient()
    {
        // Arrange
        var customFraudClient = new HttpClient();
        _disposables.Add(customFraudClient);

        customFraudClient.DefaultRequestHeaders.Add("X-Fraud-Client", "fraud-value");

        var config = new ClientConfig
        {
            ProjectId = _testConfig.ProjectId,
            ProjectSecret = _testConfig.ProjectSecret,
            FraudHttpClient = customFraudClient
            // No HttpClient specified - should create internal one
        };

        // Act
        var client = new Stytch.net.Clients.ConsumerClient(config);
        _disposables.Add(client);

        // Assert
        Assert.NotNull(client);
        Assert.True(customFraudClient.DefaultRequestHeaders.Contains("X-Fraud-Client"));
    }

    [Fact]
    public void BaseClient_MultipleDisposeCalls_DoesNotThrow()
    {
        // Arrange
        var client = new Stytch.net.Clients.ConsumerClient(_testConfig);

        // Act & Assert - Multiple dispose calls should not throw
        client.Dispose();
        client.Dispose(); // Second call should be safe
        client.Dispose(); // Third call should be safe
    }

    [Fact]
    public async Task BaseClient_CustomHttpClient_ActuallyUsedForApiCalls()
    {
        // Arrange - Create a custom message handler that tracks requests
        bool requestIntercepted = false;
        HttpRequestMessage? capturedRequest = null;
        string customHeaderValue = "test-custom-client-123";

        var mockHandler = new MockHttpMessageHandler((request) =>
        {
            requestIntercepted = true;
            capturedRequest = request;

            // Return a mock JWKS response
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    ""keys"": [{
                        ""kty"": ""RSA"",
                        ""use"": ""sig"",
                        ""kid"": ""test-key-id"",
                        ""n"": ""test-modulus"",
                        ""e"": ""AQAB""
                    }]
                }", Encoding.UTF8, "application/json")
            };

            return Task.FromResult(mockResponse);
        });

        var customHttpClient = new HttpClient(mockHandler);
        _disposables.Add(customHttpClient);

        // Add a custom header to verify this specific client is used
        customHttpClient.DefaultRequestHeaders.Add("X-Test-Custom-Client", customHeaderValue);

        var config = new ClientConfig
        {
            ProjectId = _testConfig.ProjectId,
            ProjectSecret = _testConfig.ProjectSecret,
            HttpClient = customHttpClient
        };

        var client = new Stytch.net.Clients.ConsumerClient(config);
        _disposables.Add(client);

        // Act - Make a real API call
        var jwksRequest = new SessionsGetJWKSRequest(_testConfig.ProjectId);
        var response = await client.Sessions.GetJWKS(jwksRequest);

        // Assert - Verify the request was intercepted and our custom client was used
        Assert.True(requestIntercepted, "The HTTP request should have been intercepted by our custom handler");
        Assert.NotNull(capturedRequest);
        Assert.NotNull(response);

        // Verify the request has our custom header
        Assert.True(capturedRequest.Headers.Contains("X-Test-Custom-Client"));
        var headerValues = capturedRequest.Headers.GetValues("X-Test-Custom-Client");
        Assert.Contains(customHeaderValue, headerValues);

        // Verify the request has the SDK headers that should have been added
        Assert.True(capturedRequest.Headers.Contains("User-Agent"));
        Assert.NotNull(capturedRequest.Headers.Authorization);
        Assert.Equal("Basic", capturedRequest.Headers.Authorization.Scheme);

        // Verify the request URL is correct
        Assert.Contains($"/v1/sessions/jwks/{_testConfig.ProjectId}", capturedRequest.RequestUri!.ToString());

        // Verify HTTP method
        Assert.Equal(HttpMethod.Get, capturedRequest.Method);
    }

    // Helper class to create a mock HttpMessageHandler for testing
    private class MockHttpMessageHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, Task<HttpResponseMessage>> _handler;

        public MockHttpMessageHandler(Func<HttpRequestMessage, Task<HttpResponseMessage>> handler)
        {
            _handler = handler;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return _handler(request);
        }
    }
}
