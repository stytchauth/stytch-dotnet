// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Stytch.net.Models.Consumer
{
public class ProjectMetric {
      [JsonProperty("count")]
      public required uint Count { get; set; }
      [JsonProperty("metric_type")]
      public ProjectMetricMetricType? MetricType { get; set; }
    }
public class ProjectMetricsRequest {
    }
public class ProjectMetricsResponse {
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      [JsonProperty("project_id")]
      public required string ProjectId { get; set; }
      [JsonProperty("metrics")]
      public required ProjectMetric Metrics { get; set; }
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
    }

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