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
    public class B2BMagicLinksEmailInviteRequestOptions
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
    /// Request type for <see cref="Stytch.net.Clients.B2B.MagicLinks.Email.Invite"/>..
    /// </summary>
    public class B2BMagicLinksEmailInviteRequest
    {
        /// <summary>
        /// Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
        /// perform operations on an Organization, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
        /// <summary>
        /// The email address of the Member.
        /// </summary>
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }
        /// <summary>
        /// The URL that the Member clicks from the invite Email Magic Link. This URL should be an endpoint in the
        /// backend server that verifies
        ///   the request by querying Stytch's authenticate endpoint and finishes the invite flow. If this value is
        /// not passed, the default `invite_redirect_url`
        ///   that you set in your Dashboard is used. If you have not set a default `invite_redirect_url`, an error
        /// is returned.
        /// </summary>
        [JsonProperty("invite_redirect_url")]
        public string InviteRedirectURL { get; set; }
        /// <summary>
        /// The `member_id` of the Member who sends the invite.
        /// </summary>
        [JsonProperty("invited_by_member_id")]
        public string InvitedByMemberId { get; set; }
        /// <summary>
        /// The name of the Member.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// An arbitrary JSON object for storing application-specific data or identity-provider-specific data.
        /// </summary>
        [JsonProperty("trusted_metadata")]
        public object TrustedMetadata { get; set; }
        /// <summary>
        /// An arbitrary JSON object of application-specific data. These fields can be edited directly by the
        ///   frontend SDK, and should not be used to store critical information. See the
        /// [Metadata resource](https://stytch.com/docs/b2b/api/metadata)
        ///   for complete field behavior details.
        /// </summary>
        [JsonProperty("untrusted_metadata")]
        public object UntrustedMetadata { get; set; }
        /// <summary>
        /// Use a custom template for invite emails. By default, it will use your default email template. The
        /// template must be a template
        ///   using our built-in customizations or a custom HTML email for Magic Links - Invite.
        /// </summary>
        [JsonProperty("invite_template_id")]
        public string InviteTemplateId { get; set; }
        /// <summary>
        /// Used to determine which language to use when sending the user this delivery method. Parameter is a
        /// [IETF BCP 47 language tag](https://www.w3.org/International/articles/language-tags/), e.g. `"en"`.
        /// 
        /// Currently supported languages are English (`"en"`), Spanish (`"es"`), and Brazilian Portuguese
        /// (`"pt-br"`); if no value is provided, the copy defaults to English.
        /// 
        /// Request support for additional languages
        /// [here](https://docs.google.com/forms/d/e/1FAIpQLScZSpAu_m2AmLXRT3F3kap-s_mcV6UTBitYn6CdyWP0-o7YjQ/viewform?usp=sf_link")!
        /// 
        /// </summary>
        [JsonProperty("locale")]
        public B2BMagicLinksEmailInviteRequestLocale Locale { get; set; }
        /// <summary>
        /// Roles to explicitly assign to this Member. See the
        /// [RBAC guide](https://stytch.com/docs/b2b/guides/rbac/role-assignment)
        ///    for more information about role assignment.
        /// </summary>
        [JsonProperty("roles")]
        public List<string> Roles { get; set; }
        public B2BMagicLinksEmailInviteRequest(string organizationId, string emailAddress)
        {
            this.OrganizationId = organizationId;
            this.EmailAddress = emailAddress;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.MagicLinks.Email.Invite"/>..
    /// </summary>
    public class B2BMagicLinksEmailInviteResponse
    {
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        /// <summary>
        /// Globally unique UUID that identifies a specific Member.
        /// </summary>
        [JsonProperty("member_id")]
        public string MemberId { get; set; }
        /// <summary>
        /// The [Member object](https://stytch.com/docs/b2b/api/member-object)
        /// </summary>
        [JsonProperty("member")]
        public Member Member { get; set; }
        /// <summary>
        /// The [Organization object](https://stytch.com/docs/b2b/api/organization-object).
        /// </summary>
        [JsonProperty("organization")]
        public Organization Organization { get; set; }
        /// <summary>
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.MagicLinks.Email.LoginOrSignup"/>..
    /// </summary>
    public class B2BMagicLinksEmailLoginOrSignupRequest
    {
        /// <summary>
        /// Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
        /// perform operations on an Organization, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
        /// <summary>
        /// The email address of the Member.
        /// </summary>
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }
        /// <summary>
        /// The URL that the Member clicks from the login Email Magic Link. This URL should be an endpoint in the
        /// backend server that
        ///   verifies the request by querying Stytch's authenticate endpoint and finishes the login. If this value
        /// is not passed, the default login
        ///   redirect URL that you set in your Dashboard is used. If you have not set a default login redirect URL,
        /// an error is returned.
        /// </summary>
        [JsonProperty("login_redirect_url")]
        public string LoginRedirectURL { get; set; }
        /// <summary>
        /// The URL the Member clicks from the signup Email Magic Link. This URL should be an endpoint in the
        /// backend server that verifies
        ///   the request by querying Stytch's authenticate endpoint and finishes the login. If this value is not
        /// passed, the default sign-up redirect URL
        ///   that you set in your Dashboard is used. If you have not set a default sign-up redirect URL, an error
        /// is returned.
        /// </summary>
        [JsonProperty("signup_redirect_url")]
        public string SignupRedirectURL { get; set; }
        /// <summary>
        /// A base64url encoded SHA256 hash of a one time secret used to validate that the request starts and ends
        /// on the same device.
        /// </summary>
        [JsonProperty("pkce_code_challenge")]
        public string PkceCodeChallenge { get; set; }
        /// <summary>
        /// Use a custom template for login emails. By default, it will use your default email template. The
        /// template must be from Stytch's
        /// built-in customizations or a custom HTML email for Magic Links - Login.
        /// </summary>
        [JsonProperty("login_template_id")]
        public string LoginTemplateId { get; set; }
        /// <summary>
        /// Use a custom template for signup emails. By default, it will use your default email template. The
        /// template must be from Stytch's
        /// built-in customizations or a custom HTML email for Magic Links - Signup.
        /// </summary>
        [JsonProperty("signup_template_id")]
        public string SignupTemplateId { get; set; }
        /// <summary>
        /// Used to determine which language to use when sending the user this delivery method. Parameter is a
        /// [IETF BCP 47 language tag](https://www.w3.org/International/articles/language-tags/), e.g. `"en"`.
        /// 
        /// Currently supported languages are English (`"en"`), Spanish (`"es"`), and Brazilian Portuguese
        /// (`"pt-br"`); if no value is provided, the copy defaults to English.
        /// 
        /// Request support for additional languages
        /// [here](https://docs.google.com/forms/d/e/1FAIpQLScZSpAu_m2AmLXRT3F3kap-s_mcV6UTBitYn6CdyWP0-o7YjQ/viewform?usp=sf_link")!
        /// 
        /// </summary>
        [JsonProperty("locale")]
        public LoginOrSignupRequestLocale Locale { get; set; }
        public B2BMagicLinksEmailLoginOrSignupRequest(string organizationId, string emailAddress)
        {
            this.OrganizationId = organizationId;
            this.EmailAddress = emailAddress;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.MagicLinks.Email.LoginOrSignup"/>..
    /// </summary>
    public class B2BMagicLinksEmailLoginOrSignupResponse
    {
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        /// <summary>
        /// Globally unique UUID that identifies a specific Member.
        /// </summary>
        [JsonProperty("member_id")]
        public string MemberId { get; set; }
        /// <summary>
        /// A flag indicating `true` if a new Member object was created and `false` if the Member object already
        /// existed.
        /// </summary>
        [JsonProperty("member_created")]
        public bool MemberCreated { get; set; }
        /// <summary>
        /// The [Member object](https://stytch.com/docs/b2b/api/member-object)
        /// </summary>
        [JsonProperty("member")]
        public Member Member { get; set; }
        /// <summary>
        /// The [Organization object](https://stytch.com/docs/b2b/api/organization-object).
        /// </summary>
        [JsonProperty("organization")]
        public Organization Organization { get; set; }
        /// <summary>
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum B2BMagicLinksEmailInviteRequestLocale
    {
        [EnumMember(Value = "en")]
        EN,
        [EnumMember(Value = "es")]
        ES,
        [EnumMember(Value = "pt-br")]
        PTBR,
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LoginOrSignupRequestLocale
    {
        [EnumMember(Value = "en")]
        EN,
        [EnumMember(Value = "es")]
        ES,
        [EnumMember(Value = "pt-br")]
        PTBR,
    }
}