using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;
using Stytch.net.Models;

namespace Stytch.net.Clients
{
    public class ClientConfig
    {
        public string ProjectId { get; set; }
        public string Secret { get; set; }
        public string? Environment { get; set; } // Optional property
        public int Timeout { get; set; } = 10 * 60 * 1000; // Default timeout (10 minutes)
        public HttpClientHandler? HttpClientHandler { get; set; }
    }

    // private void SetEnvironment()
    // {
    //     const string liveEnv = "live";
    //     const string testEnv = "test";

    //     if (string.IsNullOrEmpty(Environment))
    //     {
    //         if (ProjectId.StartsWith("project-live-", StringComparison.OrdinalIgnoreCase))
    //         {
    //             Environment = liveEnv;
    //         }
    //         else
    //         {
    //             Environment = testEnv;
    //         }
    //     }
    // }

    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private static readonly string sdkVersion = GetSdkVersion();

        public ApiClient(ClientConfig config)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(config.Environment) };

            var authValue = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{config.ProjectId}:{config.Secret}"));

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authValue);

            // Set User-Agent header
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd($"Stytch-dotnet/{sdkVersion}");
        }

        private static string GetSdkVersion()
        {
            // Retrieve the SDK version from the assembly
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            return version?.ToString() ?? "1.0.0";
        }
        public async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task<T> PostAsync<T>(string endpoint, object body)
        {
            var jsonBody = JsonConvert.SerializeObject(body);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(endpoint, content);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task<MagicLinkResponse> SendMagicLinkAsync(MagicLinkRequest request)
        {
            // Serialize the request model to JSON
            var jsonBody = JsonConvert.SerializeObject(request);

            // Create the content with the right content type
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            // Send the POST request to the specified URL
            var response = await _httpClient.PostAsync("/v1/magic_links/email/send", content);

    // Read the response body (even if the response is not successful)
    var responseBody = await response.Content.ReadAsStringAsync();

  if (response.IsSuccessStatusCode)
    {
        // If the response is successful, deserialize and return the response
        var magicLinkResponse = JsonConvert.DeserializeObject<MagicLinkResponse>(responseBody);
        return magicLinkResponse;
    }
    else
    {
        // If the response is not successful, log the error details
        Console.WriteLine($"Error: {response.StatusCode}, Response Body: {responseBody}");

        // Optionally, throw an exception or return null or an error object
        throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {responseBody}");
    }

}

    }
}
