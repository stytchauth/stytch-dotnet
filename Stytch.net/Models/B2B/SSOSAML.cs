// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Stytch.net.Models.Consumer
{
    public class B2BSSOSAMLCreateConnectionRequestOptions
    {
        /// <summary>
        /// Optional authorization object.
        /// Pass in an active Stytch Member session token or session JWT and the request
        /// will be run using that member's permissions.
        /// </summary>
        [JsonProperty("authorization")]
        public Authorization? Authorization { get; set; }
    }
    public class B2BSSOSAMLDeleteVerificationCertificateRequestOptions
    {
        /// <summary>
        /// Optional authorization object.
        /// Pass in an active Stytch Member session token or session JWT and the request
        /// will be run using that member's permissions.
        /// </summary>
        [JsonProperty("authorization")]
        public Authorization? Authorization { get; set; }
    }
    public class B2BSSOSAMLUpdateByURLRequestOptions
    {
        /// <summary>
        /// Optional authorization object.
        /// Pass in an active Stytch Member session token or session JWT and the request
        /// will be run using that member's permissions.
        /// </summary>
        [JsonProperty("authorization")]
        public Authorization? Authorization { get; set; }
    }
    public class B2BSSOSAMLUpdateConnectionRequestOptions
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
    /// Request type for <see cref="Stytch.net.Clients.B2B.SSO.SAML.CreateConnection"/>..
    /// </summary>
    public class B2BSSOSAMLCreateConnectionRequest
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
        public B2BSSOSAMLCreateConnectionRequestIdentityProvider? IdentityProvider { get; set; }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.SSO.SAML.CreateConnection"/>..
    /// </summary>
    public class B2BSSOSAMLCreateConnectionResponse
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
        /// The `SAML Connection` object affected by this API call. See the
        /// [SAML Connection Object](https://stytch.com/docs/b2b/api/saml-connection-object) for complete response
        /// field details.
        /// </summary>
        [JsonProperty("connection")]
        public SAMLConnection? Connection { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.SSO.SAML.DeleteVerificationCertificate"/>..
    /// </summary>
    public class B2BSSOSAMLDeleteVerificationCertificateRequest
    {
        /// <summary>
        /// The organization ID that the SAML connection belongs to.
        /// </summary>
        [JsonProperty("organization_id")]
        public required string OrganizationId { get; set; }
        /// <summary>
        /// The ID of the SAML connection.
        /// </summary>
        [JsonProperty("connection_id")]
        public required string ConnectionId { get; set; }
        /// <summary>
        /// The ID of the certificate to be deleted.
        /// </summary>
        [JsonProperty("certificate_id")]
        public required string CertificateId { get; set; }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.SSO.SAML.DeleteVerificationCertificate"/>..
    /// </summary>
    public class B2BSSOSAMLDeleteVerificationCertificateResponse
    {
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public required string RequestId { get; set; }
        /// <summary>
        /// The ID of the certificate that was deleted.
        /// </summary>
        [JsonProperty("certificate_id")]
        public required string CertificateId { get; set; }
        /// <summary>
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public required int StatusCode { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.SSO.SAML.UpdateByURL"/>..
    /// </summary>
    public class B2BSSOSAMLUpdateByURLRequest
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
        /// A URL that points to the IdP metadata. This will be provided by the IdP.
        /// </summary>
        [JsonProperty("metadata_url")]
        public required string MetadataURL { get; set; }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.SSO.SAML.UpdateByURL"/>..
    /// </summary>
    public class B2BSSOSAMLUpdateByURLResponse
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
        /// The `SAML Connection` object affected by this API call. See the
        /// [SAML Connection Object](https://stytch.com/docs/b2b/api/saml-connection-object) for complete response
        /// field details.
        /// </summary>
        [JsonProperty("connection")]
        public SAMLConnection? Connection { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.SSO.SAML.UpdateConnection"/>..
    /// </summary>
    public class B2BSSOSAMLUpdateConnectionRequest
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
        /// A globally unique name for the IdP. This will be provided by the IdP.
        /// </summary>
        [JsonProperty("idp_entity_id")]
        public string? IdpEntityId { get; set; }
        /// <summary>
        /// A human-readable display name for the connection.
        /// </summary>
        [JsonProperty("display_name")]
        public string? DisplayName { get; set; }
        /// <summary>
        /// An object that represents the attributes used to identify a Member. This object will map the IdP-defined
        /// User attributes to Stytch-specific values. Required attributes: `email` and one of `full_name` or
        /// `first_name` and `last_name`.
        /// </summary>
        [JsonProperty("attribute_mapping")]
        public object? AttributeMapping { get; set; }
        /// <summary>
        /// A certificate that Stytch will use to verify the sign-in assertion sent by the IdP, in
        /// [PEM](https://en.wikipedia.org/wiki/Privacy-Enhanced_Mail) format. See our
        /// [X509 guide](https://stytch.com/docs/b2b/api/saml-certificates) for more info.
        /// </summary>
        [JsonProperty("x509_certificate")]
        public string? X509Certificate { get; set; }
        /// <summary>
        /// The URL for which assertions for login requests will be sent. This will be provided by the IdP.
        /// </summary>
        [JsonProperty("idp_sso_url")]
        public string? IdpSSOURL { get; set; }
        /// <summary>
        /// All Members who log in with this SAML connection will implicitly receive the specified Roles. See the
        /// [RBAC guide](https://stytch.com/docs/b2b/guides/rbac/role-assignment) for more information about role
        /// assignment.
        /// </summary>
        [JsonProperty("saml_connection_implicit_role_assignments")]
        public SAMLConnectionImplicitRoleAssignment? SAMLConnectionImplicitRoleAssignments { get; set; }
        /// <summary>
        /// Defines the names of the SAML groups
        ///  that grant specific role assignments. For each group-Role pair, if a Member logs in with this SAML
        /// connection and
        ///  belongs to the specified SAML group, they will be granted the associated Role. See the
        ///  [RBAC guide](https://stytch.com/docs/b2b/guides/rbac/role-assignment) for more information about role
        /// assignment.
        ///          Before adding any group implicit role assignments, you must add a "groups" key to your SAML
        /// connection's
        ///          `attribute_mapping`. Make sure that your IdP is configured to correctly send the group
        /// information.
        /// </summary>
        [JsonProperty("saml_group_implicit_role_assignments")]
        public SAMLGroupImplicitRoleAssignment? SAMLGroupImplicitRoleAssignments { get; set; }
        /// <summary>
        /// An alternative URL to use for the Audience Restriction. This value can be used when you wish to migrate
        /// an existing SAML integration to Stytch with zero downtime.
        /// </summary>
        [JsonProperty("alternative_audience_uri")]
        public string? AlternativeAudienceUri { get; set; }
        /// <summary>
        /// The identity provider of this connection. For OIDC, the accepted values are `generic`, `okta`, and
        /// `microsoft-entra`. For SAML, the accepted values are `generic`, `okta`, `microsoft-entra`, and
        /// `google-workspace`.
        /// </summary>
        [JsonProperty("identity_provider")]
        public B2BSSOSAMLUpdateConnectionRequestIdentityProvider? IdentityProvider { get; set; }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.SSO.SAML.UpdateConnection"/>..
    /// </summary>
    public class B2BSSOSAMLUpdateConnectionResponse
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
        /// The `SAML Connection` object affected by this API call. See the
        /// [SAML Connection Object](https://stytch.com/docs/b2b/api/saml-connection-object) for complete response
        /// field details.
        /// </summary>
        [JsonProperty("connection")]
        public SAMLConnection? Connection { get; set; }
    }

    public enum B2BSSOSAMLCreateConnectionRequestIdentityProvider
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
    public enum B2BSSOSAMLUpdateConnectionRequestIdentityProvider
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