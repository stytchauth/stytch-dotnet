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
    public class B2BOAuthProviderValues
    {
        /// <summary>
        /// The OAuth scopes included for a given provider. See each provider's section above to see which scopes
        /// are included by default and how to add custom scopes.
        /// </summary>
        [JsonProperty("scopes")]
        public List<string> Scopes { get; set; }
        /// <summary>
        /// The `access_token` that you may use to access the User's data in the provider's API.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        /// <summary>
        /// The `refresh_token` that you may use to obtain a new `access_token` for the User within the provider's
        /// API.
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        [JsonProperty("expires_at")]
        public string ExpiresAt { get; set; }
        /// <summary>
        /// The `id_token` returned by the OAuth provider. ID Tokens are JWTs that contain structured information
        /// about a user. The exact content of each ID Token varies from provider to provider. ID Tokens are
        /// returned from OAuth providers that conform to the [OpenID Connect](https://openid.net/foundation/)
        /// specification, which is based on OAuth.
        /// </summary>
        [JsonProperty("id_token")]
        public string IdToken { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.OAuth.Authenticate"/>..
    /// </summary>
    public class B2BOAuthAuthenticateRequest
    {
        /// <summary>
        /// The token to authenticate.
        /// </summary>
        [JsonProperty("oauth_token")]
        public string OAuthToken { get; set; }
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
        /// A base64url encoded one time secret used to validate that the request starts and ends on the same device.
        /// </summary>
        [JsonProperty("pkce_code_verifier")]
        public string PkceCodeVerifier { get; set; }
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
        public B2BOAuthAuthenticateRequestLocale Locale { get; set; }
        /// <summary>
        /// Adds this primary authentication factor to the intermediate session token. If the resulting set of
        /// factors satisfies the organization's primary authentication requirements and MFA requirements, the
        /// intermediate session token will be consumed and converted to a member session. If not, the same
        /// intermediate session token will be returned.
        /// </summary>
        [JsonProperty("intermediate_session_token")]
        public string IntermediateSessionToken { get; set; }
        public B2BOAuthAuthenticateRequest(string oauthToken)
        {
            this.OAuthToken = oauthToken;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.OAuth.Authenticate"/>..
    /// </summary>
    public class B2BOAuthAuthenticateResponse
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
        /// The unique identifier for the User within a given OAuth provider. Also commonly called the `sub` or
        /// "Subject field" in OAuth protocols.
        /// </summary>
        [JsonProperty("provider_subject")]
        public string ProviderSubject { get; set; }
        /// <summary>
        /// Denotes the OAuth identity provider that the user has authenticated with, e.g. Google, Microsoft, GitHub
        /// etc.
        /// </summary>
        [JsonProperty("provider_type")]
        public string ProviderType { get; set; }
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
        /// Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
        /// perform operations on an Organization, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
        /// <summary>
        /// The [Organization object](https://stytch.com/docs/b2b/api/organization-object).
        /// </summary>
        [JsonProperty("organization")]
        public Organization Organization { get; set; }
        [JsonProperty("reset_sessions")]
        public bool ResetSessions { get; set; }
        /// <summary>
        /// Indicates whether the Member is fully authenticated. If false, the Member needs to complete an MFA step
        /// to log in to the Organization.
        /// </summary>
        [JsonProperty("member_authenticated")]
        public bool MemberAuthenticated { get; set; }
        /// <summary>
        /// The returned Intermediate Session Token contains an OAuth factor associated with the Member's email
        /// address. If this value is non-empty, the member must complete an MFA step to finish logging in to the
        /// Organization. The token can be used with the
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
        /// The [Session object](https://stytch.com/docs/b2b/api/session-object).
        /// </summary>
        [JsonProperty("member_session")]
        public MemberSession MemberSession { get; set; }
        /// <summary>
        /// The `provider_values` object lists relevant identifiers, values, and scopes for a given OAuth provider.
        /// For example this object will include a provider's `access_token` that you can use to access the
        /// provider's API for a given user.
        /// 
        ///   Note that these values will vary based on the OAuth provider in question, e.g. `id_token` is only
        /// returned by Microsoft. Google One Tap does not return access tokens or refresh tokens.
        /// </summary>
        [JsonProperty("provider_values")]
        public B2BOAuthProviderValues ProviderValues { get; set; }
        /// <summary>
        /// Information about the MFA requirements of the Organization and the Member's options for fulfilling MFA.
        /// </summary>
        [JsonProperty("mfa_required")]
        public MfaRequired MfaRequired { get; set; }
        [JsonProperty("primary_required")]
        public PrimaryRequired PrimaryRequired { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum B2BOAuthAuthenticateRequestLocale
    {
        [EnumMember(Value = "en")]
        EN,
        [EnumMember(Value = "es")]
        ES,
        [EnumMember(Value = "pt-br")]
        PTBR,
    }
}