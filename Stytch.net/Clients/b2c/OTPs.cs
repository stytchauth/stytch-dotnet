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
  public class OTPs
  {
    private readonly HttpClient _httpClient;
    public readonly OTPsSms Sms;
    public readonly OTPsWhatsapp Whatsapp;
    public readonly OTPsEmail Email;
    public OTPs(HttpClient client)
    {
      _httpClient = client;
        Sms = new OTPsSms(_httpClient);
        Whatsapp = new OTPsWhatsapp(_httpClient);
        Email = new OTPsEmail(_httpClient);
    }







    /**
    * Authenticate a User given a `method_id` (the associated `email_id` or `phone_id`) and a `code`. This
    * endpoint verifies that the code is valid, hasn't expired or been previously used, and any optional
    * security settings such as IP match or user agent match are satisfied. A given `method_id` may only have
    * a single active OTP code at any given time, if a User requests another OTP code before the first one has
    * expired, the first one will be invalidated.
    * @param data {@link OTPsAuthenticateRequest}
    * @returns {@link OTPsAuthenticateResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<OTPsAuthenticateResponse> authenticate(
        OTPsAuthenticateRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/otps/authenticate", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<OTPsAuthenticateResponse>(responseBody);
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
