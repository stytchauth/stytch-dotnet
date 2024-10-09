// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace Stytch.net.Models.Consumer
{
    public class TOTPWithRecoveryCodes
    {
        /// <summary>
        /// The unique ID for a TOTP instance.
        /// </summary>
        [JsonProperty("totp_id")]
        public string TOTPId { get; set; }
        /// <summary>
        /// The verified boolean denotes whether or not this send method, e.g. phone number, email address, etc.,
        /// has been successfully authenticated by the User.
        /// </summary>
        [JsonProperty("verified")]
        public bool Verified { get; set; }
        /// <summary>
        /// The recovery codes used to authenticate the user without an authenticator app.
        /// </summary>
        [JsonProperty("recovery_codes")]
        public List<string> RecoveryCodes { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.Consumer.TOTPs.Authenticate"/>..
    /// </summary>
    public class TOTPsAuthenticateRequest
    {
        /// <summary>
        /// The `user_id` of an active user the TOTP registration should be tied to.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        /// <summary>
        /// The TOTP code to authenticate. The TOTP code should consist of 6 digits.
        /// </summary>
        [JsonProperty("totp_code")]
        public string TOTPCode { get; set; }
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
        public TOTPsAuthenticateRequest(string userId, string totpCode)
        {
            this.UserId = userId;
            this.TOTPCode = totpCode;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.Consumer.TOTPs.Authenticate"/>..
    /// </summary>
    public class TOTPsAuthenticateResponse
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
        /// A secret token for a given Stytch Session.
        /// </summary>
        [JsonProperty("session_token")]
        public string SessionToken { get; set; }
        /// <summary>
        /// The unique ID for a TOTP instance.
        /// </summary>
        [JsonProperty("totp_id")]
        public string TOTPId { get; set; }
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
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.Consumer.TOTPs.Create"/>..
    /// </summary>
    public class TOTPsCreateRequest
    {
        /// <summary>
        /// The `user_id` of an active user the TOTP registration should be tied to.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        /// <summary>
        /// The expiration for the TOTP instance. If the newly created TOTP is not authenticated within this time
        /// frame the TOTP will be unusable. Defaults to 1440 (1 day) with a minimum of 5 and a maximum of 1440.
        /// </summary>
        [JsonProperty("expiration_minutes")]
        public int? ExpirationMinutes { get; set; }
        public TOTPsCreateRequest(string userId)
        {
            this.UserId = userId;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.Consumer.TOTPs.Create"/>..
    /// </summary>
    public class TOTPsCreateResponse
    {
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        /// <summary>
        /// The unique ID for a TOTP instance.
        /// </summary>
        [JsonProperty("totp_id")]
        public string TOTPId { get; set; }
        /// <summary>
        /// The TOTP secret key shared between the authenticator app and the server used to generate TOTP codes.
        /// </summary>
        [JsonProperty("secret")]
        public string Secret { get; set; }
        /// <summary>
        /// The QR code image encoded in base64.
        /// </summary>
        [JsonProperty("qr_code")]
        public string QrCode { get; set; }
        /// <summary>
        /// The recovery codes used to authenticate the user without an authenticator app.
        /// </summary>
        [JsonProperty("recovery_codes")]
        public List<string> RecoveryCodes { get; set; }
        /// <summary>
        /// The `user` object affected by this API call. See the
        /// [Get user endpoint](https://stytch.com/docs/api/get-user) for complete response field details.
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }
        /// <summary>
        /// The unique ID of the affected User.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        /// <summary>
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.Consumer.TOTPs.Recover"/>..
    /// </summary>
    public class TOTPsRecoverRequest
    {
        /// <summary>
        /// The `user_id` of an active user the TOTP registration should be tied to.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        /// <summary>
        /// The recovery code to authenticate.
        /// </summary>
        [JsonProperty("recovery_code")]
        public string RecoveryCode { get; set; }
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
        public TOTPsRecoverRequest(string userId, string recoveryCode)
        {
            this.UserId = userId;
            this.RecoveryCode = recoveryCode;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.Consumer.TOTPs.Recover"/>..
    /// </summary>
    public class TOTPsRecoverResponse
    {
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        /// <summary>
        /// The unique ID for a TOTP instance.
        /// </summary>
        [JsonProperty("totp_id")]
        public string TOTPId { get; set; }
        /// <summary>
        /// The unique ID of the affected User.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
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
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.Consumer.TOTPs.RecoveryCodes"/>..
    /// </summary>
    public class TOTPsRecoveryCodesRequest
    {
        /// <summary>
        /// The `user_id` of an active user the TOTP registration should be tied to.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        public TOTPsRecoveryCodesRequest(string userId)
        {
            this.UserId = userId;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.Consumer.TOTPs.RecoveryCodes"/>..
    /// </summary>
    public class TOTPsRecoveryCodesResponse
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
        /// An array containing a list of all TOTP instances (along with their recovery codes) for a given User in
        /// the Stytch API.
        /// </summary>
        [JsonProperty("totps")]
        public List<TOTPWithRecoveryCodes> TOTPs { get; set; }
        /// <summary>
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
    }

}