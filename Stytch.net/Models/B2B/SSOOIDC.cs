// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Stytch.net.Models.Consumer
{
    public class B2BSSOOIDCCreateConnectionRequestOptions
    {
        /// <summary>
        /// Optional authorization object.
        /// Pass in an active Stytch Member session token or session JWT and the request
        /// will be run using that member's permissions.
        /// </summary>
        [JsonProperty("authorization")]
        public Authorization? Authorization { get; set; }
    }
    public class B2BSSOOIDCUpdateConnectionRequestOptions
    {
        /// <summary>
        /// Optional authorization object.
        /// Pass in an active Stytch Member session token or session JWT and the request
        /// will be run using that member's permissions.
        /// </summary>
        [JsonProperty("authorization")]
        public Authorization? Authorization { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.SSO.OIDC.CreateConnection"/>..
    /// </summary>
    public class B2BSSOOIDCCreateConnectionRequest
    {
        /// <summary>
        /// Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
        /// perform operations on an Organization, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("organization_id")]
        public required string OrganizationId { get; set; }
        /// <summary>
        /// A human-readable display name for the connection.
        /// </summary>
        [JsonProperty("display_name")]
        public string? DisplayName { get; set; }
        /// <summary>
        /// The identity provider of this connection. For OIDC, the accepted values are `generic`, `okta`, and
        /// `microsoft-entra`. For SAML, the accepted values are `generic`, `okta`, `microsoft-entra`, and
        /// `google-workspace`.
        /// </summary>
        [JsonProperty("identity_provider")]
        public B2BSSOOIDCCreateConnectionRequestIdentityProvider? IdentityProvider { get; set; }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.SSO.OIDC.CreateConnection"/>..
    /// </summary>
    public class B2BSSOOIDCCreateConnectionResponse
    {
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public required string RequestId { get; set; }
        /// <summary>
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public required int StatusCode { get; set; }
        /// <summary>
        /// The `OIDC Connection` object affected by this API call. See the
        /// [OIDC Connection Object](https://stytch.com/docs/b2b/api/oidc-connection-object) for complete response
        /// field details.
        /// </summary>
        [JsonProperty("connection")]
        public OIDCConnection? Connection { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.SSO.OIDC.UpdateConnection"/>..
    /// </summary>
    public class B2BSSOOIDCUpdateConnectionRequest
    {
        /// <summary>
        /// Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
        /// perform operations on an Organization, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("organization_id")]
        public required string OrganizationId { get; set; }
        /// <summary>
        /// Globally unique UUID that identifies a specific SSO `connection_id` for a Member.
        /// </summary>
        [JsonProperty("connection_id")]
        public required string ConnectionId { get; set; }
        /// <summary>
        /// A human-readable display name for the connection.
        /// </summary>
        [JsonProperty("display_name")]
        public string? DisplayName { get; set; }
        /// <summary>
        /// The OAuth2.0 client ID used to authenticate login attempts. This will be provided by the IdP.
        /// </summary>
        [JsonProperty("client_id")]
        public string? ClientId { get; set; }
        /// <summary>
        /// The secret belonging to the OAuth2.0 client used to authenticate login attempts. This will be provided
        /// by the IdP.
        /// </summary>
        [JsonProperty("client_secret")]
        public string? ClientSecret { get; set; }
        /// <summary>
        /// A case-sensitive `https://` URL that uniquely identifies the IdP. This will be provided by the IdP.
        /// </summary>
        [JsonProperty("issuer")]
        public string? Issuer { get; set; }
        /// <summary>
        /// The location of the URL that starts an OAuth login at the IdP. This will be provided by the IdP.
        /// </summary>
        [JsonProperty("authorization_url")]
        public string? AuthorizationURL { get; set; }
        /// <summary>
        /// The location of the URL that issues OAuth2.0 access tokens and OIDC ID tokens. This will be provided by
        /// the IdP.
        /// </summary>
        [JsonProperty("token_url")]
        public string? TokenURL { get; set; }
        /// <summary>
        /// The location of the IDP's
        /// [UserInfo Endpoint](https://openid.net/specs/openid-connect-core-1_0.html#UserInfo). This will be
        /// provided by the IdP.
        /// </summary>
        [JsonProperty("userinfo_url")]
        public string? UserinfoURL { get; set; }
        /// <summary>
        /// The location of the IdP's JSON Web Key Set, used to verify credentials issued by the IdP. This will be
        /// provided by the IdP.
        /// </summary>
        [JsonProperty("jwks_url")]
        public string? JWKSURL { get; set; }
        /// <summary>
        /// The identity provider of this connection. For OIDC, the accepted values are `generic`, `okta`, and
        /// `microsoft-entra`. For SAML, the accepted values are `generic`, `okta`, `microsoft-entra`, and
        /// `google-workspace`.
        /// </summary>
        [JsonProperty("identity_provider")]
        public B2BSSOOIDCUpdateConnectionRequestIdentityProvider? IdentityProvider { get; set; }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.SSO.OIDC.UpdateConnection"/>..
    /// </summary>
    public class B2BSSOOIDCUpdateConnectionResponse
    {
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public required string RequestId { get; set; }
        /// <summary>
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public required int StatusCode { get; set; }
        /// <summary>
        /// The `OIDC Connection` object affected by this API call. See the
        /// [OIDC Connection Object](https://stytch.com/docs/b2b/api/oidc-connection-object) for complete response
        /// field details.
        /// </summary>
        [JsonProperty("connection")]
        public OIDCConnection? Connection { get; set; }
        /// <summary>
        /// If it is not possible to resolve the well-known metadata document from the OIDC issuer, this field will
        /// explain what went wrong if the request is successful otherwise. In other words, even if the overall
        /// request succeeds, there could be relevant warnings related to the connection update.
        /// </summary>
        [JsonProperty("warning")]
        public string? Warning { get; set; }
    }

    public enum B2BSSOOIDCCreateConnectionRequestIdentityProvider
    {
        [EnumMember(Value = "generic")]
        GENERIC,
        [EnumMember(Value = "okta")]
        OKTA,
        [EnumMember(Value = "microsoft-entra")]
        MICROSOFTENTRA,
        [EnumMember(Value = "google-workspace")]
        GOOGLEWORKSPACE,
    }
    public enum B2BSSOOIDCUpdateConnectionRequestIdentityProvider
    {
        [EnumMember(Value = "generic")]
        GENERIC,
        [EnumMember(Value = "okta")]
        OKTA,
        [EnumMember(Value = "microsoft-entra")]
        MICROSOFTENTRA,
        [EnumMember(Value = "google-workspace")]
        GOOGLEWORKSPACE,
    }
}