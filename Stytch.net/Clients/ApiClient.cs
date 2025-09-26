using System;
using System.Linq;
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
        public HttpClient HttpClient { get; set; }
        public HttpClient FraudHttpClient { get; set; }
        internal string JwksUri { get; set; }
    }

    public class BaseClient : IDisposable
    {
        protected readonly HttpClient _httpClient;
        protected readonly HttpClient _fraudClient;
        protected readonly ClientConfig _config;
        protected static readonly string SdkVersion = GetSdkVersion();
        private readonly bool _shouldDisposeHttpClient;
        private readonly bool _shouldDisposeFraudClient;
        private bool _disposed = false;

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

            // Use provided HttpClient or create new one
            if (config.HttpClient != null)
            {
                _httpClient = config.HttpClient;
                _shouldDisposeHttpClient = false;

                // Only set BaseAddress if not already set
                if (_httpClient.BaseAddress == null)
                {
                    _httpClient.BaseAddress = new Uri(config.Environment);
                }
            }
            else
            {
                _httpClient = new HttpClient { BaseAddress = new Uri(config.Environment) };
                _shouldDisposeHttpClient = true;
            }

            // Use provided FraudHttpClient or create new one
            if (config.FraudHttpClient != null)
            {
                _fraudClient = config.FraudHttpClient;
                _shouldDisposeFraudClient = false;

                // Only set BaseAddress if not already set
                if (_fraudClient.BaseAddress == null)
                {
                    _fraudClient.BaseAddress = new Uri(config.FraudBaseUrl);
                }
            }
            else
            {
                _fraudClient = new HttpClient { BaseAddress = new Uri(config.FraudBaseUrl) };
                _shouldDisposeFraudClient = true;
            }

            var authValue = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{config.ProjectId}:{config.ProjectSecret}"));

            // Only set authorization header if not already set (to avoid overriding custom configuration)
            if (_httpClient.DefaultRequestHeaders.Authorization == null)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authValue);
            }

            if (_fraudClient.DefaultRequestHeaders.Authorization == null)
            {
                _fraudClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authValue);
            }

            // Only set User-Agent header if not already set
            if (!_httpClient.DefaultRequestHeaders.UserAgent.Any())
            {
                _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd($"stytch-dotnet/{SdkVersion}");
            }

            if (!_fraudClient.DefaultRequestHeaders.UserAgent.Any())
            {
                _fraudClient.DefaultRequestHeaders.UserAgent.ParseAdd($"stytch-dotnet/{SdkVersion}");
            }
        }

        private static string GetSdkVersion()
        {
            // Retrieve the SDK version from the assembly
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            return version?.ToString() ?? "1.0.0";
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources only if we created them
                    if (_shouldDisposeHttpClient)
                    {
                        _httpClient?.Dispose();
                    }

                    if (_shouldDisposeFraudClient)
                    {
                        _fraudClient?.Dispose();
                    }
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
