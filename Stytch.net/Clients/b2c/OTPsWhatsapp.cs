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
  public class OTPsWhatsapp
  {
    private readonly HttpClient _httpClient;
    public OTPsWhatsapp(HttpClient client)
    {
      _httpClient = client;
    }







    /**
    * Send a One-Time Passcode (OTP) to a User's WhatsApp. If you'd like to create a user and send them a
    * passcode with one request, use our
    * [log in or create](https://stytch.com/docs/api/whatsapp-login-or-create) endpoint.
    * 
    * Note that sending another OTP code before the first has expired will invalidate the first code.
    * 
    * ### Cost to send SMS OTP
    * Before configuring SMS or WhatsApp OTPs, please review how Stytch
    * [bills the costs of international OTPs](https://stytch.com/pricing) and understand how to protect your
    * app against [toll fraud](https://stytch.com/docs/guides/passcodes/toll-fraud/overview).
    * 
    * ### Add a phone number to an existing user
    * 
    * This endpoint also allows you to add a new phone number to an existing Stytch User. Including a
    * `user_id`, `session_token`, or `session_jwt` in your Send one-time passcode by WhatsApp request will add
    * the new, unverified phone number to the existing Stytch User. If the user successfully authenticates
    * within 5 minutes, the new phone number will be marked as verified and remain permanently on the existing
    * Stytch User. Otherwise, it will be removed from the User object, and any subsequent login requests using
    * that phone number will create a new User.
    * 
    * ### Next steps
    * 
    * Collect the OTP which was delivered to the user. Call
    * [Authenticate OTP](https://stytch.com/docs/api/authenticate-otp) using the OTP `code` along with the
    * `phone_id` found in the response as the `method_id`.
    * @param data {@link OTPsWhatsappSendRequest}
    * @returns {@link OTPsWhatsappSendResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<OTPsWhatsappSendResponse> send(
        OTPsWhatsappSendRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/otps/whatsapp/send", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<OTPsWhatsappSendResponse>(responseBody);
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
    * Send a one-time passcode (OTP) to a User's WhatsApp using their phone number. If the phone number is not
    * associated with a User already, a User will be created.
    * 
    * ### Cost to send SMS OTP
    * Before configuring SMS or WhatsApp OTPs, please review how Stytch
    * [bills the costs of international OTPs](https://stytch.com/pricing) and understand how to protect your
    * app against [toll fraud](https://stytch.com/docs/guides/passcodes/toll-fraud/overview).
    * 
    * ### Next steps
    * 
    * Collect the OTP which was delivered to the User. Call
    * [Authenticate OTP](https://stytch.com/docs/api/authenticate-otp) using the OTP `code` along with the
    * `phone_id` found in the response as the `method_id`.
    * @param data {@link OTPsWhatsappLoginOrCreateRequest}
    * @returns {@link OTPsWhatsappLoginOrCreateResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<OTPsWhatsappLoginOrCreateResponse> loginOrCreate(
        OTPsWhatsappLoginOrCreateRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/otps/whatsapp/login_or_create", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<OTPsWhatsappLoginOrCreateResponse>(responseBody);
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

