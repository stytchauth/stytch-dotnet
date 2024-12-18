// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Stytch.net.Exceptions;
using Stytch.net.Models.Consumer;




namespace Stytch.net.Clients.Consumer
{
    public class M2MClients
    {
        private readonly ClientConfig _config;
        private readonly HttpClient _httpClient;
        public readonly M2MClientsSecrets Secrets;
        public M2MClients(HttpClient client, ClientConfig config)
        {
            _httpClient = client;
            _config = config;
            Secrets = new M2MClientsSecrets(_httpClient, _config);
        }

        /// <summary>
        /// Gets information about an existing M2M Client.
        /// </summary>
        public async Task<M2MClientsGetResponse> Get(
            M2MClientsGetRequest request
        )
        {
            var method = HttpMethod.Get;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/m2m/clients/{request.ClientId}"
            };

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<M2MClientsGetResponse>(responseBody);
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
        /// <summary>
        /// Search for M2M Clients within your Stytch Project. Submit an empty `query` in the request to return all
        /// M2M Clients.
        /// 
        /// The following search filters are supported today:
        /// - `client_id`: Pass in a list of client IDs to get many clients in a single request
        /// - `client_name`: Search for clients by exact match on client name
        /// - `scopes`: Search for clients assigned a specific scope
        /// </summary>
        public async Task<M2MClientsSearchResponse> Search(
            M2MClientsSearchRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/m2m/clients/search"
            };

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());
            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            var jsonBody = JsonConvert.SerializeObject(request, jsonSettings);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            httpReq.Content = content;

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<M2MClientsSearchResponse>(responseBody);
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
        /// <summary>
        /// Updates an existing M2M Client. You can use this endpoint to activate or deactivate a M2M Client by
        /// changing its `status`. A deactivated M2M Client will not be allowed to perform future token exchange
        /// flows until it is reactivated.
        /// 
        /// **Important:** Deactivating a M2M Client will not invalidate any existing JWTs issued to the client,
        /// only prevent it from receiving new ones.
        /// To protect more-sensitive routes, pass a lower `max_token_age` value
        /// when[authenticating the token](https://stytch.com/docs/b2b/api/authenticate-m2m-token)[authenticating the token](https://stytch.com/docs/api/authenticate-m2m-token).
        /// </summary>
        public async Task<M2MClientsUpdateResponse> Update(
            M2MClientsUpdateRequest request
        )
        {
            var method = HttpMethod.Put;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/m2m/clients/{request.ClientId}"
            };

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());
            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            var jsonBody = JsonConvert.SerializeObject(request, jsonSettings);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            httpReq.Content = content;

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<M2MClientsUpdateResponse>(responseBody);
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
        /// <summary>
        /// Deletes the M2M Client.
        /// 
        /// **Important:** Deleting a M2M Client will not invalidate any existing JWTs issued to the client, only
        /// prevent it from receiving new ones.
        /// To protect more-sensitive routes, pass a lower `max_token_age` value
        /// when[authenticating the token](https://stytch.com/docs/b2b/api/authenticate-m2m-token)[authenticating the token](https://stytch.com/docs/api/authenticate-m2m-token).
        /// </summary>
        public async Task<M2MClientsDeleteResponse> Delete(
            M2MClientsDeleteRequest request
        )
        {
            var method = HttpMethod.Delete;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/m2m/clients/{request.ClientId}"
            };

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());
            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            var jsonBody = JsonConvert.SerializeObject(request, jsonSettings);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            httpReq.Content = content;

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<M2MClientsDeleteResponse>(responseBody);
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
        /// <summary>
        /// Creates a new M2M Client. On initial client creation, you may pass in a custom `client_id` or
        /// `client_secret` to import an existing M2M client. If you do not pass in a custom `client_id` or
        /// `client_secret`, one will be generated automatically. The `client_id` must be unique among all clients
        /// in your project.
        /// 
        /// **Important:** This is the only time you will be able to view the generated `client_secret` in the API
        /// response. Stytch stores a hash of the `client_secret` and cannot recover the value if lost. Be sure to
        /// persist the `client_secret` in a secure location. If the `client_secret` is lost, you will need to
        /// trigger a secret rotation flow to receive another one.
        /// </summary>
        public async Task<M2MClientsCreateResponse> Create(
            M2MClientsCreateRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/m2m/clients"
            };

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());
            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            var jsonBody = JsonConvert.SerializeObject(request, jsonSettings);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            httpReq.Content = content;

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<M2MClientsCreateResponse>(responseBody);
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

