// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace Stytch.net.Models.Consumer
{
    public class M2MClient
    {
        /// <summary>
        /// The ID of the client.
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
        /// <summary>
        /// A human-readable name for the client.
        /// </summary>
        [JsonProperty("client_name")]
        public string ClientName { get; set; }
        /// <summary>
        /// A human-readable description for the client.
        /// </summary>
        [JsonProperty("client_description")]
        public string ClientDescription { get; set; }
        /// <summary>
        /// The status of the client - either `active` or `inactive`.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
        /// <summary>
        /// An array of scopes assigned to the client.
        /// </summary>
        [JsonProperty("scopes")]
        public List<string> Scopes { get; set; }
        /// <summary>
        /// The last four characters of the client secret.
        /// </summary>
        [JsonProperty("client_secret_last_four")]
        public string ClientSecretLastFour { get; set; }
        /// <summary>
        /// An arbitrary JSON object for storing application-specific data.
        /// </summary>
        [JsonProperty("trusted_metadata")]
        public object TrustedMetadata { get; set; }
        /// <summary>
        /// The last four characters of the `next_client_secret`. Null if no `next_client_secret` exists.
        /// </summary>
        [JsonProperty("next_client_secret_last_four")]
        public string NextClientSecretLastFour { get; set; }
    }
    public class M2MClientWithClientSecret
    {
        /// <summary>
        /// The ID of the client.
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
        /// <summary>
        /// The secret of the client. **Important:** this is the only time you will be able to view the
        /// `client_secret`. Be sure to persist the `client_secret` in a secure location. If the `client_secret` is
        /// lost, you will need to trigger a secret rotation flow to receive another one.
        /// </summary>
        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }
        /// <summary>
        /// A human-readable name for the client.
        /// </summary>
        [JsonProperty("client_name")]
        public string ClientName { get; set; }
        /// <summary>
        /// A human-readable description for the client.
        /// </summary>
        [JsonProperty("client_description")]
        public string ClientDescription { get; set; }
        /// <summary>
        /// The status of the client - either `active` or `inactive`.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
        /// <summary>
        /// An array of scopes assigned to the client.
        /// </summary>
        [JsonProperty("scopes")]
        public List<string> Scopes { get; set; }
        /// <summary>
        /// The last four characters of the client secret.
        /// </summary>
        [JsonProperty("client_secret_last_four")]
        public string ClientSecretLastFour { get; set; }
        /// <summary>
        /// An arbitrary JSON object for storing application-specific data.
        /// </summary>
        [JsonProperty("trusted_metadata")]
        public object TrustedMetadata { get; set; }
        /// <summary>
        /// The last four characters of the `next_client_secret`. Null if no `next_client_secret` exists.
        /// </summary>
        [JsonProperty("next_client_secret_last_four")]
        public string NextClientSecretLastFour { get; set; }
    }
    public class M2MClientWithNextClientSecret
    {
        /// <summary>
        /// The ID of the client.
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
        /// <summary>
        /// The newly created secret that's next in rotation for the client. **Important:** this is the only time
        /// you will be able to view the `next_client_secret`. Be sure to persist the `next_client_secret` in a
        /// secure location. If the `next_client_secret` is lost, you will need to trigger a secret rotation flow to
        /// receive another one.
        /// </summary>
        [JsonProperty("next_client_secret")]
        public string NextClientSecret { get; set; }
        /// <summary>
        /// A human-readable name for the client.
        /// </summary>
        [JsonProperty("client_name")]
        public string ClientName { get; set; }
        /// <summary>
        /// A human-readable description for the client.
        /// </summary>
        [JsonProperty("client_description")]
        public string ClientDescription { get; set; }
        /// <summary>
        /// The status of the client - either `active` or `inactive`.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
        /// <summary>
        /// An array of scopes assigned to the client.
        /// </summary>
        [JsonProperty("scopes")]
        public List<string> Scopes { get; set; }
        /// <summary>
        /// The last four characters of the client secret.
        /// </summary>
        [JsonProperty("client_secret_last_four")]
        public string ClientSecretLastFour { get; set; }
        /// <summary>
        /// An arbitrary JSON object for storing application-specific data.
        /// </summary>
        [JsonProperty("trusted_metadata")]
        public object TrustedMetadata { get; set; }
        /// <summary>
        /// The last four characters of the `next_client_secret`. Null if no `next_client_secret` exists.
        /// </summary>
        [JsonProperty("next_client_secret_last_four")]
        public string NextClientSecretLastFour { get; set; }
    }
    public class M2MResultsMetadata
    {
        /// <summary>
        /// The total number of results returned by your search query.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }
        /// <summary>
        /// The `next_cursor` string is returned when your search result contains more than one page of results.
        /// This value is passed into your next search call in the `cursor` field.
        /// </summary>
        [JsonProperty("next_cursor")]
        public string NextCursor { get; set; }
    }
    public class M2MSearchQuery
    {
        /// <summary>
        /// The action to perform on the operands. The accepted value are:
        /// 
        ///   `AND` – all the operand values provided must match.
        ///   
        ///   `OR` – the operator will return any matches to at least one of the operand values you supply.
        /// </summary>
        [JsonProperty("operator")]
        public M2MSearchQueryOperator Operator { get; set; }
        /// <summary>
        /// An array of operand objects that contains all of the filters and values to apply to your search search
        /// query.
        /// </summary>
        [JsonProperty("operands")]
        public List<M2MSearchQueryOperand> Operands { get; set; }
    }

    public enum M2MSearchQueryOperator
    {
        [EnumMember(Value = "OR")]
        OR,
        [EnumMember(Value = "AND")]
        AND,
    }
    // MANUAL(M2MSearchQueryOperand)(TYPES)
    public abstract class M2MSearchQueryOperand
    {
        public abstract string FilterName { get; }
        public required string[] FilterValue { get; set; }
    }

    public class ClientIdFilter : M2MSearchQueryOperand
    {
        public override string FilterName => "client_id";
    }

    public class ClientNameFilter : M2MSearchQueryOperand
    {
        public override string FilterName => "client_name";
    }

    public class ScopesFilter : M2MSearchQueryOperand
    {
        public override string FilterName => "scopes";
    }
    // ENDMANUAL(M2MSearchQueryOperand)

}