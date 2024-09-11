// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!

using Newtonsoft.Json;
using Stytch.net.Models.Consumer;
using System.Text;




namespace Stytch.net.Clients.b2c
{
  public class PasswordsSessions
  {
    private readonly HttpClient _httpClient;
    public PasswordsSessions(HttpClient client)
    {
      _httpClient = client;
    }







    /// <summary>
    /// Reset the user’s password using their existing session. The endpoint will error if the session does not
    /// have a password, email magic link, or email OTP authentication factor that has been issued within the
    /// last 5 minutes. This endpoint requires either a `session_jwt` or `session_token` be included in the
    /// request.
    /// 
    /// Note that a successful password reset via an existing session will revoke all active sessions for the
    /// `user_id`, except for the one used during the reset flow.
    /// </summary>
    public async Task<PasswordsSessionResetResponse> Reset(
        PasswordsSessionResetRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/passwords/session/reset", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<PasswordsSessionResetResponse>(responseBody);
        }
        else
        {
            // If the response is not successful, log the error details
            Console.WriteLine($"Error: {response.StatusCode}, Response Body: {responseBody}");

            // Optionally, throw an exception or return null or an error object
            throw new HttpRequestException(
                $"Request failed with status code {response.StatusCode}: {responseBody}");
        }
    }

  }

}

