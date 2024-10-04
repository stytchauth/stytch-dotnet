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
    /// Request type for <see cref="Stytch.net.Clients.Consumer.M2M.Clients.Create"/>..
    /// </summary>
    public class M2MClientsCreateRequest
    {
        /// <summary>
        /// An array of scopes assigned to the client.
        /// </summary>
        [JsonProperty("scopes")]
        public required List<string> Scopes { get; set; }
        /// <summary>
        /// If provided, the ID of the client to create. If not provided, Stytch will generate this value for you.
        /// The `client_id` must be unique within your project.
        /// </summary>
        [JsonProperty("client_id")]
        public string? ClientId { get; set; }
        /// <summary>
        /// If provided, the stored secret of the client to create. If not provided, Stytch will generate this value
        /// for you. If provided, the `client_secret` must be at least 8 characters long and pass entropy
        /// requirements.
        /// </summary>
        [JsonProperty("client_secret")]
        public string? ClientSecret { get; set; }
        /// <summary>
        /// A human-readable name for the client.
        /// </summary>
        [JsonProperty("client_name")]
        public string? ClientName { get; set; }
        /// <summary>
        /// A human-readable description for the client.
        /// </summary>
        [JsonProperty("client_description")]
        public string? ClientDescription { get; set; }
        /// <summary>
        /// The `trusted_metadata` field contains an arbitrary JSON object of application-specific data. See the
        /// [Metadata](https://stytch.com/docs/api/metadata) reference for complete field behavior details.
        /// </summary>
        [JsonProperty("trusted_metadata")]
        public object? TrustedMetadata { get; set; }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.Consumer.M2M.Clients.Create"/>..
    /// </summary>
    public class M2MClientsCreateResponse
    {
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public required string RequestId { get; set; }
        /// <summary>
        /// The M2M Client created by this API call.
        /// </summary>
        [JsonProperty("m2m_client")]
        public required M2MClientWithClientSecret M2MClient { get; set; }
        /// <summary>
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public required int StatusCode { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.Consumer.M2M.Clients.Delete"/>..
    /// </summary>
    public class M2MClientsDeleteRequest
    {
        /// <summary>
        /// The ID of the client.
        /// </summary>
        [JsonProperty("client_id")]
        public required string ClientId { get; set; }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.Consumer.M2M.Clients.Delete"/>..
    /// </summary>
    public class M2MClientsDeleteResponse
    {
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public required string RequestId { get; set; }
        /// <summary>
        /// The ID of the client.
        /// </summary>
        [JsonProperty("client_id")]
        public required string ClientId { get; set; }
        /// <summary>
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public required int StatusCode { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.Consumer.M2M.Clients.Get"/>..
    /// </summary>
    public class M2MClientsGetRequest
    {
        /// <summary>
        /// The ID of the client.
        /// </summary>
        [JsonProperty("client_id")]
        public required string ClientId { get; set; }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.Consumer.M2M.Clients.Get"/>..
    /// </summary>
    public class M2MClientsGetResponse
    {
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public required string RequestId { get; set; }
        /// <summary>
        /// The M2M Client affected by this operation.
        /// </summary>
        [JsonProperty("m2m_client")]
        public required M2MClient M2MClient { get; set; }
        /// <summary>
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public required int StatusCode { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.Consumer.M2M.Clients.Search"/>..
    /// </summary>
    public class M2MClientsSearchRequest
    {
        /// <summary>
        /// The `cursor` field allows you to paginate through your results. Each result array is limited to 1000
        /// results. If your query returns more than 1000 results, you will need to paginate the responses using the
        /// `cursor`. If you receive a response that includes a non-null `next_cursor` in the `results_metadata`
        /// object, repeat the search call with the `next_cursor` value set to the `cursor` field to retrieve the
        /// next page of results. Continue to make search calls until the `next_cursor` in the response is null.
        /// </summary>
        [JsonProperty("cursor")]
        public string? Cursor { get; set; }
        /// <summary>
        /// The number of search results to return per page. The default limit is 100. A maximum of 1000 results can
        /// be returned by a single search request. If the total size of your result set is greater than one page
        /// size, you must paginate the response. See the `cursor` field.
        /// </summary>
        [JsonProperty("limit")]
        public uint? Limit { get; set; }
        /// <summary>
        /// The optional query object contains the operator, i.e. `AND` or `OR`, and the operands that will filter
        /// your results. Only an operator is required. If you include no operands, no filtering will be applied. If
        /// you include no query object, it will return all results with no filtering applied.
        /// </summary>
        [JsonProperty("query")]
        public M2MSearchQuery? Query { get; set; }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.Consumer.M2M.Clients.Search"/>..
    /// </summary>
    public class M2MClientsSearchResponse
    {
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public required string RequestId { get; set; }
        /// <summary>
        /// An array of M2M Clients that match your search query.
        /// </summary>
        [JsonProperty("m2m_clients")]
        public required List<M2MClient> M2MClients { get; set; }
        /// <summary>
        /// The search `results_metadata` object contains metadata relevant to your specific query like total and
        /// `next_cursor`.
        /// </summary>
        [JsonProperty("results_metadata")]
        public required M2MResultsMetadata ResultsMetadata { get; set; }
        /// <summary>
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public required int StatusCode { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.Consumer.M2M.Clients.Update"/>..
    /// </summary>
    public class M2MClientsUpdateRequest
    {
        /// <summary>
        /// The ID of the client.
        /// </summary>
        [JsonProperty("client_id")]
        public required string ClientId { get; set; }
        /// <summary>
        /// A human-readable name for the client.
        /// </summary>
        [JsonProperty("client_name")]
        public string? ClientName { get; set; }
        /// <summary>
        /// A human-readable description for the client.
        /// </summary>
        [JsonProperty("client_description")]
        public string? ClientDescription { get; set; }
        /// <summary>
        /// The status of the client - either `active` or `inactive`.
        /// </summary>
        [JsonProperty("status")]
        public UpdateRequestStatus? Status { get; set; }
        /// <summary>
        /// An array of scopes assigned to the client.
        /// </summary>
        [JsonProperty("scopes")]
        public List<string>? Scopes { get; set; }
        /// <summary>
        /// The `trusted_metadata` field contains an arbitrary JSON object of application-specific data. See the
        /// [Metadata](https://stytch.com/docs/api/metadata) reference for complete field behavior details.
        /// </summary>
        [JsonProperty("trusted_metadata")]
        public object? TrustedMetadata { get; set; }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.Consumer.M2M.Clients.Update"/>..
    /// </summary>
    public class M2MClientsUpdateResponse
    {
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public required string RequestId { get; set; }
        /// <summary>
        /// The M2M Client affected by this operation.
        /// </summary>
        [JsonProperty("m2m_client")]
        public required M2MClient M2MClient { get; set; }
        /// <summary>
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public required int StatusCode { get; set; }
    }

    public enum UpdateRequestStatus
    {
        [EnumMember(Value = "active")]
        ACTIVE,
        [EnumMember(Value = "inactive")]
        INACTIVE,
    }
}