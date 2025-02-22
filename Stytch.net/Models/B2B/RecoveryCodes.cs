// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace Stytch.net.Models.Consumer
{
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.RecoveryCodes.Get"/>..
    /// </summary>
    public class B2BRecoveryCodesGetRequest
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
        public B2BRecoveryCodesGetRequest(string organizationId, string memberId)
        {
            this.OrganizationId = organizationId;
            this.MemberId = memberId;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.RecoveryCodes.Get"/>..
    /// </summary>
    public class B2BRecoveryCodesGetResponse
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
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.RecoveryCodes.Recover"/>..
    /// </summary>
    public class B2BRecoveryCodesRecoverRequest
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
        /// The recovery code generated by a secondary MFA method. This code is used to authenticate in place of the
        /// secondary MFA method if that method as a backup.
        /// </summary>
        [JsonProperty("recovery_code")]
        public string RecoveryCode { get; set; }
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
        public B2BRecoveryCodesRecoverRequest(string organizationId, string memberId, string recoveryCode)
        {
            this.OrganizationId = organizationId;
            this.MemberId = memberId;
            this.RecoveryCode = recoveryCode;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.RecoveryCodes.Recover"/>..
    /// </summary>
    public class B2BRecoveryCodesRecoverResponse
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
        /// The number of recovery codes remaining for a Member.
        /// </summary>
        [JsonProperty("recovery_codes_remaining")]
        public int RecoveryCodesRemaining { get; set; }
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
    /// Request type for <see cref="Stytch.net.Clients.B2B.RecoveryCodes.Rotate"/>..
    /// </summary>
    public class B2BRecoveryCodesRotateRequest
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
        public B2BRecoveryCodesRotateRequest(string organizationId, string memberId)
        {
            this.OrganizationId = organizationId;
            this.MemberId = memberId;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.RecoveryCodes.Rotate"/>..
    /// </summary>
    public class B2BRecoveryCodesRotateResponse
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
