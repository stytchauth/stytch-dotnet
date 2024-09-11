// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Stytch.net.Models.Consumer
{
public class BiometricRegistration {
      // The unique ID for a biometric registration.
      [JsonProperty("biometric_registration_id")]
      public required string BiometricRegistrationId { get; set; }
      /**
    * The verified boolean denotes whether or not this send method, e.g. phone number, email address, etc.,
    * has been successfully authenticated by the User.
    */
      [JsonProperty("verified")]
      public required bool Verified { get; set; }
    }
public class CryptoWallet {
      // The unique ID for a crypto wallet
      [JsonProperty("crypto_wallet_id")]
      public required string CryptoWalletId { get; set; }
      // The actual blockchain address of the User's crypto wallet.
      [JsonProperty("crypto_wallet_address")]
      public required string CryptoWalletAddress { get; set; }
      // The blockchain that the User's crypto wallet operates on, e.g. Ethereum, Solana, etc.
      [JsonProperty("crypto_wallet_type")]
      public required string CryptoWalletType { get; set; }
      /**
    * The verified boolean denotes whether or not this send method, e.g. phone number, email address, etc.,
    * has been successfully authenticated by the User.
    */
      [JsonProperty("verified")]
      public required bool Verified { get; set; }
    }
public class OAuthProvider {
      /**
    * Denotes the OAuth identity provider that the user has authenticated with, e.g. Google, Facebook, GitHub
    * etc.
    */
      [JsonProperty("provider_type")]
      public required string ProviderType { get; set; }
      /**
    * The unique identifier for the User within a given OAuth provider. Also commonly called the "sub" or
    * "Subject field" in OAuth protocols.
    */
      [JsonProperty("provider_subject")]
      public required string ProviderSubject { get; set; }
      /**
    * If available, the `profile_picture_url` is a url of the User's profile picture set in OAuth identity the
    * provider that the User has authenticated with, e.g. Facebook profile picture.
    */
      [JsonProperty("profile_picture_url")]
      public required string ProfilePictureURL { get; set; }
      /**
    * If available, the `locale` is the User's locale set in the OAuth identity provider that the user has
    * authenticated with.
    */
      [JsonProperty("locale")]
      public required string Locale { get; set; }
      // The unique ID for an OAuth registration.
      [JsonProperty("oauth_user_registration_id")]
      public required string OAuthUserRegistrationId { get; set; }
    }
public class Password {
      // The unique ID of a specific password
      [JsonProperty("password_id")]
      public required string PasswordId { get; set; }
      // Indicates whether this password requires a password reset
      [JsonProperty("requires_reset")]
      public required bool RequiresReset { get; set; }
    }
public class SearchUsersQuery {
      /**
    * The action to perform on the operands. The accepted value are:
    * 
    *   `AND` – all the operand values provided must match.
    *   
    *   `OR` – the operator will return any matches to at least one of the operand values you supply.
    */
      [JsonProperty("operator")]
      public required SearchUsersQueryOperator Operator { get; set; }
      /**
    * An array of operand objects that contains all of the filters and values to apply to your search search
    * query.
    */
      [JsonProperty("operands")]
      public required SearchUsersQueryOperand Operands { get; set; }
    }
public class TOTP {
      // The unique ID for a TOTP instance.
      [JsonProperty("totp_id")]
      public required string TOTPId { get; set; }
      /**
    * The verified boolean denotes whether or not this send method, e.g. phone number, email address, etc.,
    * has been successfully authenticated by the User.
    */
      [JsonProperty("verified")]
      public required bool Verified { get; set; }
    }
public class User {
      // The unique ID of the affected User.
      [JsonProperty("user_id")]
      public required string UserId { get; set; }
      // An array of email objects for the User.
      [JsonProperty("emails")]
      public required UsersEmail Emails { get; set; }
      // The status of the User. The possible values are `pending` and `active`.
      [JsonProperty("status")]
      public required string Status { get; set; }
      // An array of phone number objects linked to the User.
      [JsonProperty("phone_numbers")]
      public required UsersPhoneNumber PhoneNumbers { get; set; }
      /**
    * An array that contains a list of all Passkey or WebAuthn registrations for a given User in the Stytch
    * API.
    */
      [JsonProperty("webauthn_registrations")]
      public required WebAuthnRegistration WebAuthnRegistrations { get; set; }
      // An array of OAuth `provider` objects linked to the User.
      [JsonProperty("providers")]
      public required OAuthProvider Providers { get; set; }
      // An array containing a list of all TOTP instances for a given User in the Stytch API.
      [JsonProperty("totps")]
      public required TOTP TOTPs { get; set; }
      // An array contains a list of all crypto wallets for a given User in the Stytch API.
      [JsonProperty("crypto_wallets")]
      public required CryptoWallet CryptoWallets { get; set; }
      // An array that contains a list of all biometric registrations for a given User in the Stytch API.
      [JsonProperty("biometric_registrations")]
      public required BiometricRegistration BiometricRegistrations { get; set; }
      // The name of the User. Each field in the `name` object is optional.
      [JsonProperty("name")]
      public UsersName? Name { get; set; }
      /**
    * The timestamp of the User's creation. Values conform to the RFC 3339 standard and are expressed in UTC,
    * e.g. `2021-12-29T12:33:09Z`.
    */
      [JsonProperty("created_at")]
      public string? CreatedAt { get; set; }
      // The password object is returned for users with a password.
      [JsonProperty("password")]
      public Password? Password { get; set; }
      /**
    * The `trusted_metadata` field contains an arbitrary JSON object of application-specific data. See the
    * [Metadata](https://stytch.com/docs/api/metadata) reference for complete field behavior details.
    */
      [JsonProperty("trusted_metadata")]
      public object? TrustedMetadata { get; set; }
      /**
    * The `untrusted_metadata` field contains an arbitrary JSON object of application-specific data. Untrusted
    * metadata can be edited by end users directly via the SDK, and **cannot be used to store critical
    * information.** See the [Metadata](https://stytch.com/docs/api/metadata) reference for complete field
    * behavior details.
    */
      [JsonProperty("untrusted_metadata")]
      public object? UntrustedMetadata { get; set; }
    }
public class UsersEmail {
      // The unique ID of a specific email address.
      [JsonProperty("email_id")]
      public required string EmailId { get; set; }
      // The email address.
      [JsonProperty("email")]
      public required string Email { get; set; }
      /**
    * The verified boolean denotes whether or not this send method, e.g. phone number, email address, etc.,
    * has been successfully authenticated by the User.
    */
      [JsonProperty("verified")]
      public required bool Verified { get; set; }
    }
public class UsersName {
      // The first name of the user.
      [JsonProperty("first_name")]
      public string? FirstName { get; set; }
      // The middle name(s) of the user.
      [JsonProperty("middle_name")]
      public string? MiddleName { get; set; }
      // The last name of the user.
      [JsonProperty("last_name")]
      public string? LastName { get; set; }
    }
public class UsersPhoneNumber {
      // The unique ID for the phone number.
      [JsonProperty("phone_id")]
      public required string PhoneId { get; set; }
      // The phone number.
      [JsonProperty("phone_number")]
      public required string PhoneNumber { get; set; }
      /**
    * The verified boolean denotes whether or not this send method, e.g. phone number, email address, etc.,
    * has been successfully authenticated by the User.
    */
      [JsonProperty("verified")]
      public required bool Verified { get; set; }
    }
public class UsersResultsMetadata {
      // The total number of results returned by your search query.
      [JsonProperty("total")]
      public required int Total { get; set; }
      /**
    * The `next_cursor` string is returned when your search result contains more than one page of results.
    * This value is passed into your next search call in the `cursor` field.
    */
      [JsonProperty("next_cursor")]
      public string? NextCursor { get; set; }
    }
public class WebAuthnRegistration {
      // The unique ID for the Passkey or WebAuthn registration.
      [JsonProperty("webauthn_registration_id")]
      public required string WebAuthnRegistrationId { get; set; }
      // The `domain` on which Passkey or WebAuthn registration was started. This will be the domain of your app.
      [JsonProperty("domain")]
      public required string Domain { get; set; }
      // The user agent of the User.
      [JsonProperty("user_agent")]
      public required string UserAgent { get; set; }
      /**
    * The verified boolean denotes whether or not this send method, e.g. phone number, email address, etc.,
    * has been successfully authenticated by the User.
    */
      [JsonProperty("verified")]
      public required bool Verified { get; set; }
      /**
    * The `authenticator_type` string displays the requested authenticator type of the Passkey or WebAuthn
    * device. The two valid types are "platform" and "cross-platform". If no value is present, the Passkey or
    * WebAuthn device was created without an authenticator type preference.
    */
      [JsonProperty("authenticator_type")]
      public required string AuthenticatorType { get; set; }
      // The `name` of the Passkey or WebAuthn registration.
      [JsonProperty("name")]
      public required string Name { get; set; }
    }
// Request type for `users.create`.
    public class UsersCreateRequest {
      // The email address of the end user.
      [JsonProperty("email")]
      public string? Email { get; set; }
      // The name of the user. Each field in the name object is optional.
      [JsonProperty("name")]
      public UsersName? Name { get; set; }
      // Provided attributes help with fraud detection.
      [JsonProperty("attributes")]
      public Attributes? Attributes { get; set; }
      /**
    * The phone number to use for one-time passcodes. The phone number should be in E.164 format (i.e.
    * +1XXXXXXXXXX). You may use +10000000000 to test this endpoint, see
    * [Testing](https://stytch.com/docs/home#resources_testing) for more detail.
    */
      [JsonProperty("phone_number")]
      public string? PhoneNumber { get; set; }
      /**
    * Flag for whether or not to save a user as pending vs active in Stytch. Defaults to false.
    *         If true, users will be saved with status pending in Stytch's backend until authenticated.
    *         If false, users will be created as active. An example usage of
    *         a true flag would be to require users to verify their phone by entering the OTP code before
    * creating
    *         an account for them.
    */
      [JsonProperty("create_user_as_pending")]
      public bool? CreateUserAsPending { get; set; }
      /**
    * The `trusted_metadata` field contains an arbitrary JSON object of application-specific data. See the
    * [Metadata](https://stytch.com/docs/api/metadata) reference for complete field behavior details.
    */
      [JsonProperty("trusted_metadata")]
      public object? TrustedMetadata { get; set; }
      /**
    * The `untrusted_metadata` field contains an arbitrary JSON object of application-specific data. Untrusted
    * metadata can be edited by end users directly via the SDK, and **cannot be used to store critical
    * information.** See the [Metadata](https://stytch.com/docs/api/metadata) reference for complete field
    * behavior details.
    */
      [JsonProperty("untrusted_metadata")]
      public object? UntrustedMetadata { get; set; }
    }
// Response type for `users.create`.
    public class UsersCreateResponse {
      /**
    * Globally unique UUID that is returned with every API call. This value is important to log for debugging
    * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    */
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      // The unique ID of the affected User.
      [JsonProperty("user_id")]
      public required string UserId { get; set; }
      // The unique ID of a specific email address.
      [JsonProperty("email_id")]
      public required string EmailId { get; set; }
      // The status of the User. The possible values are `pending` and `active`.
      [JsonProperty("status")]
      public required string Status { get; set; }
      // The unique ID for the phone number.
      [JsonProperty("phone_id")]
      public required string PhoneId { get; set; }
      /**
    * The `user` object affected by this API call. See the
    * [Get user endpoint](https://stytch.com/docs/api/get-user) for complete response field details.
    */
      [JsonProperty("user")]
      public required User User { get; set; }
      /**
    * The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
    * 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
    */
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
    }
// Request type for `users.deleteBiometricRegistration`.
    public class UsersDeleteBiometricRegistrationRequest {
      // The `biometric_registration_id` to be deleted.
      [JsonProperty("biometric_registration_id")]
      public required string BiometricRegistrationId { get; set; }
    }
// Response type for `users.deleteBiometricRegistration`.
    public class UsersDeleteBiometricRegistrationResponse {
      /**
    * Globally unique UUID that is returned with every API call. This value is important to log for debugging
    * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    */
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      // The unique ID of the affected User.
      [JsonProperty("user_id")]
      public required string UserId { get; set; }
      /**
    * The `user` object affected by this API call. See the
    * [Get user endpoint](https://stytch.com/docs/api/get-user) for complete response field details.
    */
      [JsonProperty("user")]
      public required User User { get; set; }
      /**
    * The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
    * 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
    */
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
    }
// Request type for `users.deleteCryptoWallet`.
    public class UsersDeleteCryptoWalletRequest {
      // The `crypto_wallet_id` to be deleted.
      [JsonProperty("crypto_wallet_id")]
      public required string CryptoWalletId { get; set; }
    }
// Response type for `users.deleteCryptoWallet`.
    public class UsersDeleteCryptoWalletResponse {
      /**
    * Globally unique UUID that is returned with every API call. This value is important to log for debugging
    * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    */
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      // The unique ID of the affected User.
      [JsonProperty("user_id")]
      public required string UserId { get; set; }
      /**
    * The `user` object affected by this API call. See the
    * [Get user endpoint](https://stytch.com/docs/api/get-user) for complete response field details.
    */
      [JsonProperty("user")]
      public required User User { get; set; }
      /**
    * The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
    * 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
    */
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
    }
// Request type for `users.deleteEmail`.
    public class UsersDeleteEmailRequest {
      // The `email_id` to be deleted.
      [JsonProperty("email_id")]
      public required string EmailId { get; set; }
    }
// Response type for `users.deleteEmail`.
    public class UsersDeleteEmailResponse {
      /**
    * Globally unique UUID that is returned with every API call. This value is important to log for debugging
    * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    */
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      // The unique ID of the affected User.
      [JsonProperty("user_id")]
      public required string UserId { get; set; }
      /**
    * The `user` object affected by this API call. See the
    * [Get user endpoint](https://stytch.com/docs/api/get-user) for complete response field details.
    */
      [JsonProperty("user")]
      public required User User { get; set; }
      /**
    * The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
    * 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
    */
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
    }
// Request type for `users.deleteOAuthRegistration`.
    public class UsersDeleteOAuthRegistrationRequest {
      // The `oauth_user_registration_id` to be deleted.
      [JsonProperty("oauth_user_registration_id")]
      public required string OAuthUserRegistrationId { get; set; }
    }
// Response type for `users.deleteOAuthRegistration`.
    public class UsersDeleteOAuthRegistrationResponse {
      /**
    * Globally unique UUID that is returned with every API call. This value is important to log for debugging
    * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    */
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      // The unique ID of the affected User.
      [JsonProperty("user_id")]
      public required string UserId { get; set; }
      /**
    * The `user` object affected by this API call. See the
    * [Get user endpoint](https://stytch.com/docs/api/get-user) for complete response field details.
    */
      [JsonProperty("user")]
      public required User User { get; set; }
      /**
    * The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
    * 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
    */
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
    }
// Request type for `users.deletePassword`.
    public class UsersDeletePasswordRequest {
      // The `password_id` to be deleted.
      [JsonProperty("password_id")]
      public required string PasswordId { get; set; }
    }
// Response type for `users.deletePassword`.
    public class UsersDeletePasswordResponse {
      /**
    * Globally unique UUID that is returned with every API call. This value is important to log for debugging
    * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    */
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      // The unique ID of the affected User.
      [JsonProperty("user_id")]
      public required string UserId { get; set; }
      /**
    * The `user` object affected by this API call. See the
    * [Get user endpoint](https://stytch.com/docs/api/get-user) for complete response field details.
    */
      [JsonProperty("user")]
      public required User User { get; set; }
      /**
    * The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
    * 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
    */
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
    }
// Request type for `users.deletePhoneNumber`.
    public class UsersDeletePhoneNumberRequest {
      // The `phone_id` to be deleted.
      [JsonProperty("phone_id")]
      public required string PhoneId { get; set; }
    }
// Response type for `users.deletePhoneNumber`.
    public class UsersDeletePhoneNumberResponse {
      /**
    * Globally unique UUID that is returned with every API call. This value is important to log for debugging
    * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    */
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      // The unique ID of the affected User.
      [JsonProperty("user_id")]
      public required string UserId { get; set; }
      /**
    * The `user` object affected by this API call. See the
    * [Get user endpoint](https://stytch.com/docs/api/get-user) for complete response field details.
    */
      [JsonProperty("user")]
      public required User User { get; set; }
      /**
    * The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
    * 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
    */
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
    }
// Request type for `users.delete`.
    public class UsersDeleteRequest {
      // The unique ID of a specific User.
      [JsonProperty("user_id")]
      public required string UserId { get; set; }
    }
// Response type for `users.delete`.
    public class UsersDeleteResponse {
      /**
    * Globally unique UUID that is returned with every API call. This value is important to log for debugging
    * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    */
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      // The unique ID of the deleted User.
      [JsonProperty("user_id")]
      public required string UserId { get; set; }
      /**
    * The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
    * 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
    */
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
    }
// Request type for `users.deleteTOTP`.
    public class UsersDeleteTOTPRequest {
      // The `totp_id` to be deleted.
      [JsonProperty("totp_id")]
      public required string TOTPId { get; set; }
    }
// Response type for `users.deleteTOTP`.
    public class UsersDeleteTOTPResponse {
      /**
    * Globally unique UUID that is returned with every API call. This value is important to log for debugging
    * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    */
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      // The unique ID of the affected User.
      [JsonProperty("user_id")]
      public required string UserId { get; set; }
      /**
    * The `user` object affected by this API call. See the
    * [Get user endpoint](https://stytch.com/docs/api/get-user) for complete response field details.
    */
      [JsonProperty("user")]
      public required User User { get; set; }
      /**
    * The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
    * 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
    */
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
    }
// Request type for `users.deleteWebAuthnRegistration`.
    public class UsersDeleteWebAuthnRegistrationRequest {
      // The `webauthn_registration_id` to be deleted.
      [JsonProperty("webauthn_registration_id")]
      public required string WebAuthnRegistrationId { get; set; }
    }
// Response type for `users.deleteWebAuthnRegistration`.
    public class UsersDeleteWebAuthnRegistrationResponse {
      /**
    * Globally unique UUID that is returned with every API call. This value is important to log for debugging
    * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    */
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      // The unique ID of the affected User.
      [JsonProperty("user_id")]
      public required string UserId { get; set; }
      /**
    * The `user` object affected by this API call. See the
    * [Get user endpoint](https://stytch.com/docs/api/get-user) for complete response field details.
    */
      [JsonProperty("user")]
      public required User User { get; set; }
      /**
    * The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
    * 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
    */
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
    }
// Request type for `users.exchangePrimaryFactor`.
    public class UsersExchangePrimaryFactorRequest {
      // The unique ID of a specific User.
      [JsonProperty("user_id")]
      public required string UserId { get; set; }
      // The email address to exchange to.
      [JsonProperty("email_address")]
      public string? EmailAddress { get; set; }
      // The phone number to exchange to. The phone number should be in E.164 format (i.e. +1XXXXXXXXXX).
      [JsonProperty("phone_number")]
      public string? PhoneNumber { get; set; }
    }
// Response type for `users.exchangePrimaryFactor`.
    public class UsersExchangePrimaryFactorResponse {
      /**
    * Globally unique UUID that is returned with every API call. This value is important to log for debugging
    * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    */
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      // The unique ID of the affected User.
      [JsonProperty("user_id")]
      public required string UserId { get; set; }
      /**
    * The `user` object affected by this API call. See the
    * [Get user endpoint](https://stytch.com/docs/api/get-user) for complete response field details.
    */
      [JsonProperty("user")]
      public required User User { get; set; }
      /**
    * The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
    * 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
    */
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
    }
// Request type for `users.get`.
    public class UsersGetRequest {
      // The unique ID of a specific User.
      [JsonProperty("user_id")]
      public required string UserId { get; set; }
    }
// Response type for `users.get`.
    public class UsersGetResponse {
      /**
    * Globally unique UUID that is returned with every API call. This value is important to log for debugging
    * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    */
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      // The unique ID of the returned User.
      [JsonProperty("user_id")]
      public required string UserId { get; set; }
      // An array of email objects for the User.
      [JsonProperty("emails")]
      public required UsersEmail Emails { get; set; }
      // The status of the User. The possible values are `pending` and `active`.
      [JsonProperty("status")]
      public required string Status { get; set; }
      // An array of phone number objects linked to the User.
      [JsonProperty("phone_numbers")]
      public required UsersPhoneNumber PhoneNumbers { get; set; }
      /**
    * An array that contains a list of all Passkey or WebAuthn registrations for a given User in the Stytch
    * API.
    */
      [JsonProperty("webauthn_registrations")]
      public required WebAuthnRegistration WebAuthnRegistrations { get; set; }
      // An array of OAuth `provider` objects linked to the User.
      [JsonProperty("providers")]
      public required OAuthProvider Providers { get; set; }
      // An array containing a list of all TOTP instances for a given User in the Stytch API.
      [JsonProperty("totps")]
      public required TOTP TOTPs { get; set; }
      // An array contains a list of all crypto wallets for a given User in the Stytch API.
      [JsonProperty("crypto_wallets")]
      public required CryptoWallet CryptoWallets { get; set; }
      // An array that contains a list of all biometric registrations for a given User in the Stytch API.
      [JsonProperty("biometric_registrations")]
      public required BiometricRegistration BiometricRegistrations { get; set; }
      /**
    * The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
    * 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
    */
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
      // The name of the User. Each field in the `name` object is optional.
      [JsonProperty("name")]
      public UsersName? Name { get; set; }
      /**
    * The timestamp of the User's creation. Values conform to the RFC 3339 standard and are expressed in UTC,
    * e.g. `2021-12-29T12:33:09Z`.
    */
      [JsonProperty("created_at")]
      public string? CreatedAt { get; set; }
      // The password object is returned for users with a password.
      [JsonProperty("password")]
      public Password? Password { get; set; }
      /**
    * The `trusted_metadata` field contains an arbitrary JSON object of application-specific data. See the
    * [Metadata](https://stytch.com/docs/api/metadata) reference for complete field behavior details.
    */
      [JsonProperty("trusted_metadata")]
      public object? TrustedMetadata { get; set; }
      /**
    * The `untrusted_metadata` field contains an arbitrary JSON object of application-specific data. Untrusted
    * metadata can be edited by end users directly via the SDK, and **cannot be used to store critical
    * information.** See the [Metadata](https://stytch.com/docs/api/metadata) reference for complete field
    * behavior details.
    */
      [JsonProperty("untrusted_metadata")]
      public object? UntrustedMetadata { get; set; }
    }
// Request type for `users.search`.
    public class UsersSearchRequest {
      /**
    * The `cursor` field allows you to paginate through your results. Each result array is limited to 1000
    * results. If your query returns more than 1000 results, you will need to paginate the responses using the
    * `cursor`. If you receive a response that includes a non-null `next_cursor` in the `results_metadata`
    * object, repeat the search call with the `next_cursor` value set to the `cursor` field to retrieve the
    * next page of results. Continue to make search calls until the `next_cursor` in the response is null.
    */
      [JsonProperty("cursor")]
      public string? Cursor { get; set; }
      /**
    * The number of search results to return per page. The default limit is 100. A maximum of 1000 results can
    * be returned by a single search request. If the total size of your result set is greater than one page
    * size, you must paginate the response. See the `cursor` field.
    */
      [JsonProperty("limit")]
      public uint? Limit { get; set; }
      /**
    * The optional query object contains the operator, i.e. `AND` or `OR`, and the operands that will filter
    * your results. Only an operator is required. If you include no operands, no filtering will be applied. If
    * you include no query object, it will return all results with no filtering applied.
    */
      [JsonProperty("query")]
      public SearchUsersQuery? Query { get; set; }
    }
// Response type for `users.search`.
    public class UsersSearchResponse {
      /**
    * Globally unique UUID that is returned with every API call. This value is important to log for debugging
    * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    */
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      // An array of results that match your search query.
      [JsonProperty("results")]
      public required User Results { get; set; }
      /**
    * The search `results_metadata` object contains metadata relevant to your specific query like total and
    * `next_cursor`.
    */
      [JsonProperty("results_metadata")]
      public required UsersResultsMetadata ResultsMetadata { get; set; }
      /**
    * The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
    * 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
    */
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
    }
// Request type for `users.update`.
    public class UsersUpdateRequest {
      // The unique ID of a specific User.
      [JsonProperty("user_id")]
      public required string UserId { get; set; }
      // The name of the user. Each field in the name object is optional.
      [JsonProperty("name")]
      public UsersName? Name { get; set; }
      // Provided attributes help with fraud detection.
      [JsonProperty("attributes")]
      public Attributes? Attributes { get; set; }
      /**
    * The `trusted_metadata` field contains an arbitrary JSON object of application-specific data. See the
    * [Metadata](https://stytch.com/docs/api/metadata) reference for complete field behavior details.
    */
      [JsonProperty("trusted_metadata")]
      public object? TrustedMetadata { get; set; }
      /**
    * The `untrusted_metadata` field contains an arbitrary JSON object of application-specific data. Untrusted
    * metadata can be edited by end users directly via the SDK, and **cannot be used to store critical
    * information.** See the [Metadata](https://stytch.com/docs/api/metadata) reference for complete field
    * behavior details.
    */
      [JsonProperty("untrusted_metadata")]
      public object? UntrustedMetadata { get; set; }
    }
// Response type for `users.update`.
    public class UsersUpdateResponse {
      /**
    * Globally unique UUID that is returned with every API call. This value is important to log for debugging
    * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    */
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      // The unique ID of the updated User.
      [JsonProperty("user_id")]
      public required string UserId { get; set; }
      // An array of email objects for the User.
      [JsonProperty("emails")]
      public required UsersEmail Emails { get; set; }
      // An array of phone number objects linked to the User.
      [JsonProperty("phone_numbers")]
      public required UsersPhoneNumber PhoneNumbers { get; set; }
      // An array contains a list of all crypto wallets for a given User in the Stytch API.
      [JsonProperty("crypto_wallets")]
      public required CryptoWallet CryptoWallets { get; set; }
      /**
    * The `user` object affected by this API call. See the
    * [Get user endpoint](https://stytch.com/docs/api/get-user) for complete response field details.
    */
      [JsonProperty("user")]
      public required User User { get; set; }
      /**
    * The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
    * 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
    */
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
    }

public enum SearchUsersQueryOperator
    {
      [EnumMember(Value = "OR")]
      OR,
      [EnumMember(Value = "AND")]
      AND,
    }
}