// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!

using Newtonsoft.Json;
using Stytch.net.Exceptions;
using Stytch.net.Models.Consumer;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;




namespace Stytch.net.Clients.Consumer
{
    public class M2MClientsSecrets
    {
        private readonly ClientConfig _config;
        private readonly HttpClient _httpClient;
        public M2MClientsSecrets(HttpClient client, ClientConfig config)
        {
            _httpClient = client;
            _config = config;
        }

        /// <summary>
        /// Initiate the rotation of an M2M client secret. After this endpoint is called, both the client's
        /// `client_secret` and `next_client_secret` will be valid. To complete the secret rotation flow, update all
        /// usages of `client_secret` to `next_client_secret` and call the
        /// [Rotate Secret Endpoint](https://stytch.com/docs/b2b/api/m2m-rotate-secret)[Rotate Secret Endpoint](https://stytch.com/docs/api/m2m-rotate-secret) to complete the flow.
        /// Secret rotation can be cancelled using the
        /// [Rotate Cancel Endpoint](https://stytch.com/docs/b2b/api/m2m-rotate-secret-cancel)[Rotate Cancel Endpoint](https://stytch.com/docs/api/m2m-rotate-secret-cancel).
        /// 
        /// **Important:** This is the only time you will be able to view the generated `next_client_secret` in the
        /// API response. Stytch stores a hash of the `next_client_secret` and cannot recover the value if lost. Be
        /// sure to persist the `next_client_secret` in a secure location. If the `next_client_secret` is lost, you
        /// will need to trigger a secret rotation flow to receive another one.
        /// </summary>
        public async Task<M2MClientsSecretsRotateStartResponse> RotateStart(
            M2MClientsSecretsRotateStartRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/m2m/clients/{request.ClientId}/secrets/rotate/start"
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
                return JsonConvert.DeserializeObject<M2MClientsSecretsRotateStartResponse>(responseBody);
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
        /// Cancel the rotation of an M2M client secret started with the
        /// [Start Secret Rotation Endpoint](https://stytch.com/docs/b2b/api/m2m-rotate-secret-start)
        /// [Start Secret Rotation Endpoint](https://stytch.com/docs/api/m2m-rotate-secret-start).
        /// After this endpoint is called, the client's `next_client_secret` is discarded and only the original
        /// `client_secret` will be valid.
        /// </summary>
        public async Task<M2MClientsSecretsRotateCancelResponse> RotateCancel(
            M2MClientsSecretsRotateCancelRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/m2m/clients/{request.ClientId}/secrets/rotate/cancel"
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
                return JsonConvert.DeserializeObject<M2MClientsSecretsRotateCancelResponse>(responseBody);
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
        /// Complete the rotation of an M2M client secret started with the
        /// [Start Secret Rotation Endpoint](https://stytch.com/docs/b2b/api/m2m-rotate-secret-start)
        /// [Start Secret Rotation Endpoint](https://stytch.com/docs/api/m2m-rotate-secret-start).
        /// After this endpoint is called, the client's `next_client_secret` becomes its `client_secret` and the
        /// previous `client_secret` will no longer be valid.
        /// </summary>
        public async Task<M2MClientsSecretsRotateResponse> Rotate(
            M2MClientsSecretsRotateRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/m2m/clients/{request.ClientId}/secrets/rotate"
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
                return JsonConvert.DeserializeObject<M2MClientsSecretsRotateResponse>(responseBody);
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

