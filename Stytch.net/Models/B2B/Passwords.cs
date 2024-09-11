// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Stytch.net.Models.Consumer
{
public class LudsFeedback {
      /// <summary>
    /// For LUDS validation, whether the password contains at least one lowercase letter.
    /// </summary>
      [JsonProperty("has_lower_case")]
      public required bool HasLowerCase { get; set; }
      /// <summary>
    /// For LUDS validation, whether the password contains at least one uppercase letter.
    /// </summary>
      [JsonProperty("has_upper_case")]
      public required bool HasUpperCase { get; set; }
      /// <summary>
    /// For LUDS validation, whether the password contains at least one digit.
    /// </summary>
      [JsonProperty("has_digit")]
      public required bool HasDigit { get; set; }
      /// <summary>
    /// For LUDS validation, whether the password contains at least one symbol. Any UTF8 character outside of
    /// a-z or A-Z may count as a valid symbol.
    /// </summary>
      [JsonProperty("has_symbol")]
      public required bool HasSymbol { get; set; }
      /// <summary>
    /// For LUDS validation, the number of complexity requirements that are missing from the password. 
    ///       Check the complexity fields to see which requirements are missing.
    /// </summary>
      [JsonProperty("missing_complexity")]
      public required int MissingComplexity { get; set; }
      /// <summary>
    /// For LUDS validation, this is the required length of the password that you've set minus the length of the
    /// password being checked. 
    ///       The user will need to add this many characters to the password to make it valid.
    /// </summary>
      [JsonProperty("missing_characters")]
      public required int MissingCharacters { get; set; }
    }
public class ZxcvbnFeedback {
      /// <summary>
    /// For zxcvbn validation, contains an end user consumable warning if the password is valid but not strong
    /// enough.
    /// </summary>
      [JsonProperty("warning")]
      public required string Warning { get; set; }
      /// <summary>
    /// For zxcvbn validation, contains end user consumable suggestions on how to improve the strength of the
    /// password.
    /// </summary>
      [JsonProperty("suggestions")]
      public required string Suggestions { get; set; }
    }
/// <summary>
    /// Request type for `passwords.authenticate`.
    /// </summary>
    public class B2BPasswordsAuthenticateRequest {
      /// <summary>
    /// Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
    /// perform operations on an Organization, so be sure to preserve this value.
    /// </summary>
      [JsonProperty("organization_id")]
      public required string OrganizationId { get; set; }
      /// <summary>
    /// The email address of the Member.
    /// </summary>
      [JsonProperty("email_address")]
      public required string EmailAddress { get; set; }
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
    /// The JSON Web Token (JWT) for a given Stytch Session.
    /// </summary>
      [JsonProperty("session_jwt")]
      public string? SessionJwt { get; set; }
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
    /// If the Member needs to complete an MFA step, and the Member has a phone number, this endpoint will
    /// pre-emptively send a one-time passcode (OTP) to the Member's phone number. The locale argument will be
    /// used to determine which language to use when sending the passcode.
    /// 
    /// Parameter is a [IETF BCP 47 language tag](https://www.w3.org/International/articles/language-tags/),
    /// e.g. `"en"`.
    /// 
    /// Currently supported languages are English (`"en"`), Spanish (`"es"`), and Brazilian Portuguese
    /// (`"pt-br"`); if no value is provided, the copy defaults to English.
    /// 
    /// Request support for additional languages
    /// [here](https://docs.google.com/forms/d/e/1FAIpQLScZSpAu_m2AmLXRT3F3kap-s_mcV6UTBitYn6CdyWP0-o7YjQ/viewform?usp=sf_link")!
    /// 
    /// </summary>
      [JsonProperty("locale")]
      public B2BPasswordsAuthenticateRequestLocale? Locale { get; set; }
      /// <summary>
    /// Adds this primary authentication factor to the intermediate session token. If the resulting set of
    /// factors satisfies the organization's primary authentication requirements and MFA requirements, the
    /// intermediate session token will be consumed and converted to a member session. If not, the same
    /// intermediate session token will be returned.
    /// </summary>
      [JsonProperty("intermediate_session_token")]
      public string? IntermediateSessionToken { get; set; }
    }
/// <summary>
    /// Response type for `passwords.authenticate`.
    /// </summary>
    public class B2BPasswordsAuthenticateResponse {
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
    /// Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
    /// perform operations on an Organization, so be sure to preserve this value.
    /// </summary>
      [JsonProperty("organization_id")]
      public required string OrganizationId { get; set; }
      /// <summary>
    /// The [Member object](https://stytch.com/docs/b2b/api/member-object)
    /// </summary>
      [JsonProperty("member")]
      public required Member Member { get; set; }
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
    /// The [Organization object](https://stytch.com/docs/b2b/api/organization-object).
    /// </summary>
      [JsonProperty("organization")]
      public required Organization Organization { get; set; }
      /// <summary>
    /// The returned Intermediate Session Token contains a password factor associated with the Member. If this
    /// value is non-empty, the member must complete an MFA step to finish logging in to the Organization. The
    /// token can be used with the
    /// [OTP SMS Authenticate endpoint](https://stytch.com/docs/b2b/api/authenticate-otp-sms),
    /// [TOTP Authenticate endpoint](https://stytch.com/docs/b2b/api/authenticate-totp), or
    /// [Recovery Codes Recover endpoint](https://stytch.com/docs/b2b/api/recovery-codes-recover) to complete an
    /// MFA flow and log in to the Organization. Password factors are not transferable between Organizations, so
    /// the intermediate session token is not valid for use with discovery endpoints.
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
/// <summary>
    /// Request type for `passwords.migrate`.
    /// </summary>
    public class B2BPasswordsMigrateRequest {
      /// <summary>
    /// The email address of the Member.
    /// </summary>
      [JsonProperty("email_address")]
      public required string EmailAddress { get; set; }
      /// <summary>
    /// The password hash. For a Scrypt or PBKDF2 hash, the hash needs to be a base64 encoded string.
    /// </summary>
      [JsonProperty("hash")]
      public required string Hash { get; set; }
      /// <summary>
    /// The password hash used. Currently `bcrypt`, `scrypt`, `argon2i`, `argon2id`, `md_5`, `sha_1`, and
    /// `pbkdf_2` are supported.
    /// </summary>
      [JsonProperty("hash_type")]
      public required B2BPasswordsMigrateRequestHashType HashType { get; set; }
      /// <summary>
    /// Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
    /// perform operations on an Organization, so be sure to preserve this value.
    /// </summary>
      [JsonProperty("organization_id")]
      public required string OrganizationId { get; set; }
      /// <summary>
    /// Optional parameters for MD-5 hash types.
    /// </summary>
      [JsonProperty("md_5_config")]
      public MD5Config? Md5Config { get; set; }
      /// <summary>
    /// Required parameters if the argon2 hex form, as opposed to the encoded form, is supplied.
    /// </summary>
      [JsonProperty("argon_2_config")]
      public Argon2Config? Argon2Config { get; set; }
      /// <summary>
    /// Optional parameters for SHA-1 hash types.
    /// </summary>
      [JsonProperty("sha_1_config")]
      public SHA1Config? Sha1Config { get; set; }
      /// <summary>
    /// Required parameters if the scrypt is not provided in a **PHC encoded form**.
    /// </summary>
      [JsonProperty("scrypt_config")]
      public ScryptConfig? ScryptConfig { get; set; }
      /// <summary>
    /// Required additional parameters for PBKDF2 hash keys. Note that we use the SHA-256 by default, please
    /// contact [support@stytch.com](mailto:support@stytch.com) if you use another hashing function.
    /// </summary>
      [JsonProperty("pbkdf_2_config")]
      public PBKDF2Config? Pbkdf2Config { get; set; }
      /// <summary>
    /// The name of the Member. Each field in the name object is optional.
    /// </summary>
      [JsonProperty("name")]
      public string? Name { get; set; }
      /// <summary>
    /// An arbitrary JSON object for storing application-specific data or identity-provider-specific data.
    /// </summary>
      [JsonProperty("trusted_metadata")]
      public object? TrustedMetadata { get; set; }
      /// <summary>
    /// An arbitrary JSON object of application-specific data. These fields can be edited directly by the
    ///   frontend SDK, and should not be used to store critical information. See the
    /// [Metadata resource](https://stytch.com/docs/b2b/api/metadata)
    ///   for complete field behavior details.
    /// </summary>
      [JsonProperty("untrusted_metadata")]
      public object? UntrustedMetadata { get; set; }
      /// <summary>
    /// Roles to explicitly assign to this Member.
    ///  Will completely replace any existing explicitly assigned roles. See the
    ///  [RBAC guide](https://stytch.com/docs/b2b/guides/rbac/role-assignment) for more information about role
    /// assignment.
    /// 
    ///    If a Role is removed from a Member, and the Member is also implicitly assigned this Role from an SSO
    /// connection
    ///    or an SSO group, we will by default revoke any existing sessions for the Member that contain any SSO
    ///    authentication factors with the affected connection ID. You can preserve these sessions by passing in
    /// the
    ///    `preserve_existing_sessions` parameter with a value of `true`.
    /// </summary>
      [JsonProperty("roles")]
      public string? Roles { get; set; }
      /// <summary>
    /// Whether to preserve existing sessions when explicit Roles that are revoked are also implicitly assigned
    ///   by SSO connection or SSO group. Defaults to `false` - that is, existing Member Sessions that contain
    /// SSO
    ///   authentication factors with the affected SSO connection IDs will be revoked.
    /// </summary>
      [JsonProperty("preserve_existing_sessions")]
      public bool? PreserveExistingSessions { get; set; }
    }
/// <summary>
    /// Response type for `passwords.migrate`.
    /// </summary>
    public class B2BPasswordsMigrateResponse {
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
    /// A flag indicating `true` if a new Member object was created and `false` if the Member object already
    /// existed.
    /// </summary>
      [JsonProperty("member_created")]
      public required bool MemberCreated { get; set; }
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
    /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
    /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
    /// </summary>
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
    }
/// <summary>
    /// Request type for `passwords.strengthCheck`.
    /// </summary>
    public class B2BPasswordsStrengthCheckRequest {
      /// <summary>
    /// The password to authenticate, reset, or set for the first time. Any UTF8 character is allowed, e.g.
    /// spaces, emojis, non-English characers, etc.
    /// </summary>
      [JsonProperty("password")]
      public required string Password { get; set; }
      /// <summary>
    /// The email address of the Member.
    /// </summary>
      [JsonProperty("email_address")]
      public string? EmailAddress { get; set; }
    }
/// <summary>
    /// Response type for `passwords.strengthCheck`.
    /// </summary>
    public class B2BPasswordsStrengthCheckResponse {
      /// <summary>
    /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
    /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    /// </summary>
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      /// <summary>
    /// Returns `true` if the password passes our password validation. We offer two validation options, 
    ///   [zxcvbn](https://stytch.com/docs/passwords#strength-requirements) is the default option which offers a
    /// high level of sophistication. 
    ///   We also offer [LUDS](https://stytch.com/docs/passwords#strength-requirements). If an email address is
    /// included in the call we also 
    ///   require that the password hasn't been compromised using built-in breach detection powered by
    /// [HaveIBeenPwned](https://haveibeenpwned.com/)
    /// </summary>
      [JsonProperty("valid_password")]
      public required bool ValidPassword { get; set; }
      /// <summary>
    /// The score of the password determined by [zxcvbn](https://github.com/dropbox/zxcvbn). Values will be
    /// between 1 and 4, a 3 or greater is required to pass validation.
    /// </summary>
      [JsonProperty("score")]
      public required int Score { get; set; }
      /// <summary>
    /// Returns `true` if the password has been breached. Powered by
    /// [HaveIBeenPwned](https://haveibeenpwned.com/).
    /// </summary>
      [JsonProperty("breached_password")]
      public required bool BreachedPassword { get; set; }
      /// <summary>
    /// The strength policy type enforced, either `zxcvbn` or `luds`.
    /// </summary>
      [JsonProperty("strength_policy")]
      public required string StrengthPolicy { get; set; }
      /// <summary>
    /// Will return `true` if breach detection will be evaluated. By default this option is enabled. 
    ///   This option can be disabled by contacting
    /// [support@stytch.com](mailto:support@stytch.com?subject=Password%20strength%20configuration). 
    ///   If this value is false then `breached_password` will always be `false` as well.
    /// </summary>
      [JsonProperty("breach_detection_on_create")]
      public required bool BreachDetectionOnCreate { get; set; }
      /// <summary>
    /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
    /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
    /// </summary>
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
      /// <summary>
    /// Feedback for how to improve the password's strength using
    /// [luds](https://stytch.com/docs/passwords#strength-requirements).
    /// </summary>
      [JsonProperty("luds_feedback")]
      public LudsFeedback? LudsFeedback { get; set; }
      /// <summary>
    /// Feedback for how to improve the password's strength using
    /// [zxcvbn](https://stytch.com/docs/passwords#strength-requirements).
    /// </summary>
      [JsonProperty("zxcvbn_feedback")]
      public ZxcvbnFeedback? ZxcvbnFeedback { get; set; }
    }

public enum B2BPasswordsAuthenticateRequestLocale
    {
      [EnumMember(Value = "en")]
      EN,
      [EnumMember(Value = "es")]
      ES,
      [EnumMember(Value = "pt-br")]
      PTBR,
    }
public enum B2BPasswordsMigrateRequestHashType
    {
      [EnumMember(Value = "bcrypt")]
      BCRYPT,
      [EnumMember(Value = "md_5")]
      MD_5,
      [EnumMember(Value = "argon_2i")]
      ARGON_2I,
      [EnumMember(Value = "argon_2id")]
      ARGON_2ID,
      [EnumMember(Value = "sha_1")]
      SHA_1,
      [EnumMember(Value = "scrypt")]
      SCRYPT,
      [EnumMember(Value = "phpass")]
      PHPASS,
      [EnumMember(Value = "pbkdf_2")]
      PBKDF_2,
    }
}