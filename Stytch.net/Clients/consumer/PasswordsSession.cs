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
    public class PasswordsSessions
    {
        private readonly HttpClient _httpClient;
        public PasswordsSessions(HttpClient client)
        {
            _httpClient = client;
        }

        /// <summary>
        /// Reset the user’s password using their existing session. The endpoint will error if the session does not
        /// have a password, email magic link, or email OTP authentication factor that has been issued within the
        /// last 5 minutes. This endpoint requires either a `session_jwt` or `session_token` be included in the
        /// request.
        /// 
        /// Note that a successful password reset via an existing session will revoke all active sessions for the
        /// `user_id`, except for the one used during the reset flow.
        /// </summary>
        public async Task<PasswordsSessionResetResponse> Reset(
            PasswordsSessionResetRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/passwords/session/reset"
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
                return JsonConvert.DeserializeObject<PasswordsSessionResetResponse>(responseBody);
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

