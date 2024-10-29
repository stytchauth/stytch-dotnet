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
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.B2B.MagicLinks.Discovery.Authenticate"/>..
    /// </summary>
    public class B2BMagicLinksDiscoveryAuthenticateRequest
    {
        /// <summary>
        /// The Discovery Email Magic Link token to authenticate.
        /// </summary>
        [JsonProperty("discovery_magic_links_token")]
        public string DiscoveryMagicLinksToken { get; set; }
        /// <summary>
        /// A base64url encoded one time secret used to validate that the request starts and ends on the same device.
        /// </summary>
        [JsonProperty("pkce_code_verifier")]
        public string PkceCodeVerifier { get; set; }
        public B2BMagicLinksDiscoveryAuthenticateRequest(string discoveryMagicLinksToken)
        {
            this.DiscoveryMagicLinksToken = discoveryMagicLinksToken;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.B2B.MagicLinks.Discovery.Authenticate"/>..
    /// </summary>
    public class B2BMagicLinksDiscoveryAuthenticateResponse
    {
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        /// <summary>
        /// The Intermediate Session Token. This token does not necessarily belong to a specific instance of a
        /// Member, but represents a bag of factors that may be converted to a member session. The token can be used
        /// with the [OTP SMS Authenticate endpoint](https://stytch.com/docs/b2b/api/authenticate-otp-sms),
        /// [TOTP Authenticate endpoint](https://stytch.com/docs/b2b/api/authenticate-totp), or
        /// [Recovery Codes Recover endpoint](https://stytch.com/docs/b2b/api/recovery-codes-recover) to complete an
        /// MFA flow and log in to the Organization. It can also be used with the
        /// [Exchange Intermediate Session endpoint](https://stytch.com/docs/b2b/api/exchange-intermediate-session)
        /// to join a specific Organization that allows the factors represented by the intermediate session token;
        /// or the
        /// [Create Organization via Discovery endpoint](https://stytch.com/docs/b2b/api/create-organization-via-discovery) to create a new Organization and Member.
        /// </summary>
        [JsonProperty("intermediate_session_token")]
        public string IntermediateSessionToken { get; set; }
        /// <summary>
        /// The email address.
        /// </summary>
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }
        /// <summary>
        /// An array of `discovered_organization` objects tied to the `intermediate_session_token`, `session_token`,
        /// or `session_jwt`. See the
        /// [Discovered Organization Object](https://stytch.com/docs/b2b/api/discovered-organization-object) for
        /// complete details.
        ///       
        ///   Note that Organizations will only appear here under any of the following conditions:
        ///   1. The end user is already a Member of the Organization.
        ///   2. The end user is invited to the Organization. 
        ///   3. The end user can join the Organization because: 
        ///   
        ///       a) The Organization allows JIT provisioning.
        ///       
        ///       b) The Organizations' allowed domains list contains the Member's email domain.
        ///       
        ///       c) The Organization has at least one other Member with a verified email address with the same
        /// domain as the end user (to prevent phishing attacks).
        /// </summary>
        [JsonProperty("discovered_organizations")]
        public List<DiscoveredOrganization> DiscoveredOrganizations { get; set; }
        /// <summary>
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
    }

}
