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
    public class OTPsEmail
    {
        private readonly HttpClient _httpClient;
        public OTPsEmail(HttpClient client)
        {
            _httpClient = client;
        }

        /// <summary>
        /// Send a One-Time Passcode (OTP) to a User using their email. If you'd like to create a user and send them
        /// a passcode with one request, use our
        /// [log in or create endpoint](https://stytch.com/docs/api/log-in-or-create-user-by-email-otp).
        /// 
        /// ### Add an email to an existing user
        /// This endpoint also allows you to add a new email address to an existing Stytch User. Including a
        /// `user_id`, `session_token`, or `session_jwt` in your Send one-time passcode by email request will add
        /// the new, unverified email address to the existing Stytch User. If the user successfully authenticates
        /// within 5 minutes, the new email address will be marked as verified and remain permanently on the
        /// existing Stytch User. Otherwise, it will be removed from the User object, and any subsequent login
        /// requests using that email address will create a new User.
        /// 
        /// ### Next steps
        /// Collect the OTP which was delivered to the user. Call
        /// [Authenticate OTP](https://stytch.com/docs/api/authenticate-otp) using the OTP `code` along with the
        /// `email_id` found in the response as the `method_id`.
        /// </summary>
        public async Task<OTPsEmailSendResponse> Send(
            OTPsEmailSendRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/otps/email/send"
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
                return JsonConvert.DeserializeObject<OTPsEmailSendResponse>(responseBody);
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
        /// Send a one-time passcode (OTP) to a User using their email. If the email is not associated with a User
        /// already, a User will be created.
        /// 
        /// ### Next steps
        /// 
        /// Collect the OTP which was delivered to the User. Call
        /// [Authenticate OTP](https://stytch.com/docs/api/authenticate-otp) using the OTP `code` along with the
        /// `phone_id` found in the response as the `method_id`.
        /// </summary>
        public async Task<OTPsEmailLoginOrCreateResponse> LoginOrCreate(
            OTPsEmailLoginOrCreateRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/otps/email/login_or_create"
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
                return JsonConvert.DeserializeObject<OTPsEmailLoginOrCreateResponse>(responseBody);
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

