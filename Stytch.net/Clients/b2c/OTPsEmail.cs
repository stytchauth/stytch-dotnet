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
  public class OTPsEmail
  {
    private readonly HttpClient _httpClient;
    public OTPsEmail(HttpClient client)
    {
      _httpClient = client;
    }







    /**
    * Send a One-Time Passcode (OTP) to a User using their email. If you'd like to create a user and send them
    * a passcode with one request, use our
    * [log in or create endpoint](https://stytch.com/docs/api/log-in-or-create-user-by-email-otp).
    * 
    * ### Add an email to an existing user
    * This endpoint also allows you to add a new email address to an existing Stytch User. Including a
    * `user_id`, `session_token`, or `session_jwt` in your Send one-time passcode by email request will add
    * the new, unverified email address to the existing Stytch User. If the user successfully authenticates
    * within 5 minutes, the new email address will be marked as verified and remain permanently on the
    * existing Stytch User. Otherwise, it will be removed from the User object, and any subsequent login
    * requests using that email address will create a new User.
    * 
    * ### Next steps
    * Collect the OTP which was delivered to the user. Call
    * [Authenticate OTP](https://stytch.com/docs/api/authenticate-otp) using the OTP `code` along with the
    * `email_id` found in the response as the `method_id`.
    * @param data {@link OTPsEmailSendRequest}
    * @returns {@link OTPsEmailSendResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<OTPsEmailSendResponse> send(
        OTPsEmailSendRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/otps/email/send", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<OTPsEmailSendResponse>(responseBody);
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
    * Send a one-time passcode (OTP) to a User using their email. If the email is not associated with a User
    * already, a User will be created.
    * 
    * ### Next steps
    * 
    * Collect the OTP which was delivered to the User. Call
    * [Authenticate OTP](https://stytch.com/docs/api/authenticate-otp) using the OTP `code` along with the
    * `phone_id` found in the response as the `method_id`.
    * @param data {@link OTPsEmailLoginOrCreateRequest}
    * @returns {@link OTPsEmailLoginOrCreateResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<OTPsEmailLoginOrCreateResponse> loginOrCreate(
        OTPsEmailLoginOrCreateRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/otps/email/login_or_create", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<OTPsEmailLoginOrCreateResponse>(responseBody);
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
