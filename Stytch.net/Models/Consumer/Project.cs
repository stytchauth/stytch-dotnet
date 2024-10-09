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
    public class ProjectMetric
    {
        [JsonProperty("count")]
        public uint Count { get; set; }
        [JsonProperty("metric_type")]
        public ProjectMetricMetricType MetricType { get; set; }
    }
    public class ProjectMetricsRequest
    {
        public ProjectMetricsRequest()
        {
        }
    }
    public class ProjectMetricsResponse
    {
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        [JsonProperty("project_id")]
        public string ProjectId { get; set; }
        [JsonProperty("metrics")]
        public List<ProjectMetric> Metrics { get; set; }
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProjectMetricMetricType
    {
        [EnumMember(Value = "UNKNOWN")]
        UNKNOWN,
        [EnumMember(Value = "USER_COUNT")]
        USER_COUNT,
        [EnumMember(Value = "ORGANIZATION_COUNT")]
        ORGANIZATION_COUNT,
        [EnumMember(Value = "MEMBER_COUNT")]
        MEMBER_COUNT,
        [EnumMember(Value = "M2M_CLIENT_COUNT")]
        M2M_CLIENT_COUNT,
    }
}