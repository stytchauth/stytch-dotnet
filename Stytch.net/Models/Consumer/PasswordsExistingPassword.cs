// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Stytch.net.Models.Consumer
{
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.Consumer.Passwords.ExistingPassword.Reset"/>..
    /// </summary>
    public class PasswordsExistingPasswordResetRequest
    {
        /// <summary>
        /// The email address of the end user.
        /// </summary>
        [JsonProperty("email")]
        public required string Email { get; set; }
        /// <summary>
        /// The user's existing password.
        /// </summary>
        [JsonProperty("existing_password")]
        public required string ExistingPassword { get; set; }
        /// <summary>
        /// The new password for the user.
        /// </summary>
        [JsonProperty("new_password")]
        public required string NewPassword { get; set; }
        /// <summary>
        /// The `session_token` associated with a User's existing Session.
        /// </summary>
        [JsonProperty("session_token")]
        public string? SessionToken { get; set; }
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
        public string? SessionJwt { get; set; }
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
        public object? SessionCustomClaims { get; set; }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.Consumer.Passwords.ExistingPassword.Reset"/>..
    /// </summary>
    public class PasswordsExistingPasswordResetResponse
    {
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public required string RequestId { get; set; }
        /// <summary>
        /// The unique ID of the affected User.
        /// </summary>
        [JsonProperty("user_id")]
        public required string UserId { get; set; }
        /// <summary>
        /// A secret token for a given Stytch Session.
        /// </summary>
        [JsonProperty("session_token")]
        public required string SessionToken { get; set; }
        /// <summary>
        /// The JSON Web Token (JWT) for a given Stytch Session.
        /// </summary>
        [JsonProperty("session_jwt")]
        public required string SessionJwt { get; set; }
        /// <summary>
        /// The `user` object affected by this API call. See the
        /// [Get user endpoint](https://stytch.com/docs/api/get-user) for complete response field details.
        /// </summary>
        [JsonProperty("user")]
        public required User User { get; set; }
        /// <summary>
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public required int StatusCode { get; set; }
        /// <summary>
        /// If you initiate a Session, by including `session_duration_minutes` in your authenticate call, you'll
        /// receive a full Session object in the response.
        /// 
        ///   See [GET sessions](https://stytch.com/docs/api/session-get) for complete response fields.
        ///   
        /// </summary>
        [JsonProperty("session")]
        public Session? Session { get; set; }
    }

}