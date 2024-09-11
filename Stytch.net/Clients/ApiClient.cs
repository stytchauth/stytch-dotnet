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
        public required string ProjectId { get; set; }
        public required string ProjectSecret { get; set; }
        public string? Environment { get; set; } // Optional property
        public int Timeout { get; set; } = 10 * 60 * 1000; // Default timeout (10 minutes)
    }
    
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private static readonly string SdkVersion = GetSdkVersion();

        public ApiClient(ClientConfig config)
        {
            
            if (string.IsNullOrEmpty(config.Environment))
            {
                if (config.ProjectId.StartsWith("project-live-"))
                {
                    config.Environment = "https://api.stytch.com";
                }
                else
                {
                    config.Environment = "https://test.stytch.com";
                }
            }
            
            _httpClient = new HttpClient { BaseAddress = new Uri(config.Environment) };

            var authValue = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{config.ProjectId}:{config.ProjectSecret}"));

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authValue);

            // Set User-Agent header
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd($"stytch-dotnet/{SdkVersion}");
        }

        private static string GetSdkVersion()
        {
            // Retrieve the SDK version from the assembly
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            return version?.ToString() ?? "1.0.0";
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
