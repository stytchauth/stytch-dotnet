// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Stytch.net.Models.Consumer
{
public class DiscoveredOrganization {
      /**
    * Indicates whether the Member has all of the factors needed to fully authenticate to this Organization.
    * If false, the Member may need to complete an MFA step or complete a different primary authentication
    * flow. See the `primary_required` and `mfa_required` fields for more details on each.
    */
      [JsonProperty("member_authenticated")]
      public required bool MemberAuthenticated { get; set; }
      // The [Organization object](https://stytch.com/docs/b2b/api/organization-object).
      [JsonProperty("organization")]
      public Organization? Organization { get; set; }
      // Information about the membership.
      [JsonProperty("membership")]
      public Membership? Membership { get; set; }
      // Information about the primary authentication requirements of the Organization.
      [JsonProperty("primary_required")]
      public PrimaryRequired? PrimaryRequired { get; set; }
      // Information about the MFA requirements of the Organization and the Member's options for fulfilling MFA.
      [JsonProperty("mfa_required")]
      public MfaRequired? MfaRequired { get; set; }
    }
public class Membership {
      // Either `active_member`, `pending_member`, `invited_member`, or `eligible_to_join_by_email_domain`
      [JsonProperty("type")]
      public required string Type { get; set; }
      // An object containing additional metadata about the membership, if available.
      [JsonProperty("details")]
      public object? Details { get; set; }
      /**
    * The [Member object](https://stytch.com/docs/b2b/api/member-object) if one already exists, or null if one
    * does not.
    */
      [JsonProperty("member")]
      public Member? Member { get; set; }
    }

}