// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Stytch.net.Models.Consumer
{
public class AmazonOAuthFactor {
      [JsonProperty("id")]
      public required string Id { get; set; }
      [JsonProperty("provider_subject")]
      public required string ProviderSubject { get; set; }
      [JsonProperty("email_id")]
      public string? EmailId { get; set; }
    }
public class AppleOAuthFactor {
      [JsonProperty("id")]
      public required string Id { get; set; }
      [JsonProperty("provider_subject")]
      public required string ProviderSubject { get; set; }
      [JsonProperty("email_id")]
      public string? EmailId { get; set; }
    }
public class AuthenticationFactor {
      /**
    * The type of authentication factor. The possible values are: `magic_link`, `otp`,
    *        `oauth`, `password`, or `sso`.
    */
      [JsonProperty("type")]
      public required AuthenticationFactorType Type { get; set; }
      /**
    * The method that was used to deliver the authentication factor. The possible values depend on the `type`: 
    *      
    *       `magic_link` – Only `email`.
    *      
    *       `otp` – Only `sms`.
    *      
    *       `oauth` – Either `oauth_google` or `oauth_microsoft`.
    *      
    *       `password` – Only `knowledge`.
    *      
    *       `sso` – Either `sso_saml` or `sso_oidc`.
    *       
    */
      [JsonProperty("delivery_method")]
      public required AuthenticationFactorDeliveryMethod DeliveryMethod { get; set; }
      // The timestamp when the factor was last authenticated.
      [JsonProperty("last_authenticated_at")]
      public string? LastAuthenticatedAt { get; set; }
      // The timestamp when the factor was initially authenticated.
      [JsonProperty("created_at")]
      public string? CreatedAt { get; set; }
      // The timestamp when the factor was last updated.
      [JsonProperty("updated_at")]
      public string? UpdatedAt { get; set; }
      // Information about the email factor, if one is present.
      [JsonProperty("email_factor")]
      public EmailFactor? EmailFactor { get; set; }
      // Information about the phone number factor, if one is present.
      [JsonProperty("phone_number_factor")]
      public PhoneNumberFactor? PhoneNumberFactor { get; set; }
      // Information about the Google OAuth factor, if one is present.
      [JsonProperty("google_oauth_factor")]
      public GoogleOAuthFactor? GoogleOAuthFactor { get; set; }
      // Information about the Microsoft OAuth factor, if one is present.
      [JsonProperty("microsoft_oauth_factor")]
      public MicrosoftOAuthFactor? MicrosoftOAuthFactor { get; set; }
      [JsonProperty("apple_oauth_factor")]
      public AppleOAuthFactor? AppleOAuthFactor { get; set; }
      [JsonProperty("webauthn_factor")]
      public WebAuthnFactor? WebAuthnFactor { get; set; }
      // Information about the TOTP-backed Authenticator App factor, if one is present.
      [JsonProperty("authenticator_app_factor")]
      public AuthenticatorAppFactor? AuthenticatorAppFactor { get; set; }
      [JsonProperty("github_oauth_factor")]
      public GithubOAuthFactor? GithubOAuthFactor { get; set; }
      [JsonProperty("recovery_code_factor")]
      public RecoveryCodeFactor? RecoveryCodeFactor { get; set; }
      [JsonProperty("facebook_oauth_factor")]
      public FacebookOAuthFactor? FacebookOAuthFactor { get; set; }
      [JsonProperty("crypto_wallet_factor")]
      public CryptoWalletFactor? CryptoWalletFactor { get; set; }
      [JsonProperty("amazon_oauth_factor")]
      public AmazonOAuthFactor? AmazonOAuthFactor { get; set; }
      [JsonProperty("bitbucket_oauth_factor")]
      public BitbucketOAuthFactor? BitbucketOAuthFactor { get; set; }
      [JsonProperty("coinbase_oauth_factor")]
      public CoinbaseOAuthFactor? CoinbaseOAuthFactor { get; set; }
      [JsonProperty("discord_oauth_factor")]
      public DiscordOAuthFactor? DiscordOAuthFactor { get; set; }
      [JsonProperty("figma_oauth_factor")]
      public FigmaOAuthFactor? FigmaOAuthFactor { get; set; }
      [JsonProperty("git_lab_oauth_factor")]
      public GitLabOAuthFactor? GitLabOAuthFactor { get; set; }
      [JsonProperty("instagram_oauth_factor")]
      public InstagramOAuthFactor? InstagramOAuthFactor { get; set; }
      [JsonProperty("linked_in_oauth_factor")]
      public LinkedInOAuthFactor? LinkedInOAuthFactor { get; set; }
      [JsonProperty("shopify_oauth_factor")]
      public ShopifyOAuthFactor? ShopifyOAuthFactor { get; set; }
      [JsonProperty("slack_oauth_factor")]
      public SlackOAuthFactor? SlackOAuthFactor { get; set; }
      [JsonProperty("snapchat_oauth_factor")]
      public SnapchatOAuthFactor? SnapchatOAuthFactor { get; set; }
      [JsonProperty("spotify_oauth_factor")]
      public SpotifyOAuthFactor? SpotifyOAuthFactor { get; set; }
      [JsonProperty("steam_oauth_factor")]
      public SteamOAuthFactor? SteamOAuthFactor { get; set; }
      [JsonProperty("tik_tok_oauth_factor")]
      public TikTokOAuthFactor? TikTokOAuthFactor { get; set; }
      [JsonProperty("twitch_oauth_factor")]
      public TwitchOAuthFactor? TwitchOAuthFactor { get; set; }
      [JsonProperty("twitter_oauth_factor")]
      public TwitterOAuthFactor? TwitterOAuthFactor { get; set; }
      [JsonProperty("embeddable_magic_link_factor")]
      public EmbeddableMagicLinkFactor? EmbeddableMagicLinkFactor { get; set; }
      [JsonProperty("biometric_factor")]
      public BiometricFactor? BiometricFactor { get; set; }
      // Information about the SAML SSO factor, if one is present.
      [JsonProperty("saml_sso_factor")]
      public SAMLSSOFactor? SAMLSSOFactor { get; set; }
      // Information about the OIDC SSO factor, if one is present.
      [JsonProperty("oidc_sso_factor")]
      public OIDCSSOFactor? OIDCSSOFactor { get; set; }
      [JsonProperty("salesforce_oauth_factor")]
      public SalesforceOAuthFactor? SalesforceOAuthFactor { get; set; }
      [JsonProperty("yahoo_oauth_factor")]
      public YahooOAuthFactor? YahooOAuthFactor { get; set; }
      [JsonProperty("hubspot_oauth_factor")]
      public HubspotOAuthFactor? HubspotOAuthFactor { get; set; }
      [JsonProperty("slack_oauth_exchange_factor")]
      public SlackOAuthExchangeFactor? SlackOAuthExchangeFactor { get; set; }
      [JsonProperty("hubspot_oauth_exchange_factor")]
      public HubspotOAuthExchangeFactor? HubspotOAuthExchangeFactor { get; set; }
      [JsonProperty("strava_oauth_factor")]
      public StravaOAuthFactor? StravaOAuthFactor { get; set; }
    }
public class AuthenticatorAppFactor {
      // Globally unique UUID that identifies a TOTP instance.
      [JsonProperty("totp_id")]
      public required string TOTPId { get; set; }
    }
public class BiometricFactor {
      [JsonProperty("biometric_registration_id")]
      public required string BiometricRegistrationId { get; set; }
    }
public class BitbucketOAuthFactor {
      [JsonProperty("id")]
      public required string Id { get; set; }
      [JsonProperty("provider_subject")]
      public required string ProviderSubject { get; set; }
      [JsonProperty("email_id")]
      public string? EmailId { get; set; }
    }
public class CoinbaseOAuthFactor {
      [JsonProperty("id")]
      public required string Id { get; set; }
      [JsonProperty("provider_subject")]
      public required string ProviderSubject { get; set; }
      [JsonProperty("email_id")]
      public string? EmailId { get; set; }
    }
public class CryptoWalletFactor {
      [JsonProperty("crypto_wallet_id")]
      public required string CryptoWalletId { get; set; }
      [JsonProperty("crypto_wallet_address")]
      public required string CryptoWalletAddress { get; set; }
      [JsonProperty("crypto_wallet_type")]
      public required string CryptoWalletType { get; set; }
    }
public class DiscordOAuthFactor {
      [JsonProperty("id")]
      public required string Id { get; set; }
      [JsonProperty("provider_subject")]
      public required string ProviderSubject { get; set; }
      [JsonProperty("email_id")]
      public string? EmailId { get; set; }
    }
public class EmailFactor {
      // The globally unique UUID of the Member's email.
      [JsonProperty("email_id")]
      public required string EmailId { get; set; }
      // The email address of the Member.
      [JsonProperty("email_address")]
      public required string EmailAddress { get; set; }
    }
public class EmbeddableMagicLinkFactor {
      [JsonProperty("embedded_id")]
      public required string EmbeddedId { get; set; }
    }
public class FacebookOAuthFactor {
      [JsonProperty("id")]
      public required string Id { get; set; }
      [JsonProperty("provider_subject")]
      public required string ProviderSubject { get; set; }
      [JsonProperty("email_id")]
      public string? EmailId { get; set; }
    }
public class FigmaOAuthFactor {
      [JsonProperty("id")]
      public required string Id { get; set; }
      [JsonProperty("provider_subject")]
      public required string ProviderSubject { get; set; }
      [JsonProperty("email_id")]
      public string? EmailId { get; set; }
    }
public class GitLabOAuthFactor {
      [JsonProperty("id")]
      public required string Id { get; set; }
      [JsonProperty("provider_subject")]
      public required string ProviderSubject { get; set; }
      [JsonProperty("email_id")]
      public string? EmailId { get; set; }
    }
public class GithubOAuthFactor {
      [JsonProperty("id")]
      public required string Id { get; set; }
      [JsonProperty("provider_subject")]
      public required string ProviderSubject { get; set; }
      [JsonProperty("email_id")]
      public string? EmailId { get; set; }
    }
public class GoogleOAuthFactor {
      // The unique ID of an OAuth registration.
      [JsonProperty("id")]
      public required string Id { get; set; }
      /**
    * The unique identifier for the User within a given OAuth provider. Also commonly called the `sub` or
    * "Subject field" in OAuth protocols.
    */
      [JsonProperty("provider_subject")]
      public required string ProviderSubject { get; set; }
      // The globally unique UUID of the Member's email.
      [JsonProperty("email_id")]
      public string? EmailId { get; set; }
    }
public class HubspotOAuthExchangeFactor {
      [JsonProperty("email_id")]
      public required string EmailId { get; set; }
    }
public class HubspotOAuthFactor {
      [JsonProperty("id")]
      public required string Id { get; set; }
      [JsonProperty("provider_subject")]
      public required string ProviderSubject { get; set; }
      [JsonProperty("email_id")]
      public string? EmailId { get; set; }
    }
public class InstagramOAuthFactor {
      [JsonProperty("id")]
      public required string Id { get; set; }
      [JsonProperty("provider_subject")]
      public required string ProviderSubject { get; set; }
      [JsonProperty("email_id")]
      public string? EmailId { get; set; }
    }
public class JWK {
      [JsonProperty("kty")]
      public required string Kty { get; set; }
      [JsonProperty("use")]
      public required string Use { get; set; }
      [JsonProperty("key_ops")]
      public required string KeyOps { get; set; }
      [JsonProperty("alg")]
      public required string Alg { get; set; }
      [JsonProperty("kid")]
      public required string Kid { get; set; }
      [JsonProperty("x5c")]
      public required string X5C { get; set; }
      [JsonProperty("x5tS256")]
      public required string X5TS256 { get; set; }
      [JsonProperty("n")]
      public required string N { get; set; }
      [JsonProperty("e")]
      public required string E { get; set; }
    }
public class LinkedInOAuthFactor {
      [JsonProperty("id")]
      public required string Id { get; set; }
      [JsonProperty("provider_subject")]
      public required string ProviderSubject { get; set; }
      [JsonProperty("email_id")]
      public string? EmailId { get; set; }
    }
public class MicrosoftOAuthFactor {
      // The unique ID of an OAuth registration.
      [JsonProperty("id")]
      public required string Id { get; set; }
      /**
    * The unique identifier for the User within a given OAuth provider. Also commonly called the `sub` or
    * "Subject field" in OAuth protocols.
    */
      [JsonProperty("provider_subject")]
      public required string ProviderSubject { get; set; }
      // The globally unique UUID of the Member's email.
      [JsonProperty("email_id")]
      public string? EmailId { get; set; }
    }
public class OIDCSSOFactor {
      // The unique ID of an SSO Registration.
      [JsonProperty("id")]
      public required string Id { get; set; }
      // Globally unique UUID that identifies a specific OIDC Connection.
      [JsonProperty("provider_id")]
      public required string ProviderId { get; set; }
      // The ID of the member given by the identity provider.
      [JsonProperty("external_id")]
      public required string ExternalId { get; set; }
    }
public class PhoneNumberFactor {
      // The globally unique UUID of the Member's phone number.
      [JsonProperty("phone_id")]
      public required string PhoneId { get; set; }
      // The phone number of the Member.
      [JsonProperty("phone_number")]
      public required string PhoneNumber { get; set; }
    }
public class RecoveryCodeFactor {
      [JsonProperty("totp_recovery_code_id")]
      public required string TOTPRecoveryCodeId { get; set; }
    }
public class SAMLSSOFactor {
      // The unique ID of an SSO Registration.
      [JsonProperty("id")]
      public required string Id { get; set; }
      // Globally unique UUID that identifies a specific SAML Connection.
      [JsonProperty("provider_id")]
      public required string ProviderId { get; set; }
      // The ID of the member given by the identity provider.
      [JsonProperty("external_id")]
      public required string ExternalId { get; set; }
    }
public class SalesforceOAuthFactor {
      [JsonProperty("id")]
      public required string Id { get; set; }
      [JsonProperty("provider_subject")]
      public required string ProviderSubject { get; set; }
      [JsonProperty("email_id")]
      public string? EmailId { get; set; }
    }
public class Session {
      // A unique identifier for a specific Session.
      [JsonProperty("session_id")]
      public required string SessionId { get; set; }
      // The unique ID of the affected User.
      [JsonProperty("user_id")]
      public required string UserId { get; set; }
      // An array of different authentication factors that comprise a Session.
      [JsonProperty("authentication_factors")]
      public required AuthenticationFactor AuthenticationFactors { get; set; }
      /**
    * The timestamp when the Session was created. Values conform to the RFC 3339 standard and are expressed in
    * UTC, e.g. `2021-12-29T12:33:09Z`.
    */
      [JsonProperty("started_at")]
      public string? StartedAt { get; set; }
      /**
    * The timestamp when the Session was last accessed. Values conform to the RFC 3339 standard and are
    * expressed in UTC, e.g. `2021-12-29T12:33:09Z`.
    */
      [JsonProperty("last_accessed_at")]
      public string? LastAccessedAt { get; set; }
      /**
    * The timestamp when the Session expires. Values conform to the RFC 3339 standard and are expressed in
    * UTC, e.g. `2021-12-29T12:33:09Z`.
    */
      [JsonProperty("expires_at")]
      public string? ExpiresAt { get; set; }
      // Provided attributes help with fraud detection.
      [JsonProperty("attributes")]
      public Attributes? Attributes { get; set; }
      /**
    * The custom claims map for a Session. Claims can be added to a session during a Sessions authenticate
    * call.
    */
      [JsonProperty("custom_claims")]
      public object? CustomClaims { get; set; }
    }
public class ShopifyOAuthFactor {
      [JsonProperty("id")]
      public required string Id { get; set; }
      [JsonProperty("provider_subject")]
      public required string ProviderSubject { get; set; }
      [JsonProperty("email_id")]
      public string? EmailId { get; set; }
    }
public class SlackOAuthExchangeFactor {
      [JsonProperty("email_id")]
      public required string EmailId { get; set; }
    }
public class SlackOAuthFactor {
      [JsonProperty("id")]
      public required string Id { get; set; }
      [JsonProperty("provider_subject")]
      public required string ProviderSubject { get; set; }
      [JsonProperty("email_id")]
      public string? EmailId { get; set; }
    }
public class SnapchatOAuthFactor {
      [JsonProperty("id")]
      public required string Id { get; set; }
      [JsonProperty("provider_subject")]
      public required string ProviderSubject { get; set; }
      [JsonProperty("email_id")]
      public string? EmailId { get; set; }
    }
public class SpotifyOAuthFactor {
      [JsonProperty("id")]
      public required string Id { get; set; }
      [JsonProperty("provider_subject")]
      public required string ProviderSubject { get; set; }
      [JsonProperty("email_id")]
      public string? EmailId { get; set; }
    }
public class SteamOAuthFactor {
      [JsonProperty("id")]
      public required string Id { get; set; }
      [JsonProperty("provider_subject")]
      public required string ProviderSubject { get; set; }
      [JsonProperty("email_id")]
      public string? EmailId { get; set; }
    }
public class StravaOAuthFactor {
      [JsonProperty("id")]
      public required string Id { get; set; }
      [JsonProperty("provider_subject")]
      public required string ProviderSubject { get; set; }
      [JsonProperty("email_id")]
      public string? EmailId { get; set; }
    }
public class TikTokOAuthFactor {
      [JsonProperty("id")]
      public required string Id { get; set; }
      [JsonProperty("provider_subject")]
      public required string ProviderSubject { get; set; }
      [JsonProperty("email_id")]
      public string? EmailId { get; set; }
    }
public class TwitchOAuthFactor {
      [JsonProperty("id")]
      public required string Id { get; set; }
      [JsonProperty("provider_subject")]
      public required string ProviderSubject { get; set; }
      [JsonProperty("email_id")]
      public string? EmailId { get; set; }
    }
public class TwitterOAuthFactor {
      [JsonProperty("id")]
      public required string Id { get; set; }
      [JsonProperty("provider_subject")]
      public required string ProviderSubject { get; set; }
      [JsonProperty("email_id")]
      public string? EmailId { get; set; }
    }
public class WebAuthnFactor {
      [JsonProperty("webauthn_registration_id")]
      public required string WebAuthnRegistrationId { get; set; }
      [JsonProperty("domain")]
      public required string Domain { get; set; }
      [JsonProperty("user_agent")]
      public string? UserAgent { get; set; }
    }
public class YahooOAuthFactor {
      [JsonProperty("id")]
      public required string Id { get; set; }
      [JsonProperty("provider_subject")]
      public required string ProviderSubject { get; set; }
      [JsonProperty("email_id")]
      public string? EmailId { get; set; }
    }
// Request type for `sessions.authenticate`.
    public class SessionsAuthenticateRequest {
      // The session token to authenticate.
      [JsonProperty("session_token")]
      public string? SessionToken { get; set; }
      /**
    * Set the session lifetime to be this many minutes from now; minimum of 5 and a maximum of 527040 minutes
    * (366 days). Note that a successful authentication will continue to extend the session this many minutes.
    */
      [JsonProperty("session_duration_minutes")]
      public int? SessionDurationMinutes { get; set; }
      /**
    * The JWT to authenticate. You may provide a JWT that has expired according to its `exp` claim and needs
    * to be refreshed. If the signature is valid and the underlying session is still active then Stytch will
    * return a new JWT.
    */
      [JsonProperty("session_jwt")]
      public string? SessionJwt { get; set; }
      /**
    * Add a custom claims map to the Session being authenticated. Claims are only created if a Session is
    * initialized by providing a value in `session_duration_minutes`. Claims will be included on the Session
    * object and in the JWT. To update a key in an existing Session, supply a new value. To delete a key,
    * supply a null value.
    * 
    *   Custom claims made with reserved claims ("iss", "sub", "aud", "exp", "nbf", "iat", "jti") will be
    * ignored. Total custom claims size cannot exceed four kilobytes.
    */
      [JsonProperty("session_custom_claims")]
      public object? SessionCustomClaims { get; set; }
    }
// Response type for `sessions.authenticate`.
    public class SessionsAuthenticateResponse {
      /**
    * Globally unique UUID that is returned with every API call. This value is important to log for debugging
    * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    */
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      /**
    * If you initiate a Session, by including `session_duration_minutes` in your authenticate call, you'll
    * receive a full Session object in the response.
    * 
    *   See [GET sessions](https://stytch.com/docs/api/session-get) for complete response fields.
    *   
    */
      [JsonProperty("session")]
      public required Session Session { get; set; }
      // A secret token for a given Stytch Session.
      [JsonProperty("session_token")]
      public required string SessionToken { get; set; }
      // The JSON Web Token (JWT) for a given Stytch Session.
      [JsonProperty("session_jwt")]
      public required string SessionJwt { get; set; }
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
// Request type for `sessions.getJWKS`.
    public class SessionsGetJWKSRequest {
      // The `project_id` to get the JWKS for.
      [JsonProperty("project_id")]
      public required string ProjectId { get; set; }
    }
// Response type for `sessions.getJWKS`.
    public class SessionsGetJWKSResponse {
      // The JWK
      [JsonProperty("keys")]
      public required JWK Keys { get; set; }
      /**
    * Globally unique UUID that is returned with every API call. This value is important to log for debugging
    * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    */
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      /**
    * The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
    * 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
    */
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
    }
// Request type for `sessions.get`.
    public class SessionsGetRequest {
      // The `user_id` to get active Sessions for.
      [JsonProperty("user_id")]
      public required string UserId { get; set; }
    }
// Response type for `sessions.get`.
    public class SessionsGetResponse {
      /**
    * Globally unique UUID that is returned with every API call. This value is important to log for debugging
    * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    */
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      // An array of Session objects.
      [JsonProperty("sessions")]
      public required Session Sessions { get; set; }
      /**
    * The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
    * 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
    */
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
    }
// Request type for `sessions.migrate`.
    public class SessionsMigrateRequest {
      // The `session_token` associated with a User's existing Session.
      [JsonProperty("session_token")]
      public required string SessionToken { get; set; }
      /**
    * Set the session lifetime to be this many minutes from now. This will start a new session if one doesn't
    * already exist, 
    *   returning both an opaque `session_token` and `session_jwt` for this session. Remember that the
    * `session_jwt` will have a fixed lifetime of
    *   five minutes regardless of the underlying session duration, and will need to be refreshed over time.
    * 
    *   This value must be a minimum of 5 and a maximum of 527040 minutes (366 days).
    *   
    *   If a `session_token` or `session_jwt` is provided then a successful authentication will continue to
    * extend the session this many minutes.
    *   
    *   If the `session_duration_minutes` parameter is not specified, a Stytch session will not be created.
    */
      [JsonProperty("session_duration_minutes")]
      public int? SessionDurationMinutes { get; set; }
      /**
    * Add a custom claims map to the Session being authenticated. Claims are only created if a Session is
    * initialized by providing a value in `session_duration_minutes`. Claims will be included on the Session
    * object and in the JWT. To update a key in an existing Session, supply a new value. To delete a key,
    * supply a null value.
    * 
    *   Custom claims made with reserved claims ("iss", "sub", "aud", "exp", "nbf", "iat", "jti") will be
    * ignored. Total custom claims size cannot exceed four kilobytes.
    */
      [JsonProperty("session_custom_claims")]
      public object? SessionCustomClaims { get; set; }
    }
// Response type for `sessions.migrate`.
    public class SessionsMigrateResponse {
      /**
    * Globally unique UUID that is returned with every API call. This value is important to log for debugging
    * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    */
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      // The unique ID of the affected User.
      [JsonProperty("user_id")]
      public required string UserId { get; set; }
      // A secret token for a given Stytch Session.
      [JsonProperty("session_token")]
      public required string SessionToken { get; set; }
      // The JSON Web Token (JWT) for a given Stytch Session.
      [JsonProperty("session_jwt")]
      public required string SessionJwt { get; set; }
      /**
    * The `user` object affected by this API call. See the
    * [Get user endpoint](https://stytch.com/docs/api/get-user) for complete response field details.
    */
      [JsonProperty("user")]
      public required User User { get; set; }
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
      /**
    * If you initiate a Session, by including `session_duration_minutes` in your authenticate call, you'll
    * receive a full Session object in the response.
    * 
    *   See [GET sessions](https://stytch.com/docs/api/session-get) for complete response fields.
    *   
    */
      [JsonProperty("session")]
      public Session? Session { get; set; }
    }
// Request type for `sessions.revoke`.
    public class SessionsRevokeRequest {
      // The `session_id` to revoke.
      [JsonProperty("session_id")]
      public string? SessionId { get; set; }
      // The session token to revoke.
      [JsonProperty("session_token")]
      public string? SessionToken { get; set; }
      // A JWT for the session to revoke.
      [JsonProperty("session_jwt")]
      public string? SessionJwt { get; set; }
    }
// Response type for `sessions.revoke`.
    public class SessionsRevokeResponse {
      /**
    * Globally unique UUID that is returned with every API call. This value is important to log for debugging
    * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
    */
      [JsonProperty("request_id")]
      public required string RequestId { get; set; }
      /**
    * The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
    * 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
    */
      [JsonProperty("status_code")]
      public required int StatusCode { get; set; }
    }

public enum AuthenticationFactorDeliveryMethod
    {
      [EnumMember(Value = "email")]
      EMAIL,
      [EnumMember(Value = "sms")]
      SMS,
      [EnumMember(Value = "whatsapp")]
      WHATSAPP,
      [EnumMember(Value = "embedded")]
      EMBEDDED,
      [EnumMember(Value = "oauth_google")]
      OAUTH_GOOGLE,
      [EnumMember(Value = "oauth_microsoft")]
      OAUTH_MICROSOFT,
      [EnumMember(Value = "oauth_apple")]
      OAUTH_APPLE,
      [EnumMember(Value = "webauthn_registration")]
      WEBAUTHN_REGISTRATION,
      [EnumMember(Value = "authenticator_app")]
      AUTHENTICATOR_APP,
      [EnumMember(Value = "oauth_github")]
      OAUTH_GITHUB,
      [EnumMember(Value = "recovery_code")]
      RECOVERY_CODE,
      [EnumMember(Value = "oauth_facebook")]
      OAUTH_FACEBOOK,
      [EnumMember(Value = "crypto_wallet")]
      CRYPTO_WALLET,
      [EnumMember(Value = "oauth_amazon")]
      OAUTH_AMAZON,
      [EnumMember(Value = "oauth_bitbucket")]
      OAUTH_BITBUCKET,
      [EnumMember(Value = "oauth_coinbase")]
      OAUTH_COINBASE,
      [EnumMember(Value = "oauth_discord")]
      OAUTH_DISCORD,
      [EnumMember(Value = "oauth_figma")]
      OAUTH_FIGMA,
      [EnumMember(Value = "oauth_gitlab")]
      OAUTH_GITLAB,
      [EnumMember(Value = "oauth_instagram")]
      OAUTH_INSTAGRAM,
      [EnumMember(Value = "oauth_linkedin")]
      OAUTH_LINKEDIN,
      [EnumMember(Value = "oauth_shopify")]
      OAUTH_SHOPIFY,
      [EnumMember(Value = "oauth_slack")]
      OAUTH_SLACK,
      [EnumMember(Value = "oauth_snapchat")]
      OAUTH_SNAPCHAT,
      [EnumMember(Value = "oauth_spotify")]
      OAUTH_SPOTIFY,
      [EnumMember(Value = "oauth_steam")]
      OAUTH_STEAM,
      [EnumMember(Value = "oauth_tiktok")]
      OAUTH_TIKTOK,
      [EnumMember(Value = "oauth_twitch")]
      OAUTH_TWITCH,
      [EnumMember(Value = "oauth_twitter")]
      OAUTH_TWITTER,
      [EnumMember(Value = "knowledge")]
      KNOWLEDGE,
      [EnumMember(Value = "biometric")]
      BIOMETRIC,
      [EnumMember(Value = "sso_saml")]
      SSO_SAML,
      [EnumMember(Value = "sso_oidc")]
      SSO_OIDC,
      [EnumMember(Value = "oauth_salesforce")]
      OAUTH_SALESFORCE,
      [EnumMember(Value = "oauth_yahoo")]
      OAUTH_YAHOO,
      [EnumMember(Value = "oauth_hubspot")]
      OAUTH_HUBSPOT,
      [EnumMember(Value = "imported_auth0")]
      IMPORTED_AUTH0,
      [EnumMember(Value = "oauth_exchange_slack")]
      OAUTH_EXCHANGE_SLACK,
      [EnumMember(Value = "oauth_exchange_hubspot")]
      OAUTH_EXCHANGE_HUBSPOT,
      [EnumMember(Value = "oauth_strava")]
      OAUTH_STRAVA,
    }
public enum AuthenticationFactorType
    {
      [EnumMember(Value = "magic_link")]
      MAGIC_LINK,
      [EnumMember(Value = "otp")]
      OTP,
      [EnumMember(Value = "oauth")]
      OAUTH,
      [EnumMember(Value = "webauthn")]
      WEBAUTHN,
      [EnumMember(Value = "totp")]
      TOTP,
      [EnumMember(Value = "crypto")]
      CRYPTO,
      [EnumMember(Value = "password")]
      PASSWORD,
      [EnumMember(Value = "signature_challenge")]
      SIGNATURE_CHALLENGE,
      [EnumMember(Value = "sso")]
      SSO,
      [EnumMember(Value = "imported")]
      IMPORTED,
      [EnumMember(Value = "recovery_codes")]
      RECOVERY_CODES,
    }
}