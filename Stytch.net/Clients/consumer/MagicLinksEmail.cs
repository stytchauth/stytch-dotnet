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
    public class MagicLinksEmail
    {
        private readonly ClientConfig _config;
        private readonly HttpClient _httpClient;
        public MagicLinksEmail(HttpClient client, ClientConfig config)
        {
            _httpClient = client;
            _config = config;
        }

        /// <summary>
        /// Send a magic link to an existing Stytch user using their email address. If you'd like to create a user
        /// and send them a magic link by email with one request, use our
        /// [log in or create endpoint](https://stytch.com/docs/api/log-in-or-create-user-by-email).
        /// 
        /// ### Add an email to an existing user
        /// This endpoint also allows you to add a new email address to an existing Stytch User. Including a
        /// `user_id`, `session_token`, or `session_jwt` in your Send Magic Link by email request will add the new,
        /// unverified email address to the existing Stytch User. If the user successfully authenticates within 5
        /// minutes, the new email address will be marked as verified and remain permanently on the existing Stytch
        /// User. Otherwise, it will be removed from the User object, and any subsequent login requests using that
        /// email address will create a new User.
        /// 
        /// ### Next steps
        /// The user is emailed a magic link which redirects them to the provided
        /// [redirect URL](https://stytch.com/docs/guides/magic-links/email-magic-links/redirect-routing). Collect
        /// the `token` from the URL query parameters, and call
        /// [Authenticate magic link](https://stytch.com/docs/api/authenticate-magic-link) to complete
        /// authentication.
        /// </summary>
        public async Task<MagicLinksEmailSendResponse> Send(
            MagicLinksEmailSendRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/magic_links/email/send"
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
                return JsonConvert.DeserializeObject<MagicLinksEmailSendResponse>(responseBody);
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
        /// Send either a login or signup Magic Link to the User based on if the email is associated with a User
        /// already. A new or pending User will receive a signup Magic Link. An active User will receive a login
        /// Magic Link. For more information on how to control the status your Users are created in see the
        /// `create_user_as_pending` flag.
        /// 
        /// ### Next steps
        /// The User is emailed a Magic Link which redirects them to the provided
        /// [redirect URL](https://stytch.com/docs/guides/magic-links/email-magic-links/redirect-routing). Collect
        /// the `token` from the URL query parameters and call
        /// [Authenticate Magic Link](https://stytch.com/docs/api/authenticate-magic-link) to complete
        /// authentication.
        /// </summary>
        public async Task<MagicLinksEmailLoginOrCreateResponse> LoginOrCreate(
            MagicLinksEmailLoginOrCreateRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/magic_links/email/login_or_create"
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
                return JsonConvert.DeserializeObject<MagicLinksEmailLoginOrCreateResponse>(responseBody);
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
        /// Create a User and send an invite Magic Link to the provided `email`. The User will be created with a
        /// `pending` status until they click the Magic Link in the invite email.
        /// 
        /// ### Next steps
        /// The User is emailed a Magic Link which redirects them to the provided
        /// [redirect URL](https://stytch.com/docs/guides/magic-links/email-magic-links/redirect-routing). Collect
        /// the `token` from the URL query parameters and call
        /// [Authenticate Magic Link](https://stytch.com/docs/api/authenticate-magic-link) to complete
        /// authentication.
        /// </summary>
        public async Task<MagicLinksEmailInviteResponse> Invite(
            MagicLinksEmailInviteRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/magic_links/email/invite"
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
                return JsonConvert.DeserializeObject<MagicLinksEmailInviteResponse>(responseBody);
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
        /// Revoke a pending invite based on the `email` provided.
        /// </summary>
        public async Task<MagicLinksEmailRevokeInviteResponse> RevokeInvite(
            MagicLinksEmailRevokeInviteRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/magic_links/email/revoke_invite"
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
                return JsonConvert.DeserializeObject<MagicLinksEmailRevokeInviteResponse>(responseBody);
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

