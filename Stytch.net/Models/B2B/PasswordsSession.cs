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
    /// Request type for `passwords.sessions.reset`.
    /// </summary>
    public class B2BPasswordsSessionResetRequest {
      /// <summary>
    /// Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
    /// perform operations on an Organization, so be sure to preserve this value.
    /// </summary>
      [JsonProperty("organization_id")]
      public required string OrganizationId { get; set; }
      /// <summary>
    /// The password to authenticate, reset, or set for the first time. Any UTF8 character is allowed, e.g.
    /// spaces, emojis, non-English characers, etc.
    /// </summary>
      [JsonProperty("password")]
      public required string Password { get; set; }
      /// <summary>
    /// A secret token for a given Stytch Session.
    /// </summary>
      [JsonProperty("session_token")]
      public string? SessionToken { get; set; }
      /// <summary>
    /// The JSON Web Token (JWT) for a given Stytch Session.
    /// </summary>
      [JsonProperty("session_jwt")]
      public string? SessionJwt { get; set; }
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
      public object? SessionCustomClaims { get; set; }
      /// <summary>
    /// Used to determine which language to use when sending the user this delivery method. Parameter is a
    /// [IETF BCP 47 language tag](https://www.w3.org/International/articles/language-tags/), e.g. `"en"`.
    /// 
    /// Currently supported languages are English (`"en"`), Spanish (`"es"`), and Brazilian Portuguese
    /// (`"pt-br"`); if no value is provided, the copy defaults to English.
    /// 
    /// Request support for additional languages
    /// [here](https://docs.google.com/forms/d/e/1FAIpQLScZSpAu_m2AmLXRT3F3kap-s_mcV6UTBitYn6CdyWP0-o7YjQ/viewform?usp=sf_link")!
    /// 
    /// </summary>
      [JsonProperty("locale")]
      public B2BPasswordsSessionResetRequestLocale? Locale { get; set; }
    }
/// <summary>
    /// Response type for `passwords.sessions.reset`.
    /// </summary>
    public class B2BPasswordsSessionResetResponse {
      /// <summary>
    /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
    /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    /// </summary>
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      /// <summary>
    /// Globally unique UUID that identifies a specific Member.
    /// </summary>
      [JsonProperty("member_id")]
      public required string MemberId { get; set; }
      /// <summary>
    /// The [Member object](https://stytch.com/docs/b2b/api/member-object)
    /// </summary>
      [JsonProperty("member")]
      public required Member Member { get; set; }
      /// <summary>
    /// The [Organization object](https://stytch.com/docs/b2b/api/organization-object).
    /// </summary>
      [JsonProperty("organization")]
      public required Organization Organization { get; set; }
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
      public required string IntermediateSessionToken { get; set; }
      /// <summary>
    /// Indicates whether the Member is fully authenticated. If false, the Member needs to complete an MFA step
    /// to log in to the Organization.
    /// </summary>
      [JsonProperty("member_authenticated")]
      public required bool MemberAuthenticated { get; set; }
      /// <summary>
    /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
    /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
    /// </summary>
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
      /// <summary>
    /// The [Session object](https://stytch.com/docs/b2b/api/session-object).
    /// </summary>
      [JsonProperty("member_session")]
      public MemberSession? MemberSession { get; set; }
      /// <summary>
    /// Information about the MFA requirements of the Organization and the Member's options for fulfilling MFA.
    /// </summary>
      [JsonProperty("mfa_required")]
      public MfaRequired? MfaRequired { get; set; }
    }

public enum B2BPasswordsSessionResetRequestLocale
    {
      [EnumMember(Value = "en")]
      EN,
      [EnumMember(Value = "es")]
      ES,
      [EnumMember(Value = "pt-br")]
      PTBR,
    }
}