// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!

using Newtonsoft.Json;
using Stytch.net.Exceptions;
using Stytch.net.Models.Consumer;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;




namespace Stytch.net.Clients.Consumer
{
    public class Project
    {
        private readonly HttpClient _httpClient;
        public Project(HttpClient client)
        {
            _httpClient = client;
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<ProjectMetricsResponse> Metrics(
            ProjectMetricsRequest request
        )
        {
            var method = HttpMethod.Get;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/projects/metrics"
            };
            var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
            uriBuilder.Query = query.ToString();

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ProjectMetricsResponse>(responseBody);
            }
            try
            {
                var apiException = JsonConvert.DeserializeObject<StytchApiException>(responseBody);
                throw apiException;
            }
            catch (JsonException)
            {
                throw new StytchNetworkException($"Unexpected error occurred: {responseBody}", response);
            }
        }

    }

}

