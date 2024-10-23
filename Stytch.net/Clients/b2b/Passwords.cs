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




namespace Stytch.net.Clients.B2B
{
    public class Passwords
    {
        private readonly ClientConfig _config;
        private readonly HttpClient _httpClient;
        public readonly PasswordsEmail Email;
        public readonly PasswordsSessions Sessions;
        public readonly PasswordsExistingPassword ExistingPassword;
        public readonly PasswordsDiscovery Discovery;
        public Passwords(HttpClient client, ClientConfig config)
        {
            _httpClient = client;
            _config = config;
            Email = new PasswordsEmail(_httpClient, _config);
            Sessions = new PasswordsSessions(_httpClient, _config);
            ExistingPassword = new PasswordsExistingPassword(_httpClient, _config);
            Discovery = new PasswordsDiscovery(_httpClient, _config);
        }

        /// <summary>
        /// This API allows you to check whether the user’s provided password is valid, and to provide feedback to
        /// the user on how to increase the strength of their password.
        /// 
        /// This endpoint adapts to your Project's password strength configuration. If you're using
        /// [zxcvbn](https://stytch.com/docs/guides/passwords/strength-policy), the default, your passwords are
        /// considered valid if the strength score is >= 3. If you're using
        /// [LUDS](https://stytch.com/docs/guides/passwords/strength-policy), your passwords are considered valid if
        /// they meet the requirements that you've set with Stytch. You may update your password strength
        /// configuration in the [stytch dashboard](https://stytch.com/dashboard/password-strength-config).
        /// 
        /// ## Password feedback
        /// The zxcvbn_feedback and luds_feedback objects contains relevant fields for you to relay feedback to
        /// users that failed to create a strong enough password.
        /// 
        /// If you're using [zxcvbn](https://stytch.com/docs/guides/passwords/strength-policy), the feedback object
        /// will contain warning and suggestions for any password that does not meet the
        /// [zxcvbn](https://stytch.com/docs/guides/passwords/strength-policy) strength requirements. You can return
        /// these strings directly to the user to help them craft a strong password.
        /// 
        /// If you're using [LUDS](https://stytch.com/docs/guides/passwords/strength-policy), the feedback object
        /// will contain a collection of fields that the user failed or passed. You'll want to prompt the user to
        /// create a password that meets all requirements that they failed.
        /// </summary>
        public async Task<B2BPasswordsStrengthCheckResponse> StrengthCheck(
            B2BPasswordsStrengthCheckRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/passwords/strength_check"
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
                return JsonConvert.DeserializeObject<B2BPasswordsStrengthCheckResponse>(responseBody);
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
        /// Adds an existing password to a member's email that doesn't have a password yet. We support migrating
        /// members from passwords stored with bcrypt, scrypt, argon2, MD-5, SHA-1, and PBKDF2. This endpoint has a
        /// rate limit of 100 requests per second.
        /// 
        /// The member's email will be marked as verified when you use this endpoint.
        /// </summary>
        public async Task<B2BPasswordsMigrateResponse> Migrate(
            B2BPasswordsMigrateRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/passwords/migrate"
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
                return JsonConvert.DeserializeObject<B2BPasswordsMigrateResponse>(responseBody);
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
        /// Authenticate a member with their email address and password. This endpoint verifies that the member has
        /// a password currently set, and that the entered password is correct.
        /// 
        /// If you have breach detection during authentication enabled in your
        /// [password strength policy](https://stytch.com/docs/b2b/guides/passwords/strength-policies) and the
        /// member's credentials have appeared in the HaveIBeenPwned dataset, this endpoint will return a
        /// `member_reset_password` error even if the member enters a correct password. We force a password reset in
        /// this case to ensure that the member is the legitimate owner of the email address and not a malicious
        /// actor abusing the compromised credentials.
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
        /// </summary>
        public async Task<B2BPasswordsAuthenticateResponse> Authenticate(
            B2BPasswordsAuthenticateRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/passwords/authenticate"
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
                return JsonConvert.DeserializeObject<B2BPasswordsAuthenticateResponse>(responseBody);
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

