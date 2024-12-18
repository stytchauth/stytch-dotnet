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




namespace Stytch.net.Clients.B2B
{
    public class MagicLinks
    {
        private readonly ClientConfig _config;
        private readonly HttpClient _httpClient;
        public readonly MagicLinksEmail Email;
        public readonly MagicLinksDiscovery Discovery;
        public MagicLinks(HttpClient client, ClientConfig config)
        {
            _httpClient = client;
            _config = config;
            Email = new MagicLinksEmail(_httpClient, _config);
            Discovery = new MagicLinksDiscovery(_httpClient, _config);
        }

        /// <summary>
        /// Authenticate a Member with a Magic Link. This endpoint requires a Magic Link token that is not expired
        /// or previously used. If the Member’s status is `pending` or `invited`, they will be updated to `active`.
        /// Provide the `session_duration_minutes` parameter to set the lifetime of the session. If the
        /// `session_duration_minutes` parameter is not specified, a Stytch session will be created with a 60 minute
        /// duration.
        /// 
        /// If the Member is required to complete MFA to log in to the Organization, the returned value of
        /// `member_authenticated` will be `false`, and an `intermediate_session_token` will be returned.
        /// The `intermediate_session_token` can be passed into the
        /// [OTP SMS Authenticate endpoint](https://stytch.com/docs/b2b/api/authenticate-otp-sms),
        /// [TOTP Authenticate endpoint](https://stytch.com/docs/b2b/api/authenticate-totp), 
        /// or [Recovery Codes Recover endpoint](https://stytch.com/docs/b2b/api/recovery-codes-recover) to complete
        /// the MFA step and acquire a full member session.
        /// The `intermediate_session_token` can also be used with the
        /// [Exchange Intermediate Session endpoint](https://stytch.com/docs/b2b/api/exchange-intermediate-session)
        /// or the
        /// [Create Organization via Discovery endpoint](https://stytch.com/docs/b2b/api/create-organization-via-discovery) to join a different Organization or create a new one.
        /// The `session_duration_minutes` and `session_custom_claims` parameters will be ignored.
        /// 
        /// If a valid `session_token` or `session_jwt` is passed in, the Member will not be required to complete an
        /// MFA step.
        /// </summary>
        public async Task<B2BMagicLinksAuthenticateResponse> Authenticate(
            B2BMagicLinksAuthenticateRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/magic_links/authenticate"
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
                return JsonConvert.DeserializeObject<B2BMagicLinksAuthenticateResponse>(responseBody);
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

