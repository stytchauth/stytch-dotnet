// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace Stytch.net.Models.Consumer
{
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.TOTPs.Authenticate"/>..
    /// </summary>
    public class B2BTOTPsAuthenticateRequest
    {
        /// <summary>
        /// Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
        /// perform operations on an Organization, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
        /// <summary>
        /// Globally unique UUID that identifies a specific Member. The `member_id` is critical to perform
        /// operations on a Member, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("member_id")]
        public string MemberId { get; set; }
        /// <summary>
        /// The code to authenticate.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }
        /// <summary>
        /// The Intermediate Session Token. This token does not necessarily belong to a specific instance of a
        /// Member, but represents a bag of factors that may be converted to a member session. The token can be used
        /// with the [OTP SMS Authenticate endpoint](https://stytch.com/docs/b2b/api/authenticate-otp-sms),
        /// [TOTP Authenticate endpoint](https://stytch.com/docs/b2b/api/authenticate-totp), or
        /// [Recovery Codes Recover endpoint](https://stytch.com/docs/b2b/api/recovery-codes-recover) to complete an
        /// MFA flow and log in to the Organization. It can also be used with the
        /// [Exchange Intermediate Session endpoint](https://stytch.com/docs/b2b/api/exchange-intermediate-session)
        /// to join a specific Organization that allows the factors represented by the intermediate session token;
        /// or the
        /// [Create Organization via Discovery endpoint](https://stytch.com/docs/b2b/api/create-organization-via-discovery) to create a new Organization and Member.
        /// </summary>
        [JsonProperty("intermediate_session_token")]
        public string IntermediateSessionToken { get; set; }
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
        ///   If the `session_duration_minutes` parameter is not specified, a Stytch session will be created with a
        /// 60 minute duration. If you don't want
        ///   to use the Stytch session product, you can ignore the session fields in the response.
        /// </summary>
        [JsonProperty("session_duration_minutes")]
        public int? SessionDurationMinutes { get; set; }
        /// <summary>
        /// Add a custom claims map to the Session being authenticated. Claims are only created if a Session is
        /// initialized by providing a value in
        ///   `session_duration_minutes`. Claims will be included on the Session object and in the JWT. To update a
        /// key in an existing Session, supply a new value. To
        ///   delete a key, supply a null value. Custom claims made with reserved claims (`iss`, `sub`, `aud`,
        /// `exp`, `nbf`, `iat`, `jti`) will be ignored.
        ///   Total custom claims size cannot exceed four kilobytes.
        /// </summary>
        [JsonProperty("session_custom_claims")]
        public object SessionCustomClaims { get; set; }
        /// <summary>
        /// Optionally sets the Member’s MFA enrollment status upon a successful authentication. If the
        /// Organization’s MFA policy is `REQUIRED_FOR_ALL`, this field will be ignored. If this field is not passed
        /// in, the Member’s `mfa_enrolled` boolean will not be affected. The options are:
        ///  
        ///   `enroll` – sets the Member's `mfa_enrolled` boolean to `true`. The Member will be required to complete
        /// an MFA step upon subsequent logins to the Organization.
        ///  
        ///   `unenroll` –  sets the Member's `mfa_enrolled` boolean to `false`. The Member will no longer be
        /// required to complete MFA steps when logging in to the Organization.
        ///   
        /// </summary>
        [JsonProperty("set_mfa_enrollment")]
        public string SetMfaEnrollment { get; set; }
        /// <summary>
        /// If passed will set the authenticated method to the default MFA method. Completing an MFA authentication
        /// flow for the first time for a Member will implicitly set the method to the default MFA method. This
        /// option can be used to update the default MFA method if multiple are being used.
        /// </summary>
        [JsonProperty("set_default_mfa")]
        public bool? SetDefaultMfa { get; set; }
        public B2BTOTPsAuthenticateRequest(string organizationId, string memberId, string code)
        {
            this.OrganizationId = organizationId;
            this.MemberId = memberId;
            this.Code = code;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.TOTPs.Authenticate"/>..
    /// </summary>
    public class B2BTOTPsAuthenticateResponse
    {
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        /// <summary>
        /// Globally unique UUID that identifies a specific Member.
        /// </summary>
        [JsonProperty("member_id")]
        public string MemberId { get; set; }
        /// <summary>
        /// The [Member object](https://stytch.com/docs/b2b/api/member-object)
        /// </summary>
        [JsonProperty("member")]
        public Member Member { get; set; }
        /// <summary>
        /// The [Organization object](https://stytch.com/docs/b2b/api/organization-object).
        /// </summary>
        [JsonProperty("organization")]
        public Organization Organization { get; set; }
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
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
        /// <summary>
        /// The [Session object](https://stytch.com/docs/b2b/api/session-object).
        /// </summary>
        [JsonProperty("member_session")]
        public MemberSession MemberSession { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.TOTPs.Create"/>..
    /// </summary>
    public class B2BTOTPsCreateRequest
    {
        /// <summary>
        /// Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
        /// perform operations on an Organization, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
        /// <summary>
        /// Globally unique UUID that identifies a specific Member. The `member_id` is critical to perform
        /// operations on a Member, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("member_id")]
        public string MemberId { get; set; }
        /// <summary>
        /// The expiration for the TOTP registration. If the newly created TOTP registration is not authenticated
        /// within this time frame the member will have to restart the registration flow. Defaults to 60 (1 hour)
        /// with a minimum of 5 and a maximum of 1440.
        /// </summary>
        [JsonProperty("expiration_minutes")]
        public int? ExpirationMinutes { get; set; }
        /// <summary>
        /// The Intermediate Session Token. This token does not necessarily belong to a specific instance of a
        /// Member, but represents a bag of factors that may be converted to a member session. The token can be used
        /// with the [OTP SMS Authenticate endpoint](https://stytch.com/docs/b2b/api/authenticate-otp-sms),
        /// [TOTP Authenticate endpoint](https://stytch.com/docs/b2b/api/authenticate-totp), or
        /// [Recovery Codes Recover endpoint](https://stytch.com/docs/b2b/api/recovery-codes-recover) to complete an
        /// MFA flow and log in to the Organization. It can also be used with the
        /// [Exchange Intermediate Session endpoint](https://stytch.com/docs/b2b/api/exchange-intermediate-session)
        /// to join a specific Organization that allows the factors represented by the intermediate session token;
        /// or the
        /// [Create Organization via Discovery endpoint](https://stytch.com/docs/b2b/api/create-organization-via-discovery) to create a new Organization and Member.
        /// </summary>
        [JsonProperty("intermediate_session_token")]
        public string IntermediateSessionToken { get; set; }
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
        public B2BTOTPsCreateRequest(string organizationId, string memberId)
        {
            this.OrganizationId = organizationId;
            this.MemberId = memberId;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.TOTPs.Create"/>..
    /// </summary>
    public class B2BTOTPsCreateResponse
    {
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        /// <summary>
        /// Globally unique UUID that identifies a specific Member.
        /// </summary>
        [JsonProperty("member_id")]
        public string MemberId { get; set; }
        /// <summary>
        /// The unique ID for a TOTP instance.
        /// </summary>
        [JsonProperty("totp_registration_id")]
        public string TOTPRegistrationId { get; set; }
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
        /// An array of recovery codes that can be used to recover a Member's account.
        /// </summary>
        [JsonProperty("recovery_codes")]
        public List<string> RecoveryCodes { get; set; }
        /// <summary>
        /// The [Member object](https://stytch.com/docs/b2b/api/member-object)
        /// </summary>
        [JsonProperty("member")]
        public Member Member { get; set; }
        /// <summary>
        /// The [Organization object](https://stytch.com/docs/b2b/api/organization-object).
        /// </summary>
        [JsonProperty("organization")]
        public Organization Organization { get; set; }
        /// <summary>
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.TOTPs.Migrate"/>..
    /// </summary>
    public class B2BTOTPsMigrateRequest
    {
        /// <summary>
        /// Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
        /// perform operations on an Organization, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
        /// <summary>
        /// Globally unique UUID that identifies a specific Member. The `member_id` is critical to perform
        /// operations on a Member, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("member_id")]
        public string MemberId { get; set; }
        /// <summary>
        /// The TOTP secret key shared between the authenticator app and the server used to generate TOTP codes.
        /// </summary>
        [JsonProperty("secret")]
        public string Secret { get; set; }
        /// <summary>
        /// An existing set of recovery codes to be imported into Stytch to be used to authenticate in place of the
        /// secondary MFA method.
        /// </summary>
        [JsonProperty("recovery_codes")]
        public List<string> RecoveryCodes { get; set; }
        public B2BTOTPsMigrateRequest(string organizationId, string memberId, string secret, List<string> recoveryCodes)
        {
            this.OrganizationId = organizationId;
            this.MemberId = memberId;
            this.Secret = secret;
            this.RecoveryCodes = recoveryCodes;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.TOTPs.Migrate"/>..
    /// </summary>
    public class B2BTOTPsMigrateResponse
    {
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        /// <summary>
        /// Globally unique UUID that identifies a specific Member.
        /// </summary>
        [JsonProperty("member_id")]
        public string MemberId { get; set; }
        /// <summary>
        /// The [Member object](https://stytch.com/docs/b2b/api/member-object)
        /// </summary>
        [JsonProperty("member")]
        public Member Member { get; set; }
        /// <summary>
        /// The [Organization object](https://stytch.com/docs/b2b/api/organization-object).
        /// </summary>
        [JsonProperty("organization")]
        public Organization Organization { get; set; }
        /// <summary>
        /// The unique ID for a TOTP instance.
        /// </summary>
        [JsonProperty("totp_registration_id")]
        public string TOTPRegistrationId { get; set; }
        /// <summary>
        /// An array of recovery codes that can be used to recover a Member's account.
        /// </summary>
        [JsonProperty("recovery_codes")]
        public List<string> RecoveryCodes { get; set; }
        /// <summary>
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
    }

}