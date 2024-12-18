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
    public class B2BSCIMConnectionCreateRequestOptions
    {
        /// <summary>
        /// Optional authorization object.
        /// Pass in an active Stytch Member session token or session JWT and the request
        /// will be run using that member's permissions.
        /// </summary>
        [JsonProperty("authorization")]
        public Authorization Authorization { get; set; }
    }
    public class B2BSCIMConnectionDeleteRequestOptions
    {
        /// <summary>
        /// Optional authorization object.
        /// Pass in an active Stytch Member session token or session JWT and the request
        /// will be run using that member's permissions.
        /// </summary>
        [JsonProperty("authorization")]
        public Authorization Authorization { get; set; }
    }
    public class B2BSCIMConnectionGetGroupsRequestOptions
    {
        /// <summary>
        /// Optional authorization object.
        /// Pass in an active Stytch Member session token or session JWT and the request
        /// will be run using that member's permissions.
        /// </summary>
        [JsonProperty("authorization")]
        public Authorization Authorization { get; set; }
    }
    public class B2BSCIMConnectionGetRequestOptions
    {
        /// <summary>
        /// Optional authorization object.
        /// Pass in an active Stytch Member session token or session JWT and the request
        /// will be run using that member's permissions.
        /// </summary>
        [JsonProperty("authorization")]
        public Authorization Authorization { get; set; }
    }
    public class B2BSCIMConnectionRotateCancelRequestOptions
    {
        /// <summary>
        /// Optional authorization object.
        /// Pass in an active Stytch Member session token or session JWT and the request
        /// will be run using that member's permissions.
        /// </summary>
        [JsonProperty("authorization")]
        public Authorization Authorization { get; set; }
    }
    public class B2BSCIMConnectionRotateCompleteRequestOptions
    {
        /// <summary>
        /// Optional authorization object.
        /// Pass in an active Stytch Member session token or session JWT and the request
        /// will be run using that member's permissions.
        /// </summary>
        [JsonProperty("authorization")]
        public Authorization Authorization { get; set; }
    }
    public class B2BSCIMConnectionRotateStartRequestOptions
    {
        /// <summary>
        /// Optional authorization object.
        /// Pass in an active Stytch Member session token or session JWT and the request
        /// will be run using that member's permissions.
        /// </summary>
        [JsonProperty("authorization")]
        public Authorization Authorization { get; set; }
    }
    public class B2BSCIMConnectionUpdateRequestOptions
    {
        /// <summary>
        /// Optional authorization object.
        /// Pass in an active Stytch Member session token or session JWT and the request
        /// will be run using that member's permissions.
        /// </summary>
        [JsonProperty("authorization")]
        public Authorization Authorization { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.SCIM.Connection.Create"/>..
    /// </summary>
    public class B2BSCIMConnectionCreateRequest
    {
        /// <summary>
        /// Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
        /// perform operations on an Organization, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
        /// <summary>
        /// A human-readable display name for the connection.
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        [JsonProperty("identity_provider")]
        public CreateRequestIdentityProvider IdentityProvider { get; set; }
        public B2BSCIMConnectionCreateRequest(string organizationId)
        {
            this.OrganizationId = organizationId;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.SCIM.Connection.Create"/>..
    /// </summary>
    public class B2BSCIMConnectionCreateResponse
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
        /// <summary>
        /// The `SCIM Connection` object affected by this API call. See the
        /// [SCIM Connection Object](https://stytch.com/docs/b2b/api/scim-connection-object) for complete response
        /// field details.
        /// </summary>
        [JsonProperty("connection")]
        public SCIMConnectionWithToken Connection { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.SCIM.Connection.Delete"/>..
    /// </summary>
    public class B2BSCIMConnectionDeleteRequest
    {
        /// <summary>
        /// Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
        /// perform operations on an Organization, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
        /// <summary>
        /// The ID of the SCIM connection.
        /// </summary>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }
        public B2BSCIMConnectionDeleteRequest(string organizationId, string connectionId)
        {
            this.OrganizationId = organizationId;
            this.ConnectionId = connectionId;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.SCIM.Connection.Delete"/>..
    /// </summary>
    public class B2BSCIMConnectionDeleteResponse
    {
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        /// <summary>
        /// The `connection_id` that was deleted as part of the delete request.
        /// </summary>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }
        /// <summary>
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.SCIM.Connection.GetGroups"/>..
    /// </summary>
    public class B2BSCIMConnectionGetGroupsRequest
    {
        /// <summary>
        /// Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
        /// perform operations on an Organization, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
        /// <summary>
        /// The ID of the SCIM connection.
        /// </summary>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }
        /// <summary>
        /// The `cursor` field allows you to paginate through your results. Each result array is limited to 1000
        /// results. If your query returns more than 1000 results, you will need to paginate the responses using the
        /// `cursor`. If you receive a response that includes a non-null `next_cursor` in the `results_metadata`
        /// object, repeat the search call with the `next_cursor` value set to the `cursor` field to retrieve the
        /// next page of results. Continue to make search calls until the `next_cursor` in the response is null.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; set; }
        /// <summary>
        /// The number of search results to return per page. The default limit is 100. A maximum of 1000 results can
        /// be returned by a single search request. If the total size of your result set is greater than one page
        /// size, you must paginate the response. See the `cursor` field.
        /// </summary>
        [JsonProperty("limit")]
        public uint? Limit { get; set; }
        public B2BSCIMConnectionGetGroupsRequest(string organizationId, string connectionId)
        {
            this.OrganizationId = organizationId;
            this.ConnectionId = connectionId;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.SCIM.Connection.GetGroups"/>..
    /// </summary>
    public class B2BSCIMConnectionGetGroupsResponse
    {
        /// <summary>
        /// A list of SCIM Connection Groups belonging to the connection.
        /// </summary>
        [JsonProperty("scim_groups")]
        public List<SCIMGroup> SCIMGroups { get; set; }
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
        /// <summary>
        /// The `next_cursor` string is returned when your search result contains more than one page of results.
        /// This value is passed into your next search call in the `cursor` field.
        /// </summary>
        [JsonProperty("next_cursor")]
        public string NextCursor { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.SCIM.Connection.Get"/>..
    /// </summary>
    public class B2BSCIMConnectionGetRequest
    {
        /// <summary>
        /// Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
        /// perform operations on an Organization, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
        public B2BSCIMConnectionGetRequest(string organizationId)
        {
            this.OrganizationId = organizationId;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.SCIM.Connection.Get"/>..
    /// </summary>
    public class B2BSCIMConnectionGetResponse
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
        [JsonProperty("connection")]
        public SCIMConnection Connection { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.SCIM.Connection.RotateCancel"/>..
    /// </summary>
    public class B2BSCIMConnectionRotateCancelRequest
    {
        /// <summary>
        /// Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
        /// perform operations on an Organization, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
        /// <summary>
        /// The ID of the SCIM connection.
        /// </summary>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }
        public B2BSCIMConnectionRotateCancelRequest(string organizationId, string connectionId)
        {
            this.OrganizationId = organizationId;
            this.ConnectionId = connectionId;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.SCIM.Connection.RotateCancel"/>..
    /// </summary>
    public class B2BSCIMConnectionRotateCancelResponse
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
        /// <summary>
        /// The `SCIM Connection` object affected by this API call. See the
        /// [SCIM Connection Object](https://stytch.com/docs/b2b/api/scim-connection-object) for complete response
        /// field details.
        /// </summary>
        [JsonProperty("connection")]
        public SCIMConnection Connection { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.SCIM.Connection.RotateComplete"/>..
    /// </summary>
    public class B2BSCIMConnectionRotateCompleteRequest
    {
        /// <summary>
        /// Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
        /// perform operations on an Organization, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
        /// <summary>
        /// The ID of the SCIM connection.
        /// </summary>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }
        public B2BSCIMConnectionRotateCompleteRequest(string organizationId, string connectionId)
        {
            this.OrganizationId = organizationId;
            this.ConnectionId = connectionId;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.SCIM.Connection.RotateComplete"/>..
    /// </summary>
    public class B2BSCIMConnectionRotateCompleteResponse
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
        /// <summary>
        /// The `SCIM Connection` object affected by this API call. See the
        /// [SCIM Connection Object](https://stytch.com/docs/b2b/api/scim-connection-object) for complete response
        /// field details.
        /// </summary>
        [JsonProperty("connection")]
        public SCIMConnection Connection { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.SCIM.Connection.RotateStart"/>..
    /// </summary>
    public class B2BSCIMConnectionRotateStartRequest
    {
        /// <summary>
        /// Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
        /// perform operations on an Organization, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
        /// <summary>
        /// The ID of the SCIM connection.
        /// </summary>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }
        public B2BSCIMConnectionRotateStartRequest(string organizationId, string connectionId)
        {
            this.OrganizationId = organizationId;
            this.ConnectionId = connectionId;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.SCIM.Connection.RotateStart"/>..
    /// </summary>
    public class B2BSCIMConnectionRotateStartResponse
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
        /// <summary>
        /// The `SCIM Connection` object affected by this API call. See the
        /// [SCIM Connection Object](https://stytch.com/docs/b2b/api/scim-connection-object) for complete response
        /// field details.
        /// </summary>
        [JsonProperty("connection")]
        public SCIMConnectionWithNextToken Connection { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.SCIM.Connection.Update"/>..
    /// </summary>
    public class B2BSCIMConnectionUpdateRequest
    {
        /// <summary>
        /// Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
        /// perform operations on an Organization, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
        /// <summary>
        /// The ID of the SCIM connection.
        /// </summary>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }
        /// <summary>
        /// A human-readable display name for the connection.
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        [JsonProperty("identity_provider")]
        public UpdateRequestIdentityProvider IdentityProvider { get; set; }
        /// <summary>
        /// An array of SCIM group implicit role assignments. Each object in the array must contain a `group_id` and
        /// a `role_id`.
        /// </summary>
        [JsonProperty("scim_group_implicit_role_assignments")]
        public List<SCIMGroupImplicitRoleAssignments> SCIMGroupImplicitRoleAssignments { get; set; }
        public B2BSCIMConnectionUpdateRequest(string organizationId, string connectionId)
        {
            this.OrganizationId = organizationId;
            this.ConnectionId = connectionId;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.SCIM.Connection.Update"/>..
    /// </summary>
    public class B2BSCIMConnectionUpdateResponse
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
        /// <summary>
        /// The `SAML Connection` object affected by this API call. See the
        /// [SAML Connection Object](https://stytch.com/docs/b2b/api/saml-connection-object) for complete response
        /// field details.
        /// </summary>
        [JsonProperty("connection")]
        public SCIMConnection Connection { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum CreateRequestIdentityProvider
    {
        [EnumMember(Value = "generic")]
        GENERIC,
        [EnumMember(Value = "okta")]
        OKTA,
        [EnumMember(Value = "microsoft-entra")]
        MICROSOFTENTRA,
        [EnumMember(Value = "cyberark")]
        CYBERARK,
        [EnumMember(Value = "jumpcloud")]
        JUMPCLOUD,
        [EnumMember(Value = "onelogin")]
        ONELOGIN,
        [EnumMember(Value = "pingfederate")]
        PINGFEDERATE,
        [EnumMember(Value = "rippling")]
        RIPPLING,
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UpdateRequestIdentityProvider
    {
        [EnumMember(Value = "generic")]
        GENERIC,
        [EnumMember(Value = "okta")]
        OKTA,
        [EnumMember(Value = "microsoft-entra")]
        MICROSOFTENTRA,
        [EnumMember(Value = "cyberark")]
        CYBERARK,
        [EnumMember(Value = "jumpcloud")]
        JUMPCLOUD,
        [EnumMember(Value = "onelogin")]
        ONELOGIN,
        [EnumMember(Value = "pingfederate")]
        PINGFEDERATE,
        [EnumMember(Value = "rippling")]
        RIPPLING,
    }
}
