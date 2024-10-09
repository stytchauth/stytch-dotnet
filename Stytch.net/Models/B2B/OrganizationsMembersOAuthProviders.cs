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
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.Organizations.Members.OAuthProviders.Google"/>..
    /// </summary>
    public class B2BOrganizationsMembersOAuthProvidersGoogleResponse
    {
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        /// <summary>
        /// Denotes the OAuth identity provider that the user has authenticated with, e.g. Google, Microsoft, GitHub
        /// etc.
        /// </summary>
        [JsonProperty("provider_type")]
        public string ProviderType { get; set; }
        /// <summary>
        /// The unique identifier for the User within a given OAuth provider. Also commonly called the `sub` or
        /// "Subject field" in OAuth protocols.
        /// </summary>
        [JsonProperty("provider_subject")]
        public string ProviderSubject { get; set; }
        /// <summary>
        /// The `id_token` returned by the OAuth provider. ID Tokens are JWTs that contain structured information
        /// about a user. The exact content of each ID Token varies from provider to provider. ID Tokens are
        /// returned from OAuth providers that conform to the [OpenID Connect](https://openid.net/foundation/)
        /// specification, which is based on OAuth.
        /// </summary>
        [JsonProperty("id_token")]
        public string IdToken { get; set; }
        /// <summary>
        /// The OAuth scopes included for a given provider. See each provider's section above to see which scopes
        /// are included by default and how to add custom scopes.
        /// </summary>
        [JsonProperty("scopes")]
        public List<string> Scopes { get; set; }
        /// <summary>
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
        /// <summary>
        /// The `access_token` that you may use to access the User's data in the provider's API.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        /// <summary>
        /// The number of seconds until the access token expires.
        /// </summary>
        [JsonProperty("access_token_expires_in")]
        public int? AccessTokenExpiresIn { get; set; }
        /// <summary>
        /// The `refresh_token` that you may use to obtain a new `access_token` for the User within the provider's
        /// API.
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.Organizations.Members.OAuthProviders.Microsoft"/>..
    /// </summary>
    public class B2BOrganizationsMembersOAuthProvidersMicrosoftResponse
    {
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        /// <summary>
        /// Denotes the OAuth identity provider that the user has authenticated with, e.g. Google, Microsoft, GitHub
        /// etc.
        /// </summary>
        [JsonProperty("provider_type")]
        public string ProviderType { get; set; }
        /// <summary>
        /// The unique identifier for the User within a given OAuth provider. Also commonly called the `sub` or
        /// "Subject field" in OAuth protocols.
        /// </summary>
        [JsonProperty("provider_subject")]
        public string ProviderSubject { get; set; }
        /// <summary>
        /// The `access_token` that you may use to access the User's data in the provider's API.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        /// <summary>
        /// The number of seconds until the access token expires.
        /// </summary>
        [JsonProperty("access_token_expires_in")]
        public int AccessTokenExpiresIn { get; set; }
        /// <summary>
        /// The `id_token` returned by the OAuth provider. ID Tokens are JWTs that contain structured information
        /// about a user. The exact content of each ID Token varies from provider to provider. ID Tokens are
        /// returned from OAuth providers that conform to the [OpenID Connect](https://openid.net/foundation/)
        /// specification, which is based on OAuth.
        /// </summary>
        [JsonProperty("id_token")]
        public string IdToken { get; set; }
        /// <summary>
        /// The OAuth scopes included for a given provider. See each provider's section above to see which scopes
        /// are included by default and how to add custom scopes.
        /// </summary>
        [JsonProperty("scopes")]
        public List<string> Scopes { get; set; }
        /// <summary>
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
        /// <summary>
        /// The `refresh_token` that you may use to obtain a new `access_token` for the User within the provider's
        /// API.
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.Organizations.Members.OAuthProviders.Google"/>., <see
    /// cref="Stytch.net.Clients.B2B.Organizations.Members.OAuthProviders.Microsoft"/>..
    /// </summary>
    public class B2BOrganizationsMembersOAuthProvidersProviderInformationRequest
    {
        /// <summary>
        /// Globally unique UUID that identifies a specific Organization. The `organization_id` is critical to
        /// perform operations on an Organization, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
        /// <summary>
        /// Globally unique UUID that identifies a specific Member. The `member_id` is critical to perform
        /// operations on a Member, so be sure to preserve this value.
        /// </summary>
        [JsonProperty("member_id")]
        public string MemberId { get; set; }
        /// <summary>
        /// Whether to return the refresh token Stytch has stored for the OAuth Provider. Defaults to false.
        /// **Important:** If your application exchanges the refresh token, Stytch may not be able to automatically
        /// refresh access tokens in the future.
        /// </summary>
        [JsonProperty("include_refresh_token")]
        public bool? IncludeRefreshToken { get; set; }
        public B2BOrganizationsMembersOAuthProvidersProviderInformationRequest(string organizationId, string memberId)
        {
            this.OrganizationId = organizationId;
            this.MemberId = memberId;
        }
    }

}