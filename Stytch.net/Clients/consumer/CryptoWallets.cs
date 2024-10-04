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
    public class CryptoWallets
    {
        private readonly HttpClient _httpClient;
        public CryptoWallets(HttpClient client)
        {
            _httpClient = client;
        }

        /// <summary>
        /// Initiate the authentication of a crypto wallet. After calling this endpoint, the user will need to sign
        /// a message containing the returned `challenge` field.
        /// 
        /// For Ethereum crypto wallets, you can optionally use the Sign In With Ethereum (SIWE) protocol for the
        /// message by passing in the `siwe_params`. The only required fields are `domain` and `uri`.
        /// If the crypto wallet detects that the domain in the message does not match the website's domain, it will
        /// display a warning to the user.
        /// 
        /// If not using the SIWE protocol, the message will simply consist of the project name and a random string.
        /// </summary>
        public async Task<CryptoWalletsAuthenticateStartResponse> AuthenticateStart(
            CryptoWalletsAuthenticateStartRequest request)
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress!)
            {
                Path = $"/v1/crypto_wallets/authenticate/start"
            };

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());
            var jsonBody = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            httpReq.Content = content;

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<CryptoWalletsAuthenticateStartResponse>(responseBody)!;
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
        /// Complete the authentication of a crypto wallet by passing the signature.
        /// </summary>
        public async Task<CryptoWalletsAuthenticateResponse> Authenticate(
            CryptoWalletsAuthenticateRequest request)
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress!)
            {
                Path = $"/v1/crypto_wallets/authenticate"
            };

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());
            var jsonBody = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            httpReq.Content = content;

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<CryptoWalletsAuthenticateResponse>(responseBody)!;
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

