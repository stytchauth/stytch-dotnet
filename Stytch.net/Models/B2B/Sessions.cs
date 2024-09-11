// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Stytch.net.Models.Consumer
{
public class AuthorizationCheck {
      /**
    * Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
    * perform operations on an Organization, so be sure to preserve this value.
    */
      [JsonProperty("organization_id")]
      public required string OrganizationId { get; set; }
      /**
    * A unique identifier of the RBAC Resource, provided by the developer and intended to be human-readable. 
    *   
    *   A `resource_id` is not allowed to start with `stytch`, which is a special prefix used for Stytch
    * default Resources with reserved  `resource_id`s. These include: 
    *   
    *   * `stytch.organization`
    *   * `stytch.member`
    *   * `stytch.sso`
    *   * `stytch.self`
    *   
    *   Check out the
    * [guide on Stytch default Resources](https://stytch.com/docs/b2b/guides/rbac/stytch-default) for a more
    * detailed explanation.
    * 
    *   
    */
      [JsonProperty("resource_id")]
      public required string ResourceId { get; set; }
      // An action to take on a Resource.
      [JsonProperty("action")]
      public required string Action { get; set; }
    }
public class AuthorizationVerdict {
      [JsonProperty("authorized")]
      public required bool Authorized { get; set; }
      [JsonProperty("granting_roles")]
      public required string GrantingRoles { get; set; }
    }
public class B2BSessionsRevokeRequestOptions {
      /**
    * Optional authorization object.
    * Pass in an active Stytch Member session token or session JWT and the request
    * will be run using that member's permissions.
    */
      [JsonProperty("authorization")]
      public Authorization? Authorization { get; set; }
    }
public class MemberSession {
      // Globally unique UUID that identifies a specific Session.
      [JsonProperty("member_session_id")]
      public required string MemberSessionId { get; set; }
      // Globally unique UUID that identifies a specific Member.
      [JsonProperty("member_id")]
      public required string MemberId { get; set; }
      /**
    * The timestamp when the Session was created. Values conform to the RFC 3339 standard and are expressed in
    * UTC, e.g. `2021-12-29T12:33:09Z`.
    */
      [JsonProperty("started_at")]
      public required string StartedAt { get; set; }
      /**
    * The timestamp when the Session was last accessed. Values conform to the RFC 3339 standard and are
    * expressed in UTC, e.g. `2021-12-29T12:33:09Z`.
    */
      [JsonProperty("last_accessed_at")]
      public required string LastAccessedAt { get; set; }
      /**
    * The timestamp when the Session expires. Values conform to the RFC 3339 standard and are expressed in
    * UTC, e.g. `2021-12-29T12:33:09Z`.
    */
      [JsonProperty("expires_at")]
      public required string ExpiresAt { get; set; }
      // An array of different authentication factors that comprise a Session.
      [JsonProperty("authentication_factors")]
      public required AuthenticationFactor AuthenticationFactors { get; set; }
      /**
    * Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
    * perform operations on an Organization, so be sure to preserve this value.
    */
      [JsonProperty("organization_id")]
      public required string OrganizationId { get; set; }
      [JsonProperty("roles")]
      public required string Roles { get; set; }
      /**
    * The custom claims map for a Session. Claims can be added to a session during a Sessions authenticate
    * call.
    */
      [JsonProperty("custom_claims")]
      public object? CustomClaims { get; set; }
    }
public class PrimaryRequired {
      /**
    * If non-empty, indicates that the Organization restricts the authentication methods it allows for login
    * (such as `sso` or `password`), and the end user must complete one of those authentication methods to log
    * in. If empty, indicates that the Organization does not restrict the authentication method it allows for
    * login, but the end user does not have any transferrable primary factors. Only email magic link and OAuth
    * factors can be transferred between Organizations.
    */
      [JsonProperty("allowed_auth_methods")]
      public required string AllowedAuthMethods { get; set; }
    }
// Request type for `sessions.authenticate`.
    public class B2BSessionsAuthenticateRequest {
      // A secret token for a given Stytch Session.
      [JsonProperty("session_token")]
      public string? SessionToken { get; set; }
      /**
    * Set the session lifetime to be this many minutes from now. This will start a new session if one doesn't
    * already exist, 
    *   returning both an opaque `session_token` and `session_jwt` for this session. Remember that the
    * `session_jwt` will have a fixed lifetime of
    *   five minutes regardless of the underlying session duration, and will need to be refreshed over time.
    * 
    *   This value must be a minimum of 5 and a maximum of 527040 minutes (366 days).
    *   
    *   If a `session_token` or `session_jwt` is provided then a successful authentication will continue to
    * extend the session this many minutes.
    *   
    *   If the `session_duration_minutes` parameter is not specified, a Stytch session will be created with a
    * 60 minute duration. If you don't want
    *   to use the Stytch session product, you can ignore the session fields in the response.
    */
      [JsonProperty("session_duration_minutes")]
      public int? SessionDurationMinutes { get; set; }
      // The JSON Web Token (JWT) for a given Stytch Session.
      [JsonProperty("session_jwt")]
      public string? SessionJwt { get; set; }
      /**
    * Add a custom claims map to the Session being authenticated. Claims are only created if a Session is
    * initialized by providing a value in
    *   `session_duration_minutes`. Claims will be included on the Session object and in the JWT. To update a
    * key in an existing Session, supply a new value. To
    *   delete a key, supply a null value. Custom claims made with reserved claims (`iss`, `sub`, `aud`,
    * `exp`, `nbf`, `iat`, `jti`) will be ignored.
    *   Total custom claims size cannot exceed four kilobytes.
    */
      [JsonProperty("session_custom_claims")]
      public object? SessionCustomClaims { get; set; }
      /**
    * If an `authorization_check` object is passed in, this endpoint will also check if the Member is
    *   authorized to perform the given action on the given Resource in the specified Organization. A Member
    * is authorized if
    *   their Member Session contains a Role, assigned
    *   [explicitly or implicitly](https://stytch.com/docs/b2b/guides/rbac/role-assignment), with adequate
    * permissions.
    *   In addition, the `organization_id` passed in the authorization check must match the Member's
    * Organization.
    *   
    *   The Roles on the Member Session may differ from the Roles you see on the Member object - Roles that
    * are implicitly
    *   assigned by SSO connection or SSO group will only be valid for a Member Session if there is at least
    * one authentication
    *   factor on the Member Session from the specified SSO connection.
    *   
    *   If the Member is not authorized to perform the specified action on the specified Resource, or if the
    *   `organization_id` does not match the Member's Organization, a 403 error will be thrown.
    *   Otherwise, the response will contain a list of Roles that satisfied the authorization check.
    */
      [JsonProperty("authorization_check")]
      public AuthorizationCheck? AuthorizationCheck { get; set; }
    }
// Response type for `sessions.authenticate`.
    public class B2BSessionsAuthenticateResponse {
      /**
    * Globally unique UUID that is returned with every API call. This value is important to log for debugging
    * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    */
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      // The [Session object](https://stytch.com/docs/b2b/api/session-object).
      [JsonProperty("member_session")]
      public required MemberSession MemberSession { get; set; }
      // A secret token for a given Stytch Session.
      [JsonProperty("session_token")]
      public required string SessionToken { get; set; }
      // The JSON Web Token (JWT) for a given Stytch Session.
      [JsonProperty("session_jwt")]
      public required string SessionJwt { get; set; }
      // The [Member object](https://stytch.com/docs/b2b/api/member-object)
      [JsonProperty("member")]
      public required Member Member { get; set; }
      // The [Organization object](https://stytch.com/docs/b2b/api/organization-object).
      [JsonProperty("organization")]
      public required Organization Organization { get; set; }
      /**
    * The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
    * 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
    */
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
      /**
    * If an `authorization_check` is provided in the request and the check succeeds, this field will return
    *   the complete list of Roles that gave the Member permission to perform the specified action on the
    * specified Resource.
    */
      [JsonProperty("verdict")]
      public AuthorizationVerdict? Verdict { get; set; }
    }
// Request type for `sessions.exchange`.
    public class B2BSessionsExchangeRequest {
      /**
    * Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
    * perform operations on an Organization, so be sure to preserve this value.
    */
      [JsonProperty("organization_id")]
      public required string OrganizationId { get; set; }
      // The `session_token` belonging to the member that you wish to associate the email with.
      [JsonProperty("session_token")]
      public string? SessionToken { get; set; }
      // The `session_jwt` belonging to the member that you wish to associate the email with.
      [JsonProperty("session_jwt")]
      public string? SessionJwt { get; set; }
      /**
    * Set the session lifetime to be this many minutes from now. This will start a new session if one doesn't
    * already exist, 
    *   returning both an opaque `session_token` and `session_jwt` for this session. Remember that the
    * `session_jwt` will have a fixed lifetime of
    *   five minutes regardless of the underlying session duration, and will need to be refreshed over time.
    * 
    *   This value must be a minimum of 5 and a maximum of 527040 minutes (366 days).
    *   
    *   If a `session_token` or `session_jwt` is provided then a successful authentication will continue to
    * extend the session this many minutes.
    *   
    *   If the `session_duration_minutes` parameter is not specified, a Stytch session will be created with a
    * 60 minute duration. If you don't want
    *   to use the Stytch session product, you can ignore the session fields in the response.
    */
      [JsonProperty("session_duration_minutes")]
      public int? SessionDurationMinutes { get; set; }
      /**
    * Add a custom claims map to the Session being authenticated. Claims are only created if a Session is
    * initialized by providing a value in
    *   `session_duration_minutes`. Claims will be included on the Session object and in the JWT. To update a
    * key in an existing Session, supply a new value. To
    *   delete a key, supply a null value. Custom claims made with reserved claims (`iss`, `sub`, `aud`,
    * `exp`, `nbf`, `iat`, `jti`) will be ignored.
    *   Total custom claims size cannot exceed four kilobytes.
    */
      [JsonProperty("session_custom_claims")]
      public object? SessionCustomClaims { get; set; }
      /**
    * If the Member needs to complete an MFA step, and the Member has a phone number, this endpoint will
    * pre-emptively send a one-time passcode (OTP) to the Member's phone number. The locale argument will be
    * used to determine which language to use when sending the passcode.
    * 
    * Parameter is a [IETF BCP 47 language tag](https://www.w3.org/International/articles/language-tags/),
    * e.g. `"en"`.
    * 
    * Currently supported languages are English (`"en"`), Spanish (`"es"`), and Brazilian Portuguese
    * (`"pt-br"`); if no value is provided, the copy defaults to English.
    * 
    * Request support for additional languages
    * [here](https://docs.google.com/forms/d/e/1FAIpQLScZSpAu_m2AmLXRT3F3kap-s_mcV6UTBitYn6CdyWP0-o7YjQ/viewform?usp=sf_link")!
    * 
    */
      [JsonProperty("locale")]
      public B2BSessionsExchangeRequestLocale? Locale { get; set; }
    }
// Response type for `sessions.exchange`.
    public class B2BSessionsExchangeResponse {
      /**
    * Globally unique UUID that is returned with every API call. This value is important to log for debugging
    * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    */
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      // Globally unique UUID that identifies a specific Member.
      [JsonProperty("member_id")]
      public required string MemberId { get; set; }
      // The [Session object](https://stytch.com/docs/b2b/api/session-object).
      [JsonProperty("member_session")]
      public required MemberSession MemberSession { get; set; }
      // A secret token for a given Stytch Session.
      [JsonProperty("session_token")]
      public required string SessionToken { get; set; }
      // The JSON Web Token (JWT) for a given Stytch Session.
      [JsonProperty("session_jwt")]
      public required string SessionJwt { get; set; }
      // The [Member object](https://stytch.com/docs/b2b/api/member-object)
      [JsonProperty("member")]
      public required Member Member { get; set; }
      // The [Organization object](https://stytch.com/docs/b2b/api/organization-object).
      [JsonProperty("organization")]
      public required Organization Organization { get; set; }
      /**
    * Indicates whether the Member is fully authenticated. If false, the Member needs to complete an MFA step
    * to log in to the Organization.
    */
      [JsonProperty("member_authenticated")]
      public required bool MemberAuthenticated { get; set; }
      /**
    * The returned Intermediate Session Token contains any Email Magic Link or OAuth factors from the original
    * member session that are valid for the target Organization. If this value is non-empty, the member must
    * complete an MFA step to finish logging in to the Organization. The token can be used with the
    * [OTP SMS Authenticate endpoint](https://stytch.com/docs/b2b/api/authenticate-otp-sms),
    * [TOTP Authenticate endpoint](https://stytch.com/docs/b2b/api/authenticate-totp), or
    * [Recovery Codes Recover endpoint](https://stytch.com/docs/b2b/api/recovery-codes-recover) to complete an
    * MFA flow and log in to the Organization. It can also be used with the
    * [Exchange Intermediate Session endpoint](https://stytch.com/docs/b2b/api/exchange-intermediate-session)
    * to join a specific Organization that allows the factors represented by the intermediate session token;
    * or the
    * [Create Organization via Discovery endpoint](https://stytch.com/docs/b2b/api/create-organization-via-discovery) to create a new Organization and Member.
    */
      [JsonProperty("intermediate_session_token")]
      public required string IntermediateSessionToken { get; set; }
      /**
    * The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
    * 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
    */
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
      // Information about the MFA requirements of the Organization and the Member's options for fulfilling MFA.
      [JsonProperty("mfa_required")]
      public MfaRequired? MfaRequired { get; set; }
      [JsonProperty("primary_required")]
      public PrimaryRequired? PrimaryRequired { get; set; }
    }
// Request type for `sessions.getJWKS`.
    public class B2BSessionsGetJWKSRequest {
      // The `project_id` to get the JWKS for.
      [JsonProperty("project_id")]
      public required string ProjectId { get; set; }
    }
// Response type for `sessions.getJWKS`.
    public class B2BSessionsGetJWKSResponse {
      // The JWK
      [JsonProperty("keys")]
      public required JWK Keys { get; set; }
      /**
    * Globally unique UUID that is returned with every API call. This value is important to log for debugging
    * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    */
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      /**
    * The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
    * 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
    */
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
    }
// Request type for `sessions.get`.
    public class B2BSessionsGetRequest {
      /**
    * Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
    * perform operations on an Organization, so be sure to preserve this value.
    */
      [JsonProperty("organization_id")]
      public required string OrganizationId { get; set; }
      /**
    * Globally unique UUID that identifies a specific Member. The `member_id` is critical to perform
    * operations on a Member, so be sure to preserve this value.
    */
      [JsonProperty("member_id")]
      public required string MemberId { get; set; }
    }
// Response type for `sessions.get`.
    public class B2BSessionsGetResponse {
      /**
    * Globally unique UUID that is returned with every API call. This value is important to log for debugging
    * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    */
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      // An array of [Session objects](https://stytch.com/docs/b2b/api/session-object).
      [JsonProperty("member_sessions")]
      public required MemberSession MemberSessions { get; set; }
      /**
    * The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
    * 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
    */
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
    }
// Request type for `sessions.migrate`.
    public class B2BSessionsMigrateRequest {
      // The authorization token Stytch will pass in to the external userinfo endpoint.
      [JsonProperty("session_token")]
      public required string SessionToken { get; set; }
      /**
    * Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
    * perform operations on an Organization, so be sure to preserve this value.
    */
      [JsonProperty("organization_id")]
      public required string OrganizationId { get; set; }
      /**
    * Set the session lifetime to be this many minutes from now. This will start a new session if one doesn't
    * already exist, 
    *   returning both an opaque `session_token` and `session_jwt` for this session. Remember that the
    * `session_jwt` will have a fixed lifetime of
    *   five minutes regardless of the underlying session duration, and will need to be refreshed over time.
    * 
    *   This value must be a minimum of 5 and a maximum of 527040 minutes (366 days).
    *   
    *   If a `session_token` or `session_jwt` is provided then a successful authentication will continue to
    * extend the session this many minutes.
    *   
    *   If the `session_duration_minutes` parameter is not specified, a Stytch session will be created with a
    * 60 minute duration. If you don't want
    *   to use the Stytch session product, you can ignore the session fields in the response.
    */
      [JsonProperty("session_duration_minutes")]
      public int? SessionDurationMinutes { get; set; }
      /**
    * Add a custom claims map to the Session being authenticated. Claims are only created if a Session is
    * initialized by providing a value in
    *   `session_duration_minutes`. Claims will be included on the Session object and in the JWT. To update a
    * key in an existing Session, supply a new value. To
    *   delete a key, supply a null value. Custom claims made with reserved claims (`iss`, `sub`, `aud`,
    * `exp`, `nbf`, `iat`, `jti`) will be ignored.
    *   Total custom claims size cannot exceed four kilobytes.
    */
      [JsonProperty("session_custom_claims")]
      public object? SessionCustomClaims { get; set; }
    }
// Response type for `sessions.migrate`.
    public class B2BSessionsMigrateResponse {
      /**
    * Globally unique UUID that is returned with every API call. This value is important to log for debugging
    * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    */
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      // Globally unique UUID that identifies a specific Member.
      [JsonProperty("member_id")]
      public required string MemberId { get; set; }
      // A secret token for a given Stytch Session.
      [JsonProperty("session_token")]
      public required string SessionToken { get; set; }
      // The JSON Web Token (JWT) for a given Stytch Session.
      [JsonProperty("session_jwt")]
      public required string SessionJwt { get; set; }
      // The [Member object](https://stytch.com/docs/b2b/api/member-object)
      [JsonProperty("member")]
      public required Member Member { get; set; }
      // The [Organization object](https://stytch.com/docs/b2b/api/organization-object).
      [JsonProperty("organization")]
      public required Organization Organization { get; set; }
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
      // The [Session object](https://stytch.com/docs/b2b/api/session-object).
      [JsonProperty("member_session")]
      public MemberSession? MemberSession { get; set; }
    }
// Request type for `sessions.revoke`.
    public class B2BSessionsRevokeRequest {
      /**
    * Globally unique UUID that identifies a specific Session in the Stytch API. The `member_session_id` is
    * critical to perform operations on an Session, so be sure to preserve this value.
    */
      [JsonProperty("member_session_id")]
      public string? MemberSessionId { get; set; }
      // A secret token for a given Stytch Session.
      [JsonProperty("session_token")]
      public string? SessionToken { get; set; }
      // The JSON Web Token (JWT) for a given Stytch Session.
      [JsonProperty("session_jwt")]
      public string? SessionJwt { get; set; }
      /**
    * Globally unique UUID that identifies a specific Member. The `member_id` is critical to perform
    * operations on a Member, so be sure to preserve this value.
    */
      [JsonProperty("member_id")]
      public string? MemberId { get; set; }
    }
// Response type for `sessions.revoke`.
    public class B2BSessionsRevokeResponse {
      /**
    * Globally unique UUID that is returned with every API call. This value is important to log for debugging
    * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    */
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      /**
    * The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
    * 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
    */
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
    }

public enum B2BSessionsExchangeRequestLocale
    {
      [EnumMember(Value = "en")]
      EN,
      [EnumMember(Value = "es")]
      ES,
      [EnumMember(Value = "pt-br")]
      PTBR,
    }
}