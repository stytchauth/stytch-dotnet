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
    public class OrganizationsMembers
    {
        private readonly ClientConfig _config;
        private readonly HttpClient _httpClient;
        public readonly OrganizationsMembersOAuthProviders OAuthProviders;
        public OrganizationsMembers(HttpClient client, ClientConfig config)
        {
            _httpClient = client;
            _config = config;
            OAuthProviders = new OrganizationsMembersOAuthProviders(_httpClient, _config);
        }

        /// <summary>
        /// Updates a Member specified by `organization_id` and `member_id`.
        /// </summary>
        public async Task<B2BOrganizationsMembersUpdateResponse> Update(
            B2BOrganizationsMembersUpdateRequest request
            , B2BOrganizationsMembersUpdateRequestOptions options
        )
        {
            var method = HttpMethod.Put;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/organizations/${request.OrganizationId}/members/${request.MemberId}"
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
                return JsonConvert.DeserializeObject<B2BOrganizationsMembersUpdateResponse>(responseBody);
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
        /// Deletes a Member specified by `organization_id` and `member_id`.
        /// </summary>
        public async Task<B2BOrganizationsMembersDeleteResponse> Delete(
            B2BOrganizationsMembersDeleteRequest request
            , B2BOrganizationsMembersDeleteRequestOptions options
        )
        {
            var method = HttpMethod.Delete;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/organizations/${request.OrganizationId}/members/${request.MemberId}"
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
                return JsonConvert.DeserializeObject<B2BOrganizationsMembersDeleteResponse>(responseBody);
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
        /// Reactivates a deleted Member's status and its associated email status (if applicable) to active,
        /// specified by `organization_id` and `member_id`.
        /// </summary>
        public async Task<B2BOrganizationsMembersReactivateResponse> Reactivate(
            B2BOrganizationsMembersReactivateRequest request
            , B2BOrganizationsMembersReactivateRequestOptions options
        )
        {
            var method = HttpMethod.Put;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/organizations/${request.OrganizationId}/members/${request.MemberId}/reactivate"
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
                return JsonConvert.DeserializeObject<B2BOrganizationsMembersReactivateResponse>(responseBody);
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
        /// Delete a Member's MFA phone number. 
        /// 
        /// To change a Member's phone number, you must first call this endpoint to delete the existing phone number.
        /// 
        /// Existing Member Sessions that include a phone number authentication factor will not be revoked if the
        /// phone number is deleted, and MFA will not be enforced until the Member logs in again.
        /// If you wish to enforce MFA immediately after a phone number is deleted, you can do so by prompting the
        /// Member to enter a new phone number
        /// and calling the [OTP SMS send](https://stytch.com/docs/b2b/api/otp-sms-send) endpoint, then calling the
        /// [OTP SMS Authenticate](https://stytch.com/docs/b2b/api/authenticate-otp-sms) endpoint.
        /// </summary>
        public async Task<B2BOrganizationsMembersDeleteMFAPhoneNumberResponse> DeleteMFAPhoneNumber(
            B2BOrganizationsMembersDeleteMFAPhoneNumberRequest request
            , B2BOrganizationsMembersDeleteMFAPhoneNumberRequestOptions options
        )
        {
            var method = HttpMethod.Delete;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/organizations/${request.OrganizationId}/members/mfa_phone_numbers/${request.MemberId}"
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
                return JsonConvert.DeserializeObject<B2BOrganizationsMembersDeleteMFAPhoneNumberResponse>(responseBody);
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
        /// Delete a Member's MFA TOTP registration.
        /// 
        /// To mint a new registration for a Member, you must first call this endpoint to delete the existing
        /// registration.
        /// 
        /// Existing Member Sessions that include the TOTP authentication factor will not be revoked if the
        /// registration is deleted, and MFA will not be enforced until the Member logs in again.
        /// </summary>
        public async Task<B2BOrganizationsMembersDeleteTOTPResponse> DeleteTOTP(
            B2BOrganizationsMembersDeleteTOTPRequest request
            , B2BOrganizationsMembersDeleteTOTPRequestOptions options
        )
        {
            var method = HttpMethod.Delete;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/organizations/${request.OrganizationId}/members/${request.MemberId}/totp"
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
                return JsonConvert.DeserializeObject<B2BOrganizationsMembersDeleteTOTPResponse>(responseBody);
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
        /// Search for Members within specified Organizations. An array with at least one `organization_id` is
        /// required. Submitting an empty `query` returns all non-deleted Members within the specified Organizations.
        /// 
        /// *All fuzzy search filters require a minimum of three characters.
        /// </summary>
        public async Task<B2BOrganizationsMembersSearchResponse> Search(
            B2BOrganizationsMembersSearchRequest request
            , B2BOrganizationsMembersSearchRequestOptions options
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/organizations/members/search"
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
                return JsonConvert.DeserializeObject<B2BOrganizationsMembersSearchResponse>(responseBody);
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
        /// Delete a Member's password.
        /// </summary>
        public async Task<B2BOrganizationsMembersDeletePasswordResponse> DeletePassword(
            B2BOrganizationsMembersDeletePasswordRequest request
            , B2BOrganizationsMembersDeletePasswordRequestOptions options
        )
        {
            var method = HttpMethod.Delete;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/organizations/${request.OrganizationId}/members/passwords/${request.MemberPasswordId}"
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
                return JsonConvert.DeserializeObject<B2BOrganizationsMembersDeletePasswordResponse>(responseBody);
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
        /// Get a Member by `member_id`. This endpoint does not require an `organization_id`, enabling you to get
        /// members across organizations. This is a dangerous operation. Incorrect use may open you up to indirect
        /// object reference (IDOR) attacks. We recommend using the
        /// [Get Member](https://stytch.com/docs/b2b/api/get-member) API instead.
        /// </summary>
        public async Task<B2BOrganizationsMembersGetResponse> DangerouslyGet(
            B2BOrganizationsMembersDangerouslyGetRequest request
        )
        {
            var method = HttpMethod.Get;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/organizations/members/dangerously_get/${request.MemberId}"
            };
            uriBuilder.Query = Utility.BuildQueryString(new Dictionary<string, string> {
            {"include_deleted", (request.IncludeDeleted).ToString().ToLower()},
        });

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<B2BOrganizationsMembersGetResponse>(responseBody);
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
        public async Task<B2BOrganizationsMembersOIDCProvidersResponse> OIDCProviders(
            B2BOrganizationsMembersOIDCProviderInformationRequest request
        )
        {
            var method = HttpMethod.Get;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/organizations/${request.OrganizationId}/members/${request.MemberId}/oidc_providers"
            };
            uriBuilder.Query = Utility.BuildQueryString(new Dictionary<string, string> {
            {"include_refresh_token", (request.IncludeRefreshToken).ToString().ToLower()},
        });

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<B2BOrganizationsMembersOIDCProvidersResponse>(responseBody);
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
        /// Unlinks a retired email address from a Member specified by their `organization_id` and `member_id`. The
        /// email address
        /// to be retired can be identified in the request body by either its `email_id`, its `email_address`, or
        /// both. If using
        /// both identifiers they must refer to the same email.
        /// 
        /// A previously active email address can be marked as retired in one of two ways:
        /// 
        /// - It's replaced with a new primary email address during an explicit Member update.
        /// - A new email address is surfaced by an OAuth, SAML or OIDC provider. In this case the new email address
        /// becomes the
        ///   Member's primary email address and the old primary email address is retired.
        /// 
        /// A retired email address cannot be used by other Members in the same Organization. However, unlinking
        /// retired email
        /// addresses allows them to be subsequently re-used by other Organization Members. Retired email addresses
        /// can be viewed
        /// on the [Member object](https://stytch.com/docs/b2b/api/member-object).
        ///  %}
        /// </summary>
        public async Task<B2BOrganizationsMembersUnlinkRetiredEmailResponse> UnlinkRetiredEmail(
            B2BOrganizationsMembersUnlinkRetiredEmailRequest request
            , B2BOrganizationsMembersUnlinkRetiredEmailRequestOptions options
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/organizations/${request.OrganizationId}/members/${request.MemberId}/unlink_retired_email"
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
                return JsonConvert.DeserializeObject<B2BOrganizationsMembersUnlinkRetiredEmailResponse>(responseBody);
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
        /// Creates a Member. An `organization_id` and `email_address` are required.
        /// </summary>
        public async Task<B2BOrganizationsMembersCreateResponse> Create(
            B2BOrganizationsMembersCreateRequest request
            , B2BOrganizationsMembersCreateRequestOptions options
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/organizations/${request.OrganizationId}/members"
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
                return JsonConvert.DeserializeObject<B2BOrganizationsMembersCreateResponse>(responseBody);
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
        /// Get a Member by `member_id` or `email_address`.
        /// </summary>
        public async Task<B2BOrganizationsMembersGetResponse> Get(
            B2BOrganizationsMembersGetRequest request
        )
        {
            var method = HttpMethod.Get;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/organizations/${request.OrganizationId}/member"
            };
            uriBuilder.Query = Utility.BuildQueryString(new Dictionary<string, string> {
            {"member_id", request.MemberId},
            {"email_address", request.EmailAddress},
        });

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<B2BOrganizationsMembersGetResponse>(responseBody);
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

