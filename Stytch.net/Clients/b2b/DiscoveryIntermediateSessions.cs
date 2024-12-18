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
    public class DiscoveryIntermediateSessions
    {
        private readonly ClientConfig _config;
        private readonly HttpClient _httpClient;
        public DiscoveryIntermediateSessions(HttpClient client, ClientConfig config)
        {
            _httpClient = client;
            _config = config;
        }

        /// <summary>
        /// Exchange an Intermediate Session for a fully realized
        /// [Member Session](https://stytch.com/docs/b2b/api/session-object) in a desired
        /// [Organization](https://stytch.com/docs/b2b/api/organization-object).
        /// This operation consumes the Intermediate Session.
        /// 
        /// This endpoint can be used to accept invites and create new members via domain matching.
        /// 
        /// If the Member is required to complete MFA to log in to the Organization, the returned value of
        /// `member_authenticated` will be `false`.
        /// The `intermediate_session_token` will not be consumed and instead will be returned in the response.
        /// The `intermediate_session_token` can be passed into the
        /// [OTP SMS Authenticate endpoint](https://stytch.com/docs/b2b/api/authenticate-otp-sms) to complete the
        /// MFA step and acquire a full member session.
        /// The `intermediate_session_token` can also be used with the
        /// [Exchange Intermediate Session endpoint](https://stytch.com/docs/b2b/api/exchange-intermediate-session)
        /// or the
        /// [Create Organization via Discovery endpoint](https://stytch.com/docs/b2b/api/create-organization-via-discovery) to join a different Organization or create a new one.
        /// The `session_duration_minutes` and `session_custom_claims` parameters will be ignored.
        /// </summary>
        public async Task<B2BDiscoveryIntermediateSessionsExchangeResponse> Exchange(
            B2BDiscoveryIntermediateSessionsExchangeRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/discovery/intermediate_sessions/exchange"
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
                return JsonConvert.DeserializeObject<B2BDiscoveryIntermediateSessionsExchangeResponse>(responseBody);
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

