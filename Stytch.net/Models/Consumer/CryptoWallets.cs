// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Stytch.net.Models.Consumer
{
    public class SIWEParams
    {
        /**
      * Only required if `siwe_params` is passed. The domain that is requesting the crypto wallet signature.
      * Must be an RFC 3986 authority.
      */
        [JsonProperty("domain")]
        public required string Domain { get; set; }

        /**
      * Only required if `siwe_params` is passed. An RFC 3986 URI referring to the resource that is the subject
      * of the signing.
      */
        [JsonProperty("uri")]
        public required string Uri { get; set; }

        /**
      *  A list of information or references to information the user wishes to have resolved as part of
      * authentication. Every resource must be an RFC 3986 URI.
      */
        [JsonProperty("resources")]
        public required string Resources { get; set; }

        /**
      * The EIP-155 Chain ID to which the session is bound. Defaults to 1. Must be the string representation of
      * an integer between 1 and 9,223,372,036,854,775,771, inclusive.
      */
        [JsonProperty("chain_id")]
        public string? ChainId { get; set; }

        /**
      * A human-readable ASCII assertion that the user will sign. The statement may only include reserved,
      * unreserved, or space characters according to RFC 3986 definitions, and must not contain other forms of
      * whitespace such as newlines, tabs, and carriage returns.
      */
        [JsonProperty("statement")]
        public string? Statement { get; set; }

        /**
      * The time when the message was generated. Defaults to the current time. All timestamps in our API conform
      * to the RFC 3339 standard and are expressed in UTC, e.g. `2021-12-29T12:33:09Z`.
      */
        [JsonProperty("issued_at")]
        public string? IssuedAt { get; set; }

        /**
      * The time when the signed authentication message will become valid. Defaults to the current time. All
      * timestamps in our API conform to the RFC 3339 standard and are expressed in UTC, e.g.
      * `2021-12-29T12:33:09Z`.
      */
        [JsonProperty("not_before")]
        public string? NotBefore { get; set; }

        /**
      * A system-specific identifier that may be used to uniquely refer to the sign-in request. The
      * `message_request_id` must be a valid pchar according to RFC 3986 definitions.
      */
        [JsonProperty("message_request_id")]
        public string? MessageRequestId { get; set; }
    }

// Request type for `cryptoWallets.authenticate`.
    public class CryptoWalletsAuthenticateRequest
    {
        /**
      * The type of wallet to authenticate. Currently `ethereum` and `solana` are supported. Wallets for any
      * EVM-compatible chains (such as Polygon or BSC) are also supported and are grouped under the `ethereum`
      * type.
      */
        [JsonProperty("crypto_wallet_type")]
        public required string CryptoWalletType { get; set; }

        // The crypto wallet address to authenticate.
        [JsonProperty("crypto_wallet_address")]
        public required string CryptoWalletAddress { get; set; }

        // The signature from the message challenge.
        [JsonProperty("signature")] public required string Signature { get; set; }

        // The `session_token` associated with a User's existing Session.
        [JsonProperty("session_token")] public string? SessionToken { get; set; }

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

        // The `session_jwt` associated with a User's existing Session.
        [JsonProperty("session_jwt")] public string? SessionJwt { get; set; }

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

// Response type for `cryptoWallets.authenticate`.
    public class CryptoWalletsAuthenticateResponse
    {
        /**
      * Globally unique UUID that is returned with every API call. This value is important to log for debugging
      * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
      */
        [JsonProperty("request_id")]
        public required string RequestId { get; set; }

        // The unique ID of the affected User.
        [JsonProperty("user_id")] public required string UserId { get; set; }

        // A secret token for a given Stytch Session.
        [JsonProperty("session_token")] public required string SessionToken { get; set; }

        // The JSON Web Token (JWT) for a given Stytch Session.
        [JsonProperty("session_jwt")] public required string SessionJwt { get; set; }

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

        /**
      * If you initiate a Session, by including `session_duration_minutes` in your authenticate call, you'll
      * receive a full Session object in the response.
      *
      *   See [GET sessions](https://stytch.com/docs/api/session-get) for complete response fields.
      *
      */
        [JsonProperty("session")]
        public Session? Session { get; set; }

        // The parameters of the Sign In With Ethereum (SIWE) message that was signed.
        [JsonProperty("siwe_params")] public CryptoWalletsSIWEParamsResponse? SiweParams { get; set; }
    }

// Request type for `cryptoWallets.authenticateStart`.
    public class CryptoWalletsAuthenticateStartRequest
    {
        /**
      * The type of wallet to authenticate. Currently `ethereum` and `solana` are supported. Wallets for any
      * EVM-compatible chains (such as Polygon or BSC) are also supported and are grouped under the `ethereum`
      * type.
      */
        [JsonProperty("crypto_wallet_type")]
        public required string CryptoWalletType { get; set; }

        // The crypto wallet address to authenticate.
        [JsonProperty("crypto_wallet_address")]
        public required string CryptoWalletAddress { get; set; }

        // The unique ID of a specific User.
        [JsonProperty("user_id")] public string? UserId { get; set; }

        // The `session_token` associated with a User's existing Session.
        [JsonProperty("session_token")] public string? SessionToken { get; set; }

        // The `session_jwt` associated with a User's existing Session.
        [JsonProperty("session_jwt")] public string? SessionJwt { get; set; }

        /**
      * The parameters for a Sign In With Ethereum (SIWE) message. May only be passed if the
      * `crypto_wallet_type` is `ethereum`.
      */
        [JsonProperty("siwe_params")]
        public SIWEParams? SiweParams { get; set; }
    }

// Response type for `cryptoWallets.authenticateStart`.
    public class CryptoWalletsAuthenticateStartResponse
    {
        /**
      * Globally unique UUID that is returned with every API call. This value is important to log for debugging
      * purposes; we may ask for this value to help identify a specific API call when helping you debug an issue.
      */
        [JsonProperty("request_id")]
        public required string RequestId { get; set; }

        // The unique ID of the affected User.
        [JsonProperty("user_id")] public required string UserId { get; set; }

        // A challenge string to be signed by the wallet in order to prove ownership.
        [JsonProperty("challenge")] public required string Challenge { get; set; }

        // In `login_or_create` endpoints, this field indicates whether or not a User was just created.
        [JsonProperty("user_created")] public required bool UserCreated { get; set; }

        /**
      * The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
      * 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
      */
        [JsonProperty("status_code")]
        public required int StatusCode { get; set; }
    }

    public class CryptoWalletsSIWEParamsResponse
    {
        // The domain that requested the crypto wallet signature.
        [JsonProperty("domain")] public required string Domain { get; set; }

        // An RFC 3986 URI referring to the resource that is the subject of the signing.
        [JsonProperty("uri")] public required string Uri { get; set; }

        // The EIP-155 Chain ID to which the session is bound.
        [JsonProperty("chain_id")] public required string ChainId { get; set; }

        /**
      *  A list of information or references to information the user wishes to have resolved as part of
      * authentication. Every resource must be an RFC 3986 URI.
      */
        [JsonProperty("resources")]
        public required string Resources { get; set; }

        [JsonProperty("status_code")] public required int StatusCode { get; set; }

        /**
      * The time when the message was generated. All timestamps in our API conform to the RFC 3339 standard and
      * are expressed in UTC, e.g. `2021-12-29T12:33:09Z`.
      */
        [JsonProperty("issued_at")]
        public string? IssuedAt { get; set; }

        // A system-specific identifier that may be used to uniquely refer to the sign-in request.
        [JsonProperty("message_request_id")] public string? MessageRequestId { get; set; }
    }
}