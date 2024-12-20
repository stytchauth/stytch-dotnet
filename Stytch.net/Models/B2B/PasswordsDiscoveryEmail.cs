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
    public class B2BPasswordsDiscoveryEmailResetRequest
    {
        [JsonProperty("password_reset_token")]
        public string PasswordResetToken { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("pkce_code_verifier")]
        public string PkceCodeVerifier { get; set; }
        [JsonProperty("locale")]
        public string Locale { get; set; }
        public B2BPasswordsDiscoveryEmailResetRequest(string passwordResetToken, string password)
        {
            this.PasswordResetToken = passwordResetToken;
            this.Password = password;
        }
    }
    public class B2BPasswordsDiscoveryEmailResetResponse
    {
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        [JsonProperty("intermediate_session_token")]
        public string IntermediateSessionToken { get; set; }
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }
        [JsonProperty("discovered_organizations")]
        public List<DiscoveredOrganization> DiscoveredOrganizations { get; set; }
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
    }
    public class B2BPasswordsDiscoveryEmailResetStartRequest
    {
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }
        [JsonProperty("reset_password_redirect_url")]
        public string ResetPasswordRedirectURL { get; set; }
        [JsonProperty("discovery_redirect_url")]
        public string DiscoveryRedirectURL { get; set; }
        [JsonProperty("reset_password_template_id")]
        public string ResetPasswordTemplateId { get; set; }
        [JsonProperty("reset_password_expiration_minutes")]
        public int? ResetPasswordExpirationMinutes { get; set; }
        [JsonProperty("pkce_code_challenge")]
        public string PkceCodeChallenge { get; set; }
        [JsonProperty("locale")]
        public string Locale { get; set; }
        public B2BPasswordsDiscoveryEmailResetStartRequest(string emailAddress)
        {
            this.EmailAddress = emailAddress;
        }
    }
    public class B2BPasswordsDiscoveryEmailResetStartResponse
    {
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
    }

}
