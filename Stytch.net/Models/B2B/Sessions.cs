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
    public class AuthorizationCheck
    {
        /// <summary>
        /// Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
        /// perform operations on an Organization, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
        /// <summary>
        /// A unique identifier of the RBAC Resource, provided by the developer and intended to be human-readable. 
        ///   
        ///   A `resource_id` is not allowed to start with `stytch`, which is a special prefix used for Stytch
        /// default Resources with reserved  `resource_id`s. These include: 
        ///   
        ///   * `stytch.organization`
        ///   * `stytch.member`
        ///   * `stytch.sso`
        ///   * `stytch.self`
        ///   
        ///   Check out the
        /// [guide on Stytch default Resources](https://stytch.com/docs/b2b/guides/rbac/stytch-default) for a more
        /// detailed explanation.
        /// 
        ///   
        /// </summary>
        [JsonProperty("resource_id")]
        public string ResourceId { get; set; }
        /// <summary>
        /// An action to take on a Resource.
        /// </summary>
        [JsonProperty("action")]
        public string Action { get; set; }
    }
    public class AuthorizationVerdict
    {
        [JsonProperty("authorized")]
        public bool Authorized { get; set; }
        [JsonProperty("granting_roles")]
        public List<string> GrantingRoles { get; set; }
    }
    public class B2BSessionsRevokeRequestOptions
    {
        /// <summary>
        /// Optional authorization object.
        /// Pass in an active Stytch Member session token or session JWT and the request
        /// will be run using that member's permissions.
        /// </summary>
        [JsonProperty("authorization")]
        public Authorization Authorization { get; set; }
    }
    public class MemberSession
    {
        /// <summary>
        /// Globally unique UUID that identifies a specific Session.
        /// </summary>
        [JsonProperty("member_session_id")]
        public string MemberSessionId { get; set; }
        /// <summary>
        /// Globally unique UUID that identifies a specific Member.
        /// </summary>
        [JsonProperty("member_id")]
        public string MemberId { get; set; }
        /// <summary>
        /// The timestamp when the Session was created. Values conform to the RFC 3339 standard and are expressed in
        /// UTC, e.g. `2021-12-29T12:33:09Z`.
        /// </summary>
        [JsonProperty("started_at")]
        public DateTime StartedAt { get; set; }
        /// <summary>
        /// The timestamp when the Session was last accessed. Values conform to the RFC 3339 standard and are
        /// expressed in UTC, e.g. `2021-12-29T12:33:09Z`.
        /// </summary>
        [JsonProperty("last_accessed_at")]
        public DateTime LastAccessedAt { get; set; }
        /// <summary>
        /// The timestamp when the Session expires. Values conform to the RFC 3339 standard and are expressed in
        /// UTC, e.g. `2021-12-29T12:33:09Z`.
        /// </summary>
        [JsonProperty("expires_at")]
        public DateTime ExpiresAt { get; set; }
        /// <summary>
        /// An array of different authentication factors that comprise a Session.
        /// </summary>
        [JsonProperty("authentication_factors")]
        public List<AuthenticationFactor> AuthenticationFactors { get; set; }
        /// <summary>
        /// Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
        /// perform operations on an Organization, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
        [JsonProperty("roles")]
        public List<string> Roles { get; set; }
        /// <summary>
        /// The custom claims map for a Session. Claims can be added to a session during a Sessions authenticate
        /// call.
        /// </summary>
        [JsonProperty("custom_claims")]
        public object CustomClaims { get; set; }
    }
    public class PrimaryRequired
    {
        /// <summary>
        /// If non-empty, indicates that the Organization restricts the authentication methods it allows for login
        /// (such as `sso` or `password`), and the end user must complete one of those authentication methods to log
        /// in. If empty, indicates that the Organization does not restrict the authentication method it allows for
        /// login, but the end user does not have any transferrable primary factors. Only email magic link and OAuth
        /// factors can be transferred between Organizations.
        /// </summary>
        [JsonProperty("allowed_auth_methods")]
        public List<string> AllowedAuthMethods { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.Sessions.Authenticate"/>..
    /// </summary>
    public class B2BSessionsAuthenticateRequest
    {
        /// <summary>
        /// A secret token for a given Stytch Session.
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
        public string SessionJwt { get; set; }
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
        /// If an `authorization_check` object is passed in, this endpoint will also check if the Member is
        ///   authorized to perform the given action on the given Resource in the specified Organization. A Member
        /// is authorized if
        ///   their Member Session contains a Role, assigned
        ///   [explicitly or implicitly](https://stytch.com/docs/b2b/guides/rbac/role-assignment), with adequate
        /// permissions.
        ///   In addition, the `organization_id` passed in the authorization check must match the Member's
        /// Organization.
        ///   
        ///   The Roles on the Member Session may differ from the Roles you see on the Member object - Roles that
        /// are implicitly
        ///   assigned by SSO connection or SSO group will only be valid for a Member Session if there is at least
        /// one authentication
        ///   factor on the Member Session from the specified SSO connection.
        ///   
        ///   If the Member is not authorized to perform the specified action on the specified Resource, or if the
        ///   `organization_id` does not match the Member's Organization, a 403 error will be thrown.
        ///   Otherwise, the response will contain a list of Roles that satisfied the authorization check.
        /// </summary>
        [JsonProperty("authorization_check")]
        public AuthorizationCheck AuthorizationCheck { get; set; }
        public B2BSessionsAuthenticateRequest()
        {
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.Sessions.Authenticate"/>..
    /// </summary>
    public class B2BSessionsAuthenticateResponse
    {
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        /// <summary>
        /// The [Session object](https://stytch.com/docs/b2b/api/session-object).
        /// </summary>
        [JsonProperty("member_session")]
        public MemberSession MemberSession { get; set; }
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
        /// <summary>
        /// If an `authorization_check` is provided in the request and the check succeeds, this field will return
        ///   the complete list of Roles that gave the Member permission to perform the specified action on the
        /// specified Resource.
        /// </summary>
        [JsonProperty("verdict")]
        public AuthorizationVerdict Verdict { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.Sessions.Exchange"/>..
    /// </summary>
    public class B2BSessionsExchangeRequest
    {
        /// <summary>
        /// Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
        /// perform operations on an Organization, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
        /// <summary>
        /// The `session_token` belonging to the member that you wish to associate the email with.
        /// </summary>
        [JsonProperty("session_token")]
        public string SessionToken { get; set; }
        /// <summary>
        /// The `session_jwt` belonging to the member that you wish to associate the email with.
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
        public B2BSessionsExchangeRequestLocale Locale { get; set; }
        public B2BSessionsExchangeRequest(string organizationId)
        {
            this.OrganizationId = organizationId;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.Sessions.Exchange"/>..
    /// </summary>
    public class B2BSessionsExchangeResponse
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
        /// The [Session object](https://stytch.com/docs/b2b/api/session-object).
        /// </summary>
        [JsonProperty("member_session")]
        public MemberSession MemberSession { get; set; }
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
        /// Indicates whether the Member is fully authenticated. If false, the Member needs to complete an MFA step
        /// to log in to the Organization.
        /// </summary>
        [JsonProperty("member_authenticated")]
        public bool MemberAuthenticated { get; set; }
        /// <summary>
        /// The returned Intermediate Session Token contains any Email Magic Link or OAuth factors from the original
        /// member session that are valid for the target Organization. If this value is non-empty, the member must
        /// complete an MFA step to finish logging in to the Organization. The token can be used with the
        /// [OTP SMS Authenticate endpoint](https://stytch.com/docs/b2b/api/authenticate-otp-sms),
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
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
        /// <summary>
        /// Information about the MFA requirements of the Organization and the Member's options for fulfilling MFA.
        /// </summary>
        [JsonProperty("mfa_required")]
        public MfaRequired MfaRequired { get; set; }
        [JsonProperty("primary_required")]
        public PrimaryRequired PrimaryRequired { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.Sessions.GetJWKS"/>., <see
    /// cref="Stytch.net.Clients.Consumer.Sessions.GetJWKS"/>..
    /// </summary>
    public class B2BSessionsGetJWKSRequest
    {
        /// <summary>
        /// The `project_id` to get the JWKS for.
        /// </summary>
        [JsonProperty("project_id")]
        public string ProjectId { get; set; }
        public B2BSessionsGetJWKSRequest(string projectId)
        {
            this.ProjectId = projectId;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.Sessions.GetJWKS"/>., <see
    /// cref="Stytch.net.Clients.Consumer.Sessions.GetJWKS"/>..
    /// </summary>
    public class B2BSessionsGetJWKSResponse
    {
        /// <summary>
        /// The JWK
        /// </summary>
        [JsonProperty("keys")]
        public List<JWK> Keys { get; set; }
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        /// <summary>
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.Sessions.Get"/>..
    /// </summary>
    public class B2BSessionsGetRequest
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
        public B2BSessionsGetRequest(string organizationId, string memberId)
        {
            this.OrganizationId = organizationId;
            this.MemberId = memberId;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.Sessions.Get"/>..
    /// </summary>
    public class B2BSessionsGetResponse
    {
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        /// <summary>
        /// An array of [Session objects](https://stytch.com/docs/b2b/api/session-object).
        /// </summary>
        [JsonProperty("member_sessions")]
        public List<MemberSession> MemberSessions { get; set; }
        /// <summary>
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.Sessions.Migrate"/>..
    /// </summary>
    public class B2BSessionsMigrateRequest
    {
        /// <summary>
        /// The authorization token Stytch will pass in to the external userinfo endpoint.
        /// </summary>
        [JsonProperty("session_token")]
        public string SessionToken { get; set; }
        /// <summary>
        /// Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
        /// perform operations on an Organization, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
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
        public B2BSessionsMigrateRequest(string sessionToken, string organizationId)
        {
            this.SessionToken = sessionToken;
            this.OrganizationId = organizationId;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.Sessions.Migrate"/>..
    /// </summary>
    public class B2BSessionsMigrateResponse
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
        /// The [Member object](https://stytch.com/docs/b2b/api/member-object)
        /// </summary>
        [JsonProperty("member")]
        public Member Member { get; set; }
        /// <summary>
        /// The [Organization object](https://stytch.com/docs/b2b/api/organization-object).
        /// </summary>
        [JsonProperty("organization")]
        public Organization Organization { get; set; }
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
        /// <summary>
        /// The [Session object](https://stytch.com/docs/b2b/api/session-object).
        /// </summary>
        [JsonProperty("member_session")]
        public MemberSession MemberSession { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.Sessions.Revoke"/>..
    /// </summary>
    public class B2BSessionsRevokeRequest
    {
        /// <summary>
        /// Globally unique UUID that identifies a specific Session in the Stytch API. The `member_session_id` is
        /// critical to perform operations on an Session, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("member_session_id")]
        public string MemberSessionId { get; set; }
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
        /// Globally unique UUID that identifies a specific Member. The `member_id` is critical to perform
        /// operations on a Member, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("member_id")]
        public string MemberId { get; set; }
        public B2BSessionsRevokeRequest()
        {
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.Sessions.Revoke"/>..
    /// </summary>
    public class B2BSessionsRevokeResponse
    {
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        /// <summary>
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
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