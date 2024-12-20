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
    public class PasswordsEmail
    {
        private readonly ClientConfig _config;
        private readonly HttpClient _httpClient;
        public PasswordsEmail(HttpClient client, ClientConfig config)
        {
            _httpClient = client;
            _config = config;
        }

        /// <summary>
        /// Initiates a password reset for the email address provided. This will trigger an email to be sent to the
        /// address, containing a magic link that will allow them to set a new password and authenticate.
        /// 
        /// This endpoint adapts to your Project's password strength configuration.
        /// If you're using [zxcvbn](https://stytch.com/docs/guides/passwords/strength-policy), the default, your
        /// passwords are considered valid
        /// if the strength score is >= 3. If you're using
        /// [LUDS](https://stytch.com/docs/guides/passwords/strength-policy), your passwords are
        /// considered valid if they meet the requirements that you've set with Stytch.
        /// You may update your password strength configuration in the
        /// [stytch dashboard](https://stytch.com/dashboard/password-strength-config).
        /// </summary>
        public async Task<B2BPasswordsEmailResetStartResponse> ResetStart(
            B2BPasswordsEmailResetStartRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/passwords/email/reset/start"
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
                return JsonConvert.DeserializeObject<B2BPasswordsEmailResetStartResponse>(responseBody);
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
        /// Reset the member's password and authenticate them. This endpoint checks that the password reset token is
        /// valid, hasn’t expired, or already been used.
        /// 
        /// The provided password needs to meet our password strength requirements, which can be checked in advance
        /// with the password strength endpoint. If the token and password are accepted, the password is securely
        /// stored for future authentication and the user is authenticated.
        /// 
        /// If the Member is required to complete MFA to log in to the Organization, the returned value of
        /// `member_authenticated` will be `false`, and an `intermediate_session_token` will be returned.
        /// The `intermediate_session_token` can be passed into the
        /// [OTP SMS Authenticate endpoint](https://stytch.com/docs/b2b/api/authenticate-otp-sms) to complete the
        /// MFA step and acquire a full member session.
        /// The `session_duration_minutes` and `session_custom_claims` parameters will be ignored.
        /// 
        /// If a valid `session_token` or `session_jwt` is passed in, the Member will not be required to complete an
        /// MFA step.
        /// 
        /// Note that a successful password reset by email will revoke all active sessions for the `member_id`.
        /// </summary>
        public async Task<B2BPasswordsEmailResetResponse> Reset(
            B2BPasswordsEmailResetRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/passwords/email/reset"
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
                return JsonConvert.DeserializeObject<B2BPasswordsEmailResetResponse>(responseBody);
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
        /// 
        /// </summary>
        public async Task<B2BPasswordsEmailRequireResetResponse> RequireReset(
            B2BPasswordsEmailRequireResetRequest request
            , B2BPasswordsEmailRequireResetRequestOptions options
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/passwords/email/require_reset"
            };

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());
            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            var jsonBody = JsonConvert.SerializeObject(request, jsonSettings);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            httpReq.Content = content;
            if (!string.IsNullOrEmpty(options.Authorization.SessionToken))
            {
                httpReq.Headers.Add("X-Stytch-Member-Session", options.Authorization.SessionToken);
            }
            if (!string.IsNullOrEmpty(options.Authorization.SessionJwt))
            {
                httpReq.Headers.Add("X-Stytch-Member-SessionJWT", options.Authorization.SessionJwt);
            }

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<B2BPasswordsEmailRequireResetResponse>(responseBody);
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

