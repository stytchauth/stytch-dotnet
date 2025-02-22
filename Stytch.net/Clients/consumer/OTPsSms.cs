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
    public class OTPsSms
    {
        private readonly ClientConfig _config;
        private readonly HttpClient _httpClient;
        public OTPsSms(HttpClient client, ClientConfig config)
        {
            _httpClient = client;
            _config = config;
        }

        /// <summary>
        /// Send a one-time passcode (OTP) to a user's phone number. If you'd like to create a user and send them a
        /// passcode with one request, use our
        /// [log in or create](https://stytch.com/docs/api/log-in-or-create-user-by-sms) endpoint.
        /// 
        /// Note that sending another OTP code before the first has expired will invalidate the first code.
        /// 
        /// ### Cost to send SMS OTP
        /// Before configuring SMS or WhatsApp OTPs, please review how Stytch
        /// [bills the costs of international OTPs](https://stytch.com/pricing) and understand how to protect your
        /// app against [toll fraud](https://stytch.com/docs/guides/passcodes/toll-fraud/overview).
        /// 
        /// __Note:__ SMS to phone numbers outside of the US and Canada is disabled by default for customers who did
        /// not use SMS prior to October 2023. If you're interested in sending international SMS, please reach out
        /// to [support@stytch.com](mailto:support@stytch.com?subject=Enable%20international%20SMS).
        /// 
        /// Even when international SMS is enabled, we do not support sending SMS to countries on our
        /// [Unsupported countries list](https://stytch.com/docs/guides/passcodes/unsupported-countries).
        /// 
        /// ### Add a phone number to an existing user
        /// 
        /// This endpoint also allows you to add a new phone number to an existing Stytch User. Including a
        /// `user_id`, `session_token`, or `session_jwt` in your Send one-time passcode by SMS request will add the
        /// new, unverified phone number to the existing Stytch User. If the user successfully authenticates within
        /// 5 minutes, the new phone number will be marked as verified and remain permanently on the existing Stytch
        /// User. Otherwise, it will be removed from the User object, and any subsequent login requests using that
        /// phone number will create a new User.
        /// 
        /// ### Next steps
        /// 
        /// Collect the OTP which was delivered to the user. Call
        /// [Authenticate OTP](https://stytch.com/docs/api/authenticate-otp) using the OTP `code` along with the
        /// `phone_id` found in the response as the `method_id`.
        /// </summary>
        public async Task<OTPsSmsSendResponse> Send(
            OTPsSmsSendRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/otps/sms/send"
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
                return JsonConvert.DeserializeObject<OTPsSmsSendResponse>(responseBody);
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
        /// Send a One-Time Passcode (OTP) to a User using their phone number. If the phone number is not associated
        /// with a user already, a user will be created.
        /// 
        /// ### Cost to send SMS OTP
        /// Before configuring SMS or WhatsApp OTPs, please review how Stytch
        /// [bills the costs of international OTPs](https://stytch.com/pricing) and understand how to protect your
        /// app against [toll fraud](https://stytch.com/docs/guides/passcodes/toll-fraud/overview).
        /// 
        /// __Note:__ SMS to phone numbers outside of the US and Canada is disabled by default for customers who did
        /// not use SMS prior to October 2023. If you're interested in sending international SMS, please reach out
        /// to [support@stytch.com](mailto:support@stytch.com?subject=Enable%20international%20SMS).
        /// 
        /// Even when international SMS is enabled, we do not support sending SMS to countries on our
        /// [Unsupported countries list](https://stytch.com/docs/guides/passcodes/unsupported-countries).
        /// 
        /// ### Next steps
        /// 
        /// Collect the OTP which was delivered to the User. Call
        /// [Authenticate OTP](https://stytch.com/docs/api/authenticate-otp) using the OTP `code` along with the
        /// `phone_id` found in the response as the `method_id`.
        /// </summary>
        public async Task<OTPsSmsLoginOrCreateResponse> LoginOrCreate(
            OTPsSmsLoginOrCreateRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/otps/sms/login_or_create"
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
                return JsonConvert.DeserializeObject<OTPsSmsLoginOrCreateResponse>(responseBody);
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

