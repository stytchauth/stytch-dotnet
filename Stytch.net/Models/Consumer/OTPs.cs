// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace Stytch.net.Models.Consumer
{
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.Consumer.OTPs.Authenticate"/>..
    /// </summary>
    public class OTPsAuthenticateRequest
    {
        /// <summary>
        /// The `email_id` or `phone_id` involved in the given authentication.
        /// </summary>
        [JsonProperty("method_id")]
        public string MethodId { get; set; }
        /// <summary>
        /// The code to authenticate.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }
        /// <summary>
        /// Provided attributes help with fraud detection.
        /// </summary>
        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
        /// <summary>
        /// Specify optional security settings.
        /// </summary>
        [JsonProperty("options")]
        public Options Options { get; set; }
        /// <summary>
        /// The `session_token` associated with a User's existing Session.
        /// </summary>
        [JsonProperty("session_token")]
        public string SessionToken { get; set; }
        /// <summary>
        /// Set the session lifetime to be this many minutes from now. This will start a new session if one doesn't
        /// already exist, 
        ///   returning both an opaque `session_token` and `session_jwt` for this session. Remember that the
        /// `session_jwt` will have a fixed lifetime of
        ///   five minutes regardless of the underlying session duration, and will need to be refreshed over time.
        /// 
        ///   This value must be a minimum of 5 and a maximum of 527040 minutes (366 days).
        ///   
        ///   If a `session_token` or `session_jwt` is provided then a successful authentication will continue to
        /// extend the session this many minutes.
        ///   
        ///   If the `session_duration_minutes` parameter is not specified, a Stytch session will not be created.
        /// </summary>
        [JsonProperty("session_duration_minutes")]
        public int? SessionDurationMinutes { get; set; }
        /// <summary>
        /// The `session_jwt` associated with a User's existing Session.
        /// </summary>
        [JsonProperty("session_jwt")]
        public string SessionJwt { get; set; }
        /// <summary>
        /// Add a custom claims map to the Session being authenticated. Claims are only created if a Session is
        /// initialized by providing a value in `session_duration_minutes`. Claims will be included on the Session
        /// object and in the JWT. To update a key in an existing Session, supply a new value. To delete a key,
        /// supply a null value.
        /// 
        ///   Custom claims made with reserved claims ("iss", "sub", "aud", "exp", "nbf", "iat", "jti") will be
        /// ignored. Total custom claims size cannot exceed four kilobytes.
        /// </summary>
        [JsonProperty("session_custom_claims")]
        public object SessionCustomClaims { get; set; }
        public OTPsAuthenticateRequest(string methodId, string code)
        {
            this.MethodId = methodId;
            this.Code = code;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.Consumer.OTPs.Authenticate"/>..
    /// </summary>
    public class OTPsAuthenticateResponse
    {
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        /// <summary>
        /// The unique ID of the affected User.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        /// <summary>
        /// The `email_id` or `phone_id` involved in the given authentication.
        /// </summary>
        [JsonProperty("method_id")]
        public string MethodId { get; set; }
        /// <summary>
        /// A secret token for a given Stytch Session.
        /// </summary>
        [JsonProperty("session_token")]
        public string SessionToken { get; set; }
        /// <summary>
        /// The JSON Web Token (JWT) for a given Stytch Session.
        /// </summary>
        [JsonProperty("session_jwt")]
        public string SessionJwt { get; set; }
        /// <summary>
        /// The `user` object affected by this API call. See the
        /// [Get user endpoint](https://stytch.com/docs/api/get-user) for complete response field details.
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }
        /// <summary>
        /// Indicates if all other of the User's Sessions need to be reset. You should check this field if you
        /// aren't using Stytch's Session product. If you are using Stytch's Session product, we revoke the User's
        /// other sessions for you.
        /// </summary>
        [JsonProperty("reset_sessions")]
        public bool ResetSessions { get; set; }
        /// <summary>
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
        /// <summary>
        /// If you initiate a Session, by including `session_duration_minutes` in your authenticate call, you'll
        /// receive a full Session object in the response.
        /// 
        ///   See [GET sessions](https://stytch.com/docs/api/session-get) for complete response fields.
        ///   
        /// </summary>
        [JsonProperty("session")]
        public Session Session { get; set; }
    }

}