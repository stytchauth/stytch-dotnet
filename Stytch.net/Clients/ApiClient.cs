using System;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Stytch.net.Models;

namespace Stytch.net.Clients
{
    public class ClientConfig
    {
        public string ProjectId { get; set; }
        public string ProjectSecret { get; set; }
        public string Environment { get; set; }
        public string CustomBaseUrl { get; set; }
        public string FraudBaseUrl { get; set; } = "https://telemetry.stytch.com";
        public int Timeout { get; set; } = 10 * 60 * 1000; // Default timeout (10 minutes)
        internal string JwksUri { get; set; }
    }

    public class BaseClient
    {
        protected readonly HttpClient _httpClient;
        protected readonly HttpClient _fraudClient;
        protected readonly ClientConfig _config;
        protected static readonly string SdkVersion = GetSdkVersion();

        public BaseClient(ClientConfig config)
        {
            _config = config;

            // If CustomBaseUrl is provided, it will take precedence over Environment.
            // Otherwise, the URL is determined based on the Environment or ProjectId.
            if (!string.IsNullOrEmpty(config.CustomBaseUrl))
            {
                config.Environment = config.CustomBaseUrl;
            }

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
            _fraudClient = new HttpClient { BaseAddress = new Uri(config.FraudBaseUrl) };

            var authValue = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{config.ProjectId}:{config.ProjectSecret}"));

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authValue);
            _fraudClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authValue);

            // Set User-Agent header
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd($"stytch-dotnet/{SdkVersion}");
            _fraudClient.DefaultRequestHeaders.UserAgent.ParseAdd($"stytch-dotnet/{SdkVersion}");
        }

        private static string GetSdkVersion()
        {
            // Retrieve the SDK version from the assembly
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            return version?.ToString() ?? "1.0.0";
        }
    }
}
