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
    public class WebAuthn
    {
        private readonly HttpClient _httpClient;
        public WebAuthn(HttpClient client)
        {
            _httpClient = client;
        }

        /// <summary>
        /// Initiate the process of creating a new Passkey or WebAuthn registration. 
        /// 
        /// To optimize for Passkeys, set the `return_passkey_credential_options` field to `true`.
        /// 
        /// After calling this endpoint, the browser will need to call
        /// [navigator.credentials.create()](https://www.w3.org/TR/webauthn-2/#sctn-createCredential) with the data
        /// from
        /// [public_key_credential_creation_options](https://w3c.github.io/webauthn/#dictionary-makecredentialoptions)
        /// passed to the [navigator.credentials.create()](https://www.w3.org/TR/webauthn-2/#sctn-createCredential)
        /// request via the public key argument. We recommend using the `create()` wrapper provided by the
        /// webauthn-json library. 
        /// 
        /// If you are not using the [webauthn-json](https://github.com/github/webauthn-json) library, the
        /// `public_key_credential_creation_options` will need to be converted to a suitable public key by
        /// unmarshalling the JSON, base64 decoding the user ID field, and converting user ID and the challenge
        /// fields into an array buffer.
        /// </summary>
        public async Task<WebAuthnRegisterStartResponse> RegisterStart(
            WebAuthnRegisterStartRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/webauthn/register/start"
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
                return JsonConvert.DeserializeObject<WebAuthnRegisterStartResponse>(responseBody);
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
        /// Complete the creation of a WebAuthn registration by passing the response from the
        /// [navigator.credentials.create()](https://www.w3.org/TR/webauthn-2/#sctn-createCredential) request to
        /// this endpoint as the `public_key_credential` parameter. 
        /// 
        /// If the [webauthn-json](https://github.com/github/webauthn-json) library's `create()` method was used,
        /// the response can be passed directly to the
        /// [register endpoint](https://stytch.com/docs/api/webauthn-register). If not, some fields (the client data
        /// and the attestation object) from the
        /// [navigator.credentials.create()](https://www.w3.org/TR/webauthn-2/#sctn-createCredential) response will
        /// need to be converted from array buffers to strings and marshalled into JSON.
        /// </summary>
        public async Task<WebAuthnRegisterResponse> Register(
            WebAuthnRegisterRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/webauthn/register"
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
                return JsonConvert.DeserializeObject<WebAuthnRegisterResponse>(responseBody);
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
        /// Initiate the authentication of a Passkey or WebAuthn registration. 
        /// 
        /// To optimize for Passkeys, set the `return_passkey_credential_options` field to `true`.
        /// 
        /// After calling this endpoint, the browser will need to call
        /// [navigator.credentials.get()](https://www.w3.org/TR/webauthn-2/#sctn-getAssertion) with the data from
        /// `public_key_credential_request_options` passed to the
        /// [navigator.credentials.get()](https://www.w3.org/TR/webauthn-2/#sctn-getAssertion) request via the
        /// public key argument. We recommend using the `get()` wrapper provided by the webauthn-json library. 
        /// 
        /// If you are not using the [webauthn-json](https://github.com/github/webauthn-json) library, `the
        /// public_key_credential_request_options` will need to be converted to a suitable public key by
        /// unmarshalling the JSON and converting some the fields to array buffers.
        /// </summary>
        public async Task<WebAuthnAuthenticateStartResponse> AuthenticateStart(
            WebAuthnAuthenticateStartRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/webauthn/authenticate/start"
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
                return JsonConvert.DeserializeObject<WebAuthnAuthenticateStartResponse>(responseBody);
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
        /// Complete the authentication of a Passkey or WebAuthn registration by passing the response from the
        /// [navigator.credentials.get()](https://www.w3.org/TR/webauthn-2/#sctn-getAssertion) request to the
        /// authenticate endpoint. 
        /// 
        /// If the [webauthn-json](https://github.com/github/webauthn-json) library's `get()` method was used, the
        /// response can be passed directly to the
        /// [authenticate endpoint](https://stytch.com/docs/api/webauthn-authenticate). If not some fields from the
        /// [navigator.credentials.get()](https://www.w3.org/TR/webauthn-2/#sctn-getAssertion) response will need to
        /// be converted from array buffers to strings and marshalled into JSON.
        /// </summary>
        public async Task<WebAuthnAuthenticateResponse> Authenticate(
            WebAuthnAuthenticateRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/webauthn/authenticate"
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
                return JsonConvert.DeserializeObject<WebAuthnAuthenticateResponse>(responseBody);
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
        /// Updates a Passkey or WebAuthn registration.
        /// </summary>
        public async Task<WebAuthnUpdateResponse> Update(
            WebAuthnUpdateRequest request
        )
        {
            var method = HttpMethod.Put;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/webauthn/${request.WebAuthnRegistrationId}"
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
                return JsonConvert.DeserializeObject<WebAuthnUpdateResponse>(responseBody);
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

