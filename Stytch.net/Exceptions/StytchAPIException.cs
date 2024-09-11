using Newtonsoft.Json;

namespace Stytch.net.Exceptions;

public class StytchApiException : Exception
{
    [JsonProperty("status_code")]
    public required int StatusCode { get; set; }
    [JsonProperty("error_type")]
    public required string ErrorType { get; set; }
    [JsonProperty("error_message")]
    public required string ErrorMessage { get; set; }
    [JsonProperty("error_url")]
    public required string ErrorUrl { get; set; }

    public override string ToString()
    {
        return $"StytchApiException<{ErrorType}, {StatusCode}>: {ErrorMessage}\n{ErrorUrl}";
    }
}