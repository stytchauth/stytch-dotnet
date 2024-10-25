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

using JsonException = Newtonsoft.Json.JsonException;
using System.Text.Json;



namespace Stytch.net.Clients.Consumer
{
    public class Sessions
    {
        private readonly ClientConfig _config;
        private readonly HttpClient _httpClient;
        public Sessions(HttpClient client, ClientConfig config)
        {
            _httpClient = client;
            _config = config;
        }

        /// <summary>
        /// List all active Sessions for a given `user_id`. All timestamps are formatted according to the RFC 3339
        /// standard and are expressed in UTC, e.g. `2021-12-29T12:33:09Z`.
        /// </summary>
        public async Task<SessionsGetResponse> Get(
            SessionsGetRequest request
        )
        {
            var method = HttpMethod.Get;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/sessions"
            };
            uriBuilder.Query = Utility.BuildQueryString(new Dictionary<string, string> {
            {"user_id", request.UserId},
        });

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<SessionsGetResponse>(responseBody);
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
        /// Authenticate a session token or session JWT and retrieve associated session data. If
        /// `session_duration_minutes` is included, update the lifetime of the session to be that many minutes from
        /// now. All timestamps are formatted according to the RFC 3339 standard and are expressed in UTC, e.g.
        /// `2021-12-29T12:33:09Z`. This endpoint requires exactly one `session_jwt` or `session_token` as part of
        /// the request. If both are included, you will receive a `too_many_session_arguments` error.
        /// 
        /// You may provide a JWT that needs to be refreshed and is expired according to its `exp` claim. A new JWT
        /// will be returned if both the signature and the underlying Session are still valid. See our
        /// [How to use Stytch Session JWTs](https://stytch.com/docs/guides/sessions/using-jwts) guide for more
        /// information.
        /// </summary>
        public async Task<SessionsAuthenticateResponse> Authenticate(
            SessionsAuthenticateRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/sessions/authenticate"
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
                return JsonConvert.DeserializeObject<SessionsAuthenticateResponse>(responseBody);
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
        /// Revoke a Session, immediately invalidating all of its session tokens. You can revoke a session in three
        /// ways: using its ID, or using one of its session tokens, or one of its JWTs. This endpoint requires
        /// exactly one of those to be included in the request. It will return an error if multiple are present.
        /// </summary>
        public async Task<SessionsRevokeResponse> Revoke(
            SessionsRevokeRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/sessions/revoke"
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
                return JsonConvert.DeserializeObject<SessionsRevokeResponse>(responseBody);
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
        /// match that email address with an existing User and create a Stytch Session. You will need to create the
        /// user before using this endpoint.
        /// </summary>
        public async Task<SessionsMigrateResponse> Migrate(
            SessionsMigrateRequest request
        )
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/sessions/migrate"
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
                return JsonConvert.DeserializeObject<SessionsMigrateResponse>(responseBody);
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
        /// If you're using one of our [backend SDKs](https://stytch.com/docs/sdks), the JWKS roll will be handled
        /// for you.
        /// 
        /// If you're using your own JWT validation library, many have built-in support for JWKS rotation, and
        /// you'll just need to supply this API endpoint. If not, your application should decide which JWKS to use
        /// for validation by inspecting the `kid` value.
        /// 
        /// See our [How to use Stytch Session JWTs](https://stytch.com/docs/guides/sessions/using-jwts) guide for
        /// more information.
        /// </summary>
        public async Task<SessionsGetJWKSResponse> GetJWKS(
            SessionsGetJWKSRequest request
        )
        {
            var method = HttpMethod.Get;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/sessions/jwks/${request.ProjectId}"
            };

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<SessionsGetJWKSResponse>(responseBody);
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

        // MANUAL(AuthenticateJWT)(SERVICE_METHOD)
        // ADDIMPORT: using System.Text.Json;
        // ADDIMPORT: using JsonException = Newtonsoft.Json.JsonException;
        /// <summary>
        /// Parse a JWT and verify the signature, preferring local verification to remote.
        /// </summary>
        public async Task<Session> AuthenticateJwt(
            AuthenticateJwtRequest request)
        {
            try
            {
                return await AuthenticateJwtLocal(new AuthenticateJwtLocalRequest(request.SessionJwt)
                {
                    ClockSkew = request.ClockSkew,
                    LifetimeValidator = request.LifetimeValidator,
                });
            }
            catch
            {
                var networkResponse = await Authenticate(new SessionsAuthenticateRequest
                {
                    SessionJwt = request.SessionJwt,
                });
                return networkResponse.Session;
            }
        }

        /// <summary>
        /// The SessionJWTModel is an intermediate representation of the Session as stored in the JWT.
        /// It differs from the typical JSON API Response session in the following ways:
        /// - SessionId is stored as "id" instead of "session_id"
        /// - No user ID is present - it is stored under the "sub" claim 
        /// </summary>
        private class SessionJWTModel : Session
        {
            [JsonProperty("id")] public new string SessionId { get; set; }

            public Session ToSession(string userId)
            {
                return new Session
                {
                    SessionId = SessionId,
                    UserId = userId,
                    AuthenticationFactors = AuthenticationFactors,
                    StartedAt = StartedAt,
                    LastAccessedAt = LastAccessedAt,
                    ExpiresAt = ExpiresAt,
                    Attributes = Attributes,
                    CustomClaims = CustomClaims
                };
            }
        }

        /// <summary>
        /// Parse a JWT and verify the signature locally (without calling /authenticate in the API).
        /// </summary>
        public async Task<Session> AuthenticateJwtLocal(
            AuthenticateJwtLocalRequest request
        )
        {
            var res = await Utility.AuthenticateJwtLocal(_httpClient, _config, new Utility.AuthenticateJwtParams
            {
                Jwt = request.SessionJwt,
                ClockSkew = request.ClockSkew,
                LifetimeValidator = request.LifetimeValidator
            });

            var sessionJsonEl = (JsonElement)res.CustomClaims["https://stytch.com/session"];

            return JsonConvert.DeserializeObject<SessionJWTModel>(sessionJsonEl.GetRawText())
                .ToSession(res.Subject);
        }
        // ENDMANUAL(AuthenticateJWT)


    }

}

