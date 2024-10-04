using Newtonsoft.Json;

namespace Stytch.net.Models
{
    public class MagicLinkRequest
    {
        [JsonProperty("email")]  // Ensure this matches the API's expected field name
        public string Email { get; set; }  // Required

        [JsonProperty("login_magic_link_url")]
        public string? LoginMagicLinkUrl { get; set; }  // Optional

        [JsonProperty("signup_magic_link_url")]
        public string? SignupMagicLinkUrl { get; set; }  // Optional

        [JsonProperty("login_expiration_minutes")]
        public int? LoginExpirationMinutes { get; set; }  // Optional

        [JsonProperty("signup_expiration_minutes")]
        public int? SignupExpirationMinutes { get; set; }  // Optional

        [JsonProperty("login_template_id")]
        public string? LoginTemplateId { get; set; }  // Optional

        [JsonProperty("signup_template_id")]
        public string? SignupTemplateId { get; set; }  // Optional

        [JsonProperty("locale")]
        public string? Locale { get; set; }  // Optional

        [JsonProperty("attributes")]
        public object? Attributes { get; set; }  // Optional

        [JsonProperty("code_challenge")]
        public string? CodeChallenge { get; set; }  // Optional

        [JsonProperty("user_id")]
        public string? UserId { get; set; }  // Optional

        [JsonProperty("session_token")]
        public string? SessionToken { get; set; }  // Optional

        [JsonProperty("session_jwt")]
        public string? SessionJwt { get; set; }  // Optional
    }

    public class MagicLinkResponse
    {

        [JsonProperty("status_code")]
        public required int StatusCode { get; set; }
        [JsonProperty("request_id")]
        public required string RequestId { get; set; }
        [JsonProperty("user_id")]
        public required string UserId { get; set; }
        [JsonProperty("email_id")]
        public required string EmailId { get; set; }
    }
}
