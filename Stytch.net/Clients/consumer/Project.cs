// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!

using Newtonsoft.Json;
using Stytch.net.Models.Consumer;
using System.Text;




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
            ProjectMetricsRequest request)
        {
            var method = HttpMethod.Get;
            var uriBuilder = new UriBuilder($"/v1/projects/metrics");
            var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
            uriBuilder.Query = query.ToString();

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ProjectMetricsResponse>(responseBody)!;
            }
            else
            {
                // Optionally, throw an exception or return null or an error object
                throw new HttpRequestException(
                    $"Request failed with status code {response.StatusCode}: {responseBody}");
            }
        }

    }

}

