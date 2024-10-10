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
        public string ProjectSecret { get; set; }
        public string Environment { get; set; }
        public int Timeout { get; set; } = 10 * 60 * 1000; // Default timeout (10 minutes)
    }

    public class BaseClient
    {
        protected readonly HttpClient _httpClient;
        protected static readonly string SdkVersion = GetSdkVersion();

        public BaseClient(ClientConfig config)
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
    }
}
