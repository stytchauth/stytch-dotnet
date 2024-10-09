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
    public class OTPs
    {
        private readonly HttpClient _httpClient;
        public readonly OTPsSms Sms;
        public readonly OTPsWhatsapp Whatsapp;
        public readonly OTPsEmail Email;
        public OTPs(HttpClient client)
        {
            _httpClient = client;
            Sms = new OTPsSms(_httpClient);
            Whatsapp = new OTPsWhatsapp(_httpClient);
            Email = new OTPsEmail(_httpClient);
        }

        /// <summary>
        /// Authenticate a User given a `method_id` (the associated `email_id` or `phone_id`) and a `code`. This
        /// endpoint verifies that the code is valid, hasn't expired or been previously used, and any optional
        /// security settings such as IP match or user agent match are satisfied. A given `method_id` may only have
        /// a single active OTP code at any given time, if a User requests another OTP code before the first one has
        /// expired, the first one will be invalidated.
        /// </summary>
        public async Task<OTPsAuthenticateResponse> Authenticate(
            OTPsAuthenticateRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/otps/authenticate"
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
                return JsonConvert.DeserializeObject<OTPsAuthenticateResponse>(responseBody);
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

