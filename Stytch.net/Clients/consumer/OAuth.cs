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
    public class OAuth
    {
        private readonly ClientConfig _config;
        private readonly HttpClient _httpClient;
        public OAuth(HttpClient client, ClientConfig config)
        {
            _httpClient = client;
            _config = config;
        }

        /// <summary>
        /// Generate an OAuth Attach Token to pre-associate an OAuth flow with an existing Stytch User. Pass the
        /// returned `oauth_attach_token` to the same provider's OAuth Start endpoint to treat this OAuth flow as a
        /// login for that user instead of a signup for a new user.
        /// 
        /// Exactly one of `user_id`, `session_token`, or `session_jwt` must be provided to identify the target
        /// Stytch User.
        /// 
        /// This is an optional step in the OAuth flow. Stytch can often determine whether to create a new user or
        /// log in an existing one based on verified identity provider information. This endpoint is useful for
        /// cases where we can't, such as missing or unverified provider information.
        /// </summary>
        public async Task<OAuthAttachResponse> Attach(
            OAuthAttachRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/oauth/attach"
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
                return JsonConvert.DeserializeObject<OAuthAttachResponse>(responseBody);
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
        /// Authenticate a User given a `token`. This endpoint verifies that the user completed the OAuth flow by
        /// verifying that the token is valid and hasn't expired. To initiate a Stytch session for the user while
        /// authenticating their OAuth token, include `session_duration_minutes`; a session with the identity
        /// provider, e.g. Google or Facebook, will always be initiated upon successful authentication.
        /// </summary>
        public async Task<OAuthAuthenticateResponse> Authenticate(
            OAuthAuthenticateRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/oauth/authenticate"
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
                return JsonConvert.DeserializeObject<OAuthAuthenticateResponse>(responseBody);
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

