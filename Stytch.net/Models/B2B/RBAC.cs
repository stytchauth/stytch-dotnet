// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Stytch.net.Models.Consumer
{
public class Policy {
      /// <summary>
    /// An array of [Role objects](https://stytch.com/docs/b2b/api/rbac-role-object).
    /// </summary>
      [JsonProperty("roles")]
      public required PolicyRole Roles { get; set; }
      /// <summary>
    /// An array of [Resource objects](https://stytch.com/docs/b2b/api/rbac-resource-object).
    /// </summary>
      [JsonProperty("resources")]
      public required PolicyResource Resources { get; set; }
    }
public class PolicyResource {
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
      public required string ResourceId { get; set; }
      /// <summary>
    /// The description of the RBAC Resource.
    /// </summary>
      [JsonProperty("description")]
      public required string Description { get; set; }
      /// <summary>
    /// A list of all possible actions for a provided Resource. 
    ///   
    ///   Reserved `actions` that are predefined by Stytch include: 
    ///   
    ///   * `*`
    ///   * For the `stytch.organization` Resource:
    ///     * `update.info.name`
    ///     * `update.info.slug`
    ///     * `update.info.untrusted_metadata`
    ///     * `update.info.email_jit_provisioning`
    ///     * `update.info.logo_url`
    ///     * `update.info.email_invites`
    ///     * `update.info.allowed_domains`
    ///     * `update.info.default_sso_connection`
    ///     * `update.info.sso_jit_provisioning`
    ///     * `update.info.mfa_policy`
    ///     * `update.info.implicit_roles`
    ///     * `delete`
    ///   * For the `stytch.member` Resource:
    ///     * `create`
    ///     * `update.info.name`
    ///     * `update.info.untrusted_metadata`
    ///     * `update.info.mfa-phone`
    ///     * `update.info.delete.mfa-phone`
    ///     * `update.settings.is-breakglass`
    ///     * `update.settings.mfa_enrolled`
    ///     * `update.settings.roles`
    ///     * `search`
    ///     * `delete`
    ///   * For the `stytch.sso` Resource:
    ///     * `create`
    ///     * `update`
    ///     * `delete`
    ///   * For the `stytch.self` Resource:
    ///     * `update.info.name`
    ///     * `update.info.untrusted_metadata`
    ///     * `update.info.mfa-phone`
    ///     * `update.info.delete.mfa-phone`
    ///     * `update.info.delete.password`
    ///     * `update.settings.mfa_enrolled`
    ///     * `delete`
    ///   
    /// </summary>
      [JsonProperty("actions")]
      public required string Actions { get; set; }
    }
public class PolicyRole {
      /// <summary>
    /// The unique identifier of the RBAC Role, provided by the developer and intended to be human-readable.  
    ///   
    ///   Reserved `role_id`s that are predefined by Stytch include: 
    ///   
    ///   * `stytch_member`
    ///   * `stytch_admin`
    ///   
    ///   Check out the [guide on Stytch default Roles](https://stytch.com/docs/b2b/guides/rbac/stytch-default)
    /// for a more detailed explanation.
    /// 
    ///   
    /// </summary>
      [JsonProperty("role_id")]
      public required string RoleId { get; set; }
      /// <summary>
    /// The description of the RBAC Role.
    /// </summary>
      [JsonProperty("description")]
      public required string Description { get; set; }
      /// <summary>
    /// A list of permissions that link a [Resource](https://stytch.com/docs/b2b/api/rbac-resource-object) to a
    /// list of actions.
    /// </summary>
      [JsonProperty("permissions")]
      public required PolicyRolePermission Permissions { get; set; }
    }
public class PolicyRolePermission {
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
      public required string ResourceId { get; set; }
      /// <summary>
    /// A list of permitted actions the Role is authorized to take with the provided Resource. You can use `*`
    /// as a wildcard to grant a Role permission to use all possible actions related to the Resource. 
    /// </summary>
      [JsonProperty("actions")]
      public required string Actions { get; set; }
    }
/// <summary>
    /// Request type for `rbac.policy`.
    /// </summary>
    public class B2BRBACPolicyRequest {
    }
/// <summary>
    /// Response type for `rbac.policy`.
    /// </summary>
    public class B2BRBACPolicyResponse {
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
    /// The RBAC Policy document that contains all defined Roles and Resources – which are managed in the
    /// [Dashboard](/dashboard/rbac). Read more about these entities and how they work in our
    /// [RBAC overview](https://stytch.com/docs/b2b/guides/rbac/overview).
    /// </summary>
      [JsonProperty("policy")]
      public Policy? Policy { get; set; }
    }

// MANUAL(Authorization)(TYPES)
public class Authorization
{
  // A secret token for a given Stytch Session.
  public string? SessionToken { get; set; }
  // The JSON Web Token (JWT) for a given Stytch Session.
  public string? SessionJwt { get; set; }
}
// ENDMANUAL(Authorization)

}