// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace Stytch.net.Models.Consumer
{
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.Consumer.OTPs.Email.LoginOrCreate"/>..
    /// </summary>
    public class OTPsEmailLoginOrCreateRequest
    {
        /// <summary>
        /// The email address of the user to send the one-time passcode to. You may use sandbox@stytch.com to test
        /// this endpoint, see [Testing](https://stytch.com/docs/home#resources_testing) for more detail.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
        /// <summary>
        /// Set the expiration for the one-time passcode, in minutes. The minimum expiration is 1 minute and the
        /// maximum is 10 minutes. The default expiration is 2 minutes.
        /// </summary>
        [JsonProperty("expiration_minutes")]
        public int? ExpirationMinutes { get; set; }
        /// <summary>
        /// Provided attributes help with fraud detection.
        /// </summary>
        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
        /// <summary>
        /// Flag for whether or not to save a user as pending vs active in Stytch. Defaults to false.
        ///         If true, users will be saved with status pending in Stytch's backend until authenticated.
        ///         If false, users will be created as active. An example usage of
        ///         a true flag would be to require users to verify their phone by entering the OTP code before
        /// creating
        ///         an account for them.
        /// </summary>
        [JsonProperty("create_user_as_pending")]
        public bool? CreateUserAsPending { get; set; }
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
        public OTPsEmailLoginOrCreateRequestLocale Locale { get; set; }
        /// <summary>
        /// Use a custom template for login emails. By default, it will use your default email template. The
        /// template must be a template using our built-in customizations or a custom HTML email for Magic links -
        /// Login.
        /// </summary>
        [JsonProperty("login_template_id")]
        public string LoginTemplateId { get; set; }
        /// <summary>
        /// Use a custom template for sign-up emails. By default, it will use your default email template. The
        /// template must be a template using our built-in customizations or a custom HTML email for Magic links -
        /// Sign-up.
        /// </summary>
        [JsonProperty("signup_template_id")]
        public string SignupTemplateId { get; set; }
        public OTPsEmailLoginOrCreateRequest(string email)
        {
            this.Email = email;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.Consumer.OTPs.Email.LoginOrCreate"/>..
    /// </summary>
    public class OTPsEmailLoginOrCreateResponse
    {
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        /// <summary>
        /// The unique ID of the affected User.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        /// <summary>
        /// The unique ID of a specific email address.
        /// </summary>
        [JsonProperty("email_id")]
        public string EmailId { get; set; }
        /// <summary>
        /// In `login_or_create` endpoints, this field indicates whether or not a User was just created.
        /// </summary>
        [JsonProperty("user_created")]
        public bool UserCreated { get; set; }
        /// <summary>
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.Consumer.OTPs.Email.Send"/>..
    /// </summary>
    public class OTPsEmailSendRequest
    {
        /// <summary>
        /// The email address of the user to send the one-time passcode to. You may use sandbox@stytch.com to test
        /// this endpoint, see [Testing](https://stytch.com/docs/home#resources_testing) for more detail.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
        /// <summary>
        /// Set the expiration for the one-time passcode, in minutes. The minimum expiration is 1 minute and the
        /// maximum is 10 minutes. The default expiration is 2 minutes.
        /// </summary>
        [JsonProperty("expiration_minutes")]
        public int? ExpirationMinutes { get; set; }
        /// <summary>
        /// Provided attributes help with fraud detection.
        /// </summary>
        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
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
        public OTPsEmailSendRequestLocale Locale { get; set; }
        /// <summary>
        /// The unique ID of a specific User.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        /// <summary>
        /// The `session_token` associated with a User's existing Session.
        /// </summary>
        [JsonProperty("session_token")]
        public string SessionToken { get; set; }
        /// <summary>
        /// The `session_jwt` associated with a User's existing Session.
        /// </summary>
        [JsonProperty("session_jwt")]
        public string SessionJwt { get; set; }
        /// <summary>
        /// Use a custom template for login emails. By default, it will use your default email template. The
        /// template must be a template using our built-in customizations or a custom HTML email for Magic links -
        /// Login.
        /// </summary>
        [JsonProperty("login_template_id")]
        public string LoginTemplateId { get; set; }
        /// <summary>
        /// Use a custom template for sign-up emails. By default, it will use your default email template. The
        /// template must be a template using our built-in customizations or a custom HTML email for Magic links -
        /// Sign-up.
        /// </summary>
        [JsonProperty("signup_template_id")]
        public string SignupTemplateId { get; set; }
        public OTPsEmailSendRequest(string email)
        {
            this.Email = email;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.Consumer.OTPs.Email.Send"/>..
    /// </summary>
    public class OTPsEmailSendResponse
    {
        /// <summary>
        /// Globally unique UUID that is returned with every API call. This value is important to log for debugging
        /// purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        /// <summary>
        /// The unique ID of the affected User.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        /// <summary>
        /// The unique ID of a specific email address.
        /// </summary>
        [JsonProperty("email_id")]
        public string EmailId { get; set; }
        /// <summary>
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
    }

    public enum OTPsEmailLoginOrCreateRequestLocale
    {
        [EnumMember(Value = "en")]
        EN,
        [EnumMember(Value = "es")]
        ES,
        [EnumMember(Value = "pt-br")]
        PTBR,
    }
    public enum OTPsEmailSendRequestLocale
    {
        [EnumMember(Value = "en")]
        EN,
        [EnumMember(Value = "es")]
        ES,
        [EnumMember(Value = "pt-br")]
        PTBR,
    }
}