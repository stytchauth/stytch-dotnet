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
  public class PasswordsEmail
  {
    private readonly HttpClient _httpClient;
    public PasswordsEmail(HttpClient client)
    {
      _httpClient = client;
    }







    /**
    * Initiates a password reset for the email address provided. This will trigger an email to be sent to the
    * address, containing a magic link that will allow them to set a new password and authenticate.
    * @param data {@link PasswordsEmailResetStartRequest}
    * @returns {@link PasswordsEmailResetStartResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<PasswordsEmailResetStartResponse> resetStart(
        PasswordsEmailResetStartRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/passwords/email/reset/start", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<PasswordsEmailResetStartResponse>(responseBody);
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
    /**
    * Reset the user’s password and authenticate them. This endpoint checks that the magic link `token` is
    * valid, hasn’t expired, or already been used – and can optionally require additional security settings,
    * such as the IP address and user agent matching the initial reset request.
    * 
    * The provided password needs to meet our password strength requirements, which can be checked in advance
    * with the password strength endpoint. If the token and password are accepted, the password is securely
    * stored for future authentication and the user is authenticated.
    * 
    * Note that a successful password reset by email will revoke all active sessions for the `user_id`.
    * @param data {@link PasswordsEmailResetRequest}
    * @returns {@link PasswordsEmailResetResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<PasswordsEmailResetResponse> reset(
        PasswordsEmailResetRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/passwords/email/reset", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<PasswordsEmailResetResponse>(responseBody);
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
