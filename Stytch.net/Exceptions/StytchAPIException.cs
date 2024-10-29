using System;
using Newtonsoft.Json;

namespace Stytch.net.Exceptions
{
    public class StytchApiException : Exception
    {
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
        [JsonProperty("request_id")]
        public string RequestID { get; set; }
        [JsonProperty("error_type")]
        public string ErrorType { get; set; }
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
        [JsonProperty("error_url")]
        public string ErrorUrl { get; set; }

        public override string ToString()
        {
            return $"StytchApiException<{RequestID}, {ErrorType}, {StatusCode}>: {ErrorMessage}\n{ErrorUrl}";
        }
    }
}
