// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!

using Newtonsoft.Json;
using Stytch.net.Models.Consumer;
using System.Text;




namespace Stytch.net.Clients.b2b
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
    * 
    * This endpoint adapts to your Project's password strength configuration.
    * If you're using [zxcvbn](https://stytch.com/docs/guides/passwords/strength-policy), the default, your
    * passwords are considered valid
    * if the strength score is >= 3. If you're using
    * [LUDS](https://stytch.com/docs/guides/passwords/strength-policy), your passwords are
    * considered valid if they meet the requirements that you've set with Stytch.
    * You may update your password strength configuration in the
    * [stytch dashboard](https://stytch.com/dashboard/password-strength-config).
    * @param data {@link B2BPasswordsEmailResetStartRequest}
    * @returns {@link B2BPasswordsEmailResetStartResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<B2BPasswordsEmailResetStartResponse> resetStart(
        B2BPasswordsEmailResetStartRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/b2b/passwords/email/reset/start", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<B2BPasswordsEmailResetStartResponse>(responseBody);
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
    * Reset the member's password and authenticate them. This endpoint checks that the password reset token is
    * valid, hasn’t expired, or already been used.
    * 
    * The provided password needs to meet our password strength requirements, which can be checked in advance
    * with the password strength endpoint. If the token and password are accepted, the password is securely
    * stored for future authentication and the user is authenticated.
    * 
    * If the Member is required to complete MFA to log in to the Organization, the returned value of
    * `member_authenticated` will be `false`, and an `intermediate_session_token` will be returned.
    * The `intermediate_session_token` can be passed into the
    * [OTP SMS Authenticate endpoint](https://stytch.com/docs/b2b/api/authenticate-otp-sms) to complete the
    * MFA step and acquire a full member session.
    * The `session_duration_minutes` and `session_custom_claims` parameters will be ignored.
    * 
    * If a valid `session_token` or `session_jwt` is passed in, the Member will not be required to complete an
    * MFA step.
    * 
    * Note that a successful password reset by email will revoke all active sessions for the `member_id`.
    * @param data {@link B2BPasswordsEmailResetRequest}
    * @returns {@link B2BPasswordsEmailResetResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<B2BPasswordsEmailResetResponse> reset(
        B2BPasswordsEmailResetRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/b2b/passwords/email/reset", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<B2BPasswordsEmailResetResponse>(responseBody);
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

