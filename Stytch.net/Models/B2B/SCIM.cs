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
    public class Address
    {
        [JsonProperty("formatted")]
        public string Formatted { get; set; }
        [JsonProperty("street_address")]
        public string StreetAddress { get; set; }
        [JsonProperty("locality")]
        public string Locality { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("primary")]
        public bool Primary { get; set; }
    }
    public class B2BSCIMEmail
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("primary")]
        public bool Primary { get; set; }
    }
    public class B2BSCIMName
    {
        [JsonProperty("formatted")]
        public string Formatted { get; set; }
        [JsonProperty("family_name")]
        public string FamilyName { get; set; }
        [JsonProperty("given_name")]
        public string GivenName { get; set; }
        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }
        [JsonProperty("honorific_prefix")]
        public string HonorificPrefix { get; set; }
        [JsonProperty("honorific_suffix")]
        public string HonorificSuffix { get; set; }
    }
    public class B2BSCIMPhoneNumber
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("primary")]
        public bool Primary { get; set; }
    }
    public class B2BSCIMX509Certificate
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("primary")]
        public bool Primary { get; set; }
    }
    public class EnterpriseExtension
    {
        [JsonProperty("employee_number")]
        public string EmployeeNumber { get; set; }
        [JsonProperty("cost_center")]
        public string CostCenter { get; set; }
        [JsonProperty("division")]
        public string Division { get; set; }
        [JsonProperty("department")]
        public string Department { get; set; }
        [JsonProperty("organization")]
        public string Organization { get; set; }
        [JsonProperty("manager")]
        public Manager Manager { get; set; }
    }
    public class Entitlement
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("primary")]
        public bool Primary { get; set; }
    }
    public class Group
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("display")]
        public string Display { get; set; }
    }
    public class IMs
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("primary")]
        public bool Primary { get; set; }
    }
    public class Manager
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("ref")]
        public string Ref { get; set; }
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
    }
    public class Photo
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("primary")]
        public bool Primary { get; set; }
    }
    public class Role
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("primary")]
        public bool Primary { get; set; }
    }
    public class SCIMAttributes
    {
        [JsonProperty("user_name")]
        public string UserName { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }
        [JsonProperty("active")]
        public bool Active { get; set; }
        [JsonProperty("groups")]
        public List<Group> Groups { get; set; }
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        [JsonProperty("nick_name")]
        public string NickName { get; set; }
        [JsonProperty("profile_url")]
        public string ProfileURL { get; set; }
        [JsonProperty("user_type")]
        public string UserType { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("preferred_language")]
        public string PreferredLanguage { get; set; }
        [JsonProperty("locale")]
        public string Locale { get; set; }
        [JsonProperty("timezone")]
        public string Timezone { get; set; }
        [JsonProperty("emails")]
        public List<B2BSCIMEmail> Emails { get; set; }
        [JsonProperty("phone_numbers")]
        public List<B2BSCIMPhoneNumber> PhoneNumbers { get; set; }
        [JsonProperty("addresses")]
        public List<Address> Addresses { get; set; }
        [JsonProperty("ims")]
        public List<IMs> Ims { get; set; }
        [JsonProperty("photos")]
        public List<Photo> Photos { get; set; }
        [JsonProperty("entitlements")]
        public List<Entitlement> Entitlements { get; set; }
        [JsonProperty("roles")]
        public List<Role> Roles { get; set; }
        [JsonProperty("x509certificates")]
        public List<B2BSCIMX509Certificate> X509Certificates { get; set; }
        [JsonProperty("name")]
        public B2BSCIMName Name { get; set; }
        [JsonProperty("enterprise_extension")]
        public EnterpriseExtension EnterpriseExtension { get; set; }
    }
    public class SCIMConnection
    {
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        [JsonProperty("identity_provider")]
        public string IdentityProvider { get; set; }
        [JsonProperty("base_url")]
        public string BaseURL { get; set; }
        [JsonProperty("bearer_token_last_four")]
        public string BearerTokenLastFour { get; set; }
        [JsonProperty("scim_group_implicit_role_assignments")]
        public List<SCIMGroupImplicitRoleAssignments> SCIMGroupImplicitRoleAssignments { get; set; }
        [JsonProperty("next_bearer_token_last_four")]
        public string NextBearerTokenLastFour { get; set; }
        [JsonProperty("bearer_token_expires_at")]
        public DateTime? BearerTokenExpiresAt { get; set; }
        [JsonProperty("next_bearer_token_expires_at")]
        public DateTime? NextBearerTokenExpiresAt { get; set; }
    }
    public class SCIMConnectionWithNextToken
    {
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        [JsonProperty("base_url")]
        public string BaseURL { get; set; }
        [JsonProperty("identity_provider")]
        public string IdentityProvider { get; set; }
        [JsonProperty("bearer_token_last_four")]
        public string BearerTokenLastFour { get; set; }
        [JsonProperty("next_bearer_token")]
        public string NextBearerToken { get; set; }
        [JsonProperty("scim_group_implicit_role_assignments")]
        public List<SCIMGroupImplicitRoleAssignments> SCIMGroupImplicitRoleAssignments { get; set; }
        [JsonProperty("bearer_token_expires_at")]
        public DateTime? BearerTokenExpiresAt { get; set; }
        [JsonProperty("next_bearer_token_expires_at")]
        public DateTime? NextBearerTokenExpiresAt { get; set; }
    }
    public class SCIMConnectionWithToken
    {
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        [JsonProperty("identity_provider")]
        public string IdentityProvider { get; set; }
        [JsonProperty("base_url")]
        public string BaseURL { get; set; }
        [JsonProperty("bearer_token")]
        public string BearerToken { get; set; }
        [JsonProperty("scim_group_implicit_role_assignments")]
        public List<SCIMGroupImplicitRoleAssignments> SCIMGroupImplicitRoleAssignments { get; set; }
        [JsonProperty("bearer_token_expires_at")]
        public DateTime? BearerTokenExpiresAt { get; set; }
    }
    public class SCIMGroup
    {
        /// <summary>
        /// Globally unique UUID that identifies a specific SCIM Group.
        /// </summary>
        [JsonProperty("group_id")]
        public string GroupId { get; set; }
        /// <summary>
        /// The name of the SCIM group.
        /// </summary>
        [JsonProperty("group_name")]
        public string GroupName { get; set; }
        /// <summary>
        /// Globally unique UUID that identifies a specific Organization. The organization_id is critical to perform
        /// operations on an Organization, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
        /// <summary>
        /// The ID of the SCIM connection.
        /// </summary>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }
    }
    public class SCIMGroupImplicitRoleAssignments
    {
        /// <summary>
        /// The ID of the role.
        /// </summary>
        [JsonProperty("role_id")]
        public string RoleId { get; set; }
        /// <summary>
        /// The ID of the group.
        /// </summary>
        [JsonProperty("group_id")]
        public string GroupId { get; set; }
        [JsonProperty("group_name")]
        public string GroupName { get; set; }
    }

}
