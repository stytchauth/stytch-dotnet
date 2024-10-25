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
    public class SIWEParams
    {
        /// <summary>
        /// Only required if `siwe_params` is passed. The domain that is requesting the crypto wallet signature.
        /// Must be an RFC 3986 authority.
        /// </summary>
        [JsonProperty("domain")]
        public string Domain { get; set; }
        /// <summary>
        /// Only required if `siwe_params` is passed. An RFC 3986 URI referring to the resource that is the subject
        /// of the signing.
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; set; }
        /// <summary>
        ///  A list of information or references to information the user wishes to have resolved as part of
        /// authentication. Every resource must be an RFC 3986 URI.
        /// </summary>
        [JsonProperty("resources")]
        public List<string> Resources { get; set; }
        /// <summary>
        /// The EIP-155 Chain ID to which the session is bound. Defaults to 1. Must be the string representation of
        /// an integer between 1 and 9,223,372,036,854,775,771, inclusive.
        /// </summary>
        [JsonProperty("chain_id")]
        public string ChainId { get; set; }
        /// <summary>
        /// A human-readable ASCII assertion that the user will sign. The statement may only include reserved,
        /// unreserved, or space characters according to RFC 3986 definitions, and must not contain other forms of
        /// whitespace such as newlines, tabs, and carriage returns.
        /// </summary>
        [JsonProperty("statement")]
        public string Statement { get; set; }
        /// <summary>
        /// The time when the message was generated. Defaults to the current time. All timestamps in our API conform
        /// to the RFC 3339 standard and are expressed in UTC, e.g. `2021-12-29T12:33:09Z`.
        /// </summary>
        [JsonProperty("issued_at")]
        public DateTime? IssuedAt { get; set; }
        /// <summary>
        /// The time when the signed authentication message will become valid. Defaults to the current time. All
        /// timestamps in our API conform to the RFC 3339 standard and are expressed in UTC, e.g.
        /// `2021-12-29T12:33:09Z`.
        /// </summary>
        [JsonProperty("not_before")]
        public DateTime? NotBefore { get; set; }
        /// <summary>
        /// A system-specific identifier that may be used to uniquely refer to the sign-in request. The
        /// `message_request_id` must be a valid pchar according to RFC 3986 definitions.
        /// </summary>
        [JsonProperty("message_request_id")]
        public string MessageRequestId { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.Consumer.CryptoWallets.Authenticate"/>..
    /// </summary>
    public class CryptoWalletsAuthenticateRequest
    {
        /// <summary>
        /// The type of wallet to authenticate. Currently `ethereum` and `solana` are supported. Wallets for any
        /// EVM-compatible chains (such as Polygon or BSC) are also supported and are grouped under the `ethereum`
        /// type.
        /// </summary>
        [JsonProperty("crypto_wallet_type")]
        public string CryptoWalletType { get; set; }
        /// <summary>
        /// The crypto wallet address to authenticate.
        /// </summary>
        [JsonProperty("crypto_wallet_address")]
        public string CryptoWalletAddress { get; set; }
        /// <summary>
        /// The signature from the message challenge.
        /// </summary>
        [JsonProperty("signature")]
        public string Signature { get; set; }
        /// <summary>
        /// The `session_token` associated with a User's existing Session.
        /// </summary>
        [JsonProperty("session_token")]
        public string SessionToken { get; set; }
        /// <summary>
        /// Set the session lifetime to be this many minutes from now. This will start a new session if one doesn't
        /// already exist, 
        ///   returning both an opaque `session_token` and `session_jwt` for this session. Remember that the
        /// `session_jwt` will have a fixed lifetime of
        ///   five minutes regardless of the underlying session duration, and will need to be refreshed over time.
        /// 
        ///   This value must be a minimum of 5 and a maximum of 527040 minutes (366 days).
        ///   
        ///   If a `session_token` or `session_jwt` is provided then a successful authentication will continue to
        /// extend the session this many minutes.
        ///   
        ///   If the `session_duration_minutes` parameter is not specified, a Stytch session will not be created.
        /// </summary>
        [JsonProperty("session_duration_minutes")]
        public int? SessionDurationMinutes { get; set; }
        /// <summary>
        /// The `session_jwt` associated with a User's existing Session.
        /// </summary>
        [JsonProperty("session_jwt")]
        public string SessionJwt { get; set; }
        /// <summary>
        /// Add a custom claims map to the Session being authenticated. Claims are only created if a Session is
        /// initialized by providing a value in `session_duration_minutes`. Claims will be included on the Session
        /// object and in the JWT. To update a key in an existing Session, supply a new value. To delete a key,
        /// supply a null value.
        /// 
        ///   Custom claims made with reserved claims ("iss", "sub", "aud", "exp", "nbf", "iat", "jti") will be
        /// ignored. Total custom claims size cannot exceed four kilobytes.
        /// </summary>
        [JsonProperty("session_custom_claims")]
        public object SessionCustomClaims { get; set; }
        public CryptoWalletsAuthenticateRequest(string cryptoWalletType, string cryptoWalletAddress, string signature)
        {
            this.CryptoWalletType = cryptoWalletType;
            this.CryptoWalletAddress = cryptoWalletAddress;
            this.Signature = signature;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.Consumer.CryptoWallets.Authenticate"/>..
    /// </summary>
    public class CryptoWalletsAuthenticateResponse
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
        /// A secret token for a given Stytch Session.
        /// </summary>
        [JsonProperty("session_token")]
        public string SessionToken { get; set; }
        /// <summary>
        /// The JSON Web Token (JWT) for a given Stytch Session.
        /// </summary>
        [JsonProperty("session_jwt")]
        public string SessionJwt { get; set; }
        /// <summary>
        /// The `user` object affected by this API call. See the
        /// [Get user endpoint](https://stytch.com/docs/api/get-user) for complete response field details.
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }
        /// <summary>
        /// The HTTP status code of the response. Stytch follows standard HTTP response status code patterns, e.g.
        /// 2XX values equate to success, 3XX values are redirects, 4XX are client errors, and 5XX are server errors.
        /// </summary>
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
        /// <summary>
        /// If you initiate a Session, by including `session_duration_minutes` in your authenticate call, you'll
        /// receive a full Session object in the response.
        /// 
        ///   See [GET sessions](https://stytch.com/docs/api/session-get) for complete response fields.
        ///   
        /// </summary>
        [JsonProperty("session")]
        public Session Session { get; set; }
        /// <summary>
        /// The parameters of the Sign In With Ethereum (SIWE) message that was signed.
        /// </summary>
        [JsonProperty("siwe_params")]
        public CryptoWalletsSIWEParamsResponse SiweParams { get; set; }
    }
    /// <summary>
    /// Request type for <see cref="Stytch.net.Clients.Consumer.CryptoWallets.AuthenticateStart"/>..
    /// </summary>
    public class CryptoWalletsAuthenticateStartRequest
    {
        /// <summary>
        /// The type of wallet to authenticate. Currently `ethereum` and `solana` are supported. Wallets for any
        /// EVM-compatible chains (such as Polygon or BSC) are also supported and are grouped under the `ethereum`
        /// type.
        /// </summary>
        [JsonProperty("crypto_wallet_type")]
        public string CryptoWalletType { get; set; }
        /// <summary>
        /// The crypto wallet address to authenticate.
        /// </summary>
        [JsonProperty("crypto_wallet_address")]
        public string CryptoWalletAddress { get; set; }
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
        /// The parameters for a Sign In With Ethereum (SIWE) message. May only be passed if the
        /// `crypto_wallet_type` is `ethereum`.
        /// </summary>
        [JsonProperty("siwe_params")]
        public SIWEParams SiweParams { get; set; }
        public CryptoWalletsAuthenticateStartRequest(string cryptoWalletType, string cryptoWalletAddress)
        {
            this.CryptoWalletType = cryptoWalletType;
            this.CryptoWalletAddress = cryptoWalletAddress;
        }
    }
    /// <summary>
    /// Response type for <see cref="Stytch.net.Clients.Consumer.CryptoWallets.AuthenticateStart"/>..
    /// </summary>
    public class CryptoWalletsAuthenticateStartResponse
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
        /// A challenge string to be signed by the wallet in order to prove ownership.
        /// </summary>
        [JsonProperty("challenge")]
        public string Challenge { get; set; }
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
    public class CryptoWalletsSIWEParamsResponse
    {
        /// <summary>
        /// The domain that requested the crypto wallet signature.
        /// </summary>
        [JsonProperty("domain")]
        public string Domain { get; set; }
        /// <summary>
        /// An RFC 3986 URI referring to the resource that is the subject of the signing.
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; set; }
        /// <summary>
        /// The EIP-155 Chain ID to which the session is bound.
        /// </summary>
        [JsonProperty("chain_id")]
        public string ChainId { get; set; }
        /// <summary>
        ///  A list of information or references to information the user wishes to have resolved as part of
        /// authentication. Every resource must be an RFC 3986 URI.
        /// </summary>
        [JsonProperty("resources")]
        public List<string> Resources { get; set; }
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
        /// <summary>
        /// The time when the message was generated. All timestamps in our API conform to the RFC 3339 standard and
        /// are expressed in UTC, e.g. `2021-12-29T12:33:09Z`.
        /// </summary>
        [JsonProperty("issued_at")]
        public DateTime? IssuedAt { get; set; }
        /// <summary>
        /// A system-specific identifier that may be used to uniquely refer to the sign-in request.
        /// </summary>
        [JsonProperty("message_request_id")]
        public string MessageRequestId { get; set; }
    }

}
