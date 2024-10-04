// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!

using Newtonsoft.Json;
using Stytch.net.Exceptions;
using Stytch.net.Models.Consumer;
using System.Text;




namespace Stytch.net.Clients.Consumer
{
    public class TOTPs
    {
        private readonly HttpClient _httpClient;
        public TOTPs(HttpClient client)
        {
            _httpClient = client;
        }

        /// <summary>
        /// Create a new TOTP instance for a user. The user can use the authenticator application of their choice to
        /// scan the QR code or enter the secret.
        /// </summary>
        public async Task<TOTPsCreateResponse> Create(
            TOTPsCreateRequest request)
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress!)
            {
                Path = $"/v1/totps"
            };

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());
            var jsonBody = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            httpReq.Content = content;

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TOTPsCreateResponse>(responseBody)!;
            }
            try
            {
                var apiException = JsonConvert.DeserializeObject<StytchApiException>(responseBody)!;
                throw apiException;
            }
            catch (JsonException)
            {
                throw new StytchNetworkException($"Unexpected error occurred: {responseBody}", response);
            }
        }
        /// <summary>
        /// Authenticate a TOTP code entered by a user.
        /// </summary>
        public async Task<TOTPsAuthenticateResponse> Authenticate(
            TOTPsAuthenticateRequest request)
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress!)
            {
                Path = $"/v1/totps/authenticate"
            };

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());
            var jsonBody = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            httpReq.Content = content;

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TOTPsAuthenticateResponse>(responseBody)!;
            }
            try
            {
                var apiException = JsonConvert.DeserializeObject<StytchApiException>(responseBody)!;
                throw apiException;
            }
            catch (JsonException)
            {
                throw new StytchNetworkException($"Unexpected error occurred: {responseBody}", response);
            }
        }
        /// <summary>
        /// Retrieve the recovery codes for a TOTP instance tied to a User.
        /// </summary>
        public async Task<TOTPsRecoveryCodesResponse> RecoveryCodes(
            TOTPsRecoveryCodesRequest request)
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress!)
            {
                Path = $"/v1/totps/recovery_codes"
            };

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());
            var jsonBody = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            httpReq.Content = content;

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TOTPsRecoveryCodesResponse>(responseBody)!;
            }
            try
            {
                var apiException = JsonConvert.DeserializeObject<StytchApiException>(responseBody)!;
                throw apiException;
            }
            catch (JsonException)
            {
                throw new StytchNetworkException($"Unexpected error occurred: {responseBody}", response);
            }
        }
        /// <summary>
        /// Authenticate a recovery code for a TOTP instance.
        /// </summary>
        public async Task<TOTPsRecoverResponse> Recover(
            TOTPsRecoverRequest request)
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress!)
            {
                Path = $"/v1/totps/recover"
            };

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());
            var jsonBody = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            httpReq.Content = content;

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TOTPsRecoverResponse>(responseBody)!;
            }
            try
            {
                var apiException = JsonConvert.DeserializeObject<StytchApiException>(responseBody)!;
                throw apiException;
            }
            catch (JsonException)
            {
                throw new StytchNetworkException($"Unexpected error occurred: {responseBody}", response);
            }
        }

    }

}

