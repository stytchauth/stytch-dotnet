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




namespace Stytch.net.Clients.B2B
{
    public class Sessions
    {
        private readonly HttpClient _httpClient;
        public Sessions(HttpClient client)
        {
            _httpClient = client;
        }

        /// <summary>
        /// Retrieves all active Sessions for a Member.
        /// </summary>
        public async Task<B2BSessionsGetResponse> Get(
            B2BSessionsGetRequest request
        )
        {
            var method = HttpMethod.Get;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/sessions"
            };
            var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
            query["organization_id"] = request.OrganizationId;
            query["member_id"] = request.MemberId;
            uriBuilder.Query = query.ToString();

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<B2BSessionsGetResponse>(responseBody);
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
        /// Authenticates a Session and updates its lifetime by the specified `session_duration_minutes`. If the
        /// `session_duration_minutes` is not specified, a Session will not be extended. This endpoint requires
        /// either a `session_jwt` or `session_token` be included in the request. It will return an error if both
        /// are present.
        /// 
        /// You may provide a JWT that needs to be refreshed and is expired according to its `exp` claim. A new JWT
        /// will be returned if both the signature and the underlying Session are still valid. See our
        /// [How to use Stytch Session JWTs](https://stytch.com/docs/b2b/guides/sessions/resources/using-jwts) guide
        /// for more information.
        /// 
        /// If an `authorization_check` object is passed in, this method will also check if the Member is authorized
        /// to perform the given action on the given Resource in the specified. A is authorized if their Member
        /// Session contains a Role, assigned
        /// [explicitly or implicitly](https://stytch.com/docs/b2b/guides/rbac/role-assignment), with adequate
        /// permissions.
        /// In addition, the `organization_id` passed in the authorization check must match the Member's
        /// Organization.
        /// 
        /// If the Member is not authorized to perform the specified action on the specified Resource, or if the
        /// `organization_id` does not match the Member's Organization, a 403 error will be thrown.
        /// Otherwise, the response will contain a list of Roles that satisfied the authorization check.
        /// </summary>
        public async Task<B2BSessionsAuthenticateResponse> Authenticate(
            B2BSessionsAuthenticateRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/sessions/authenticate"
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
                return JsonConvert.DeserializeObject<B2BSessionsAuthenticateResponse>(responseBody);
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
        /// Revoke a Session and immediately invalidate all its tokens. To revoke a specific Session, pass either
        /// the `member_session_id`, `session_token`, or `session_jwt`. To revoke all Sessions for a Member, pass
        /// the `member_id`.
        /// </summary>
        public async Task<B2BSessionsRevokeResponse> Revoke(
            B2BSessionsRevokeRequest request
            , B2BSessionsRevokeRequestOptions options
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/sessions/revoke"
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
                return JsonConvert.DeserializeObject<B2BSessionsRevokeResponse>(responseBody);
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
        /// Use this endpoint to exchange a's existing session for another session in a different. This can be used
        /// to accept an invite, but not to create a new member via domain matching.
        /// 
        /// To create a new member via domain matching, use the
        /// [Exchange Intermediate Session](https://stytch.com/docs/b2b/api/exchange-intermediate-session) flow
        /// instead.
        /// 
        /// Only Email Magic Link, OAuth, and SMS OTP factors can be transferred between sessions. Other
        /// authentication factors, such as password factors, will not be transferred to the new session.
        /// Any OAuth Tokens owned by the Member will not be transferred to the new Organization.
        /// SMS OTP factors can be used to fulfill MFA requirements for the target Organization if both the original
        /// and target Member have the same phone number and the phone number is verified for both Members.
        /// HubSpot and Slack OAuth registrations will not be transferred between sessions. Instead, you will
        /// receive a corresponding factor with type `"oauth_exchange_slack"` or `"oauth_exchange_hubspot"`
        /// 
        /// If the Member is required to complete MFA to log in to the Organization, the returned value of
        /// `member_authenticated` will be `false`, and an `intermediate_session_token` will be returned.
        /// The `intermediate_session_token` can be passed into the
        /// [OTP SMS Authenticate endpoint](https://stytch.com/docs/b2b/api/authenticate-otp-sms) to complete the
        /// MFA step and acquire a full member session.
        /// The `intermediate_session_token` can also be used with the
        /// [Exchange Intermediate Session endpoint](https://stytch.com/docs/b2b/api/exchange-intermediate-session)
        /// or the
        /// [Create Organization via Discovery endpoint](https://stytch.com/docs/b2b/api/create-organization-via-discovery) to join a different Organization or create a new one.
        /// The `session_duration_minutes` and `session_custom_claims` parameters will be ignored.
        /// </summary>
        public async Task<B2BSessionsExchangeResponse> Exchange(
            B2BSessionsExchangeRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/sessions/exchange"
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
                return JsonConvert.DeserializeObject<B2BSessionsExchangeResponse>(responseBody);
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
        /// Migrate a session from an external OIDC compliant endpoint. Stytch will call the external UserInfo
        /// endpoint defined in your Stytch Project settings in the [Dashboard](/dashboard), and then perform a
        /// lookup using the `session_token`. If the response contains a valid email address, Stytch will attempt to
        /// match that email address with an existing in your and create a Stytch Session. You will need to create
        /// the member before using this endpoint.
        /// </summary>
        public async Task<B2BSessionsMigrateResponse> Migrate(
            B2BSessionsMigrateRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/sessions/migrate"
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
                return JsonConvert.DeserializeObject<B2BSessionsMigrateResponse>(responseBody);
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
        /// Get the JSON Web Key Set (JWKS) for a project.
        /// 
        /// JWKS are rotated every ~6 months. Upon rotation, new JWTs will be signed using the new key set, and both
        /// key sets will be returned by this endpoint for a period of 1 month. 
        /// 
        /// JWTs have a set lifetime of 5 minutes, so there will be a 5 minute period where some JWTs will be signed
        /// by the old JWKS, and some JWTs will be signed by the new JWKS. The correct JWKS to use for validation is
        /// determined by matching the `kid` value of the JWT and JWKS.  
        /// 
        /// If you're using one of our [backend SDKs](https://stytch.com/docs/b2b/sdks), the JWKS roll will be
        /// handled for you.
        /// 
        /// If you're using your own JWT validation library, many have built-in support for JWKS rotation, and
        /// you'll just need to supply this API endpoint. If not, your application should decide which JWKS to use
        /// for validation by inspecting the `kid` value.
        /// 
        /// See our
        /// [How to use Stytch Session JWTs](https://stytch.com/docs/b2b/guides/sessions/resources/using-jwts) guide
        /// for more information.
        /// </summary>
        public async Task<B2BSessionsGetJWKSResponse> GetJWKS(
            B2BSessionsGetJWKSRequest request
        )
        {
            var method = HttpMethod.Get;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/sessions/jwks/${request.ProjectId}"
            };
            var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
            uriBuilder.Query = query.ToString();

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<B2BSessionsGetJWKSResponse>(responseBody);
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

