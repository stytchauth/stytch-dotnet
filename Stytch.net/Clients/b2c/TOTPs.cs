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
  public class TOTPs
  {
    private readonly HttpClient _httpClient;
    public TOTPs(HttpClient client)
    {
      _httpClient = client;
    }







    /**
    * Create a new TOTP instance for a user. The user can use the authenticator application of their choice to
    * scan the QR code or enter the secret.
    * @param data {@link TOTPsCreateRequest}
    * @returns {@link TOTPsCreateResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<TOTPsCreateResponse> Create(
        TOTPsCreateRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/totps", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<TOTPsCreateResponse>(responseBody);
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
    * Authenticate a TOTP code entered by a user.
    * @param data {@link TOTPsAuthenticateRequest}
    * @returns {@link TOTPsAuthenticateResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<TOTPsAuthenticateResponse> Authenticate(
        TOTPsAuthenticateRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/totps/authenticate", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<TOTPsAuthenticateResponse>(responseBody);
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
    * Retrieve the recovery codes for a TOTP instance tied to a User.
    * @param data {@link TOTPsRecoveryCodesRequest}
    * @returns {@link TOTPsRecoveryCodesResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<TOTPsRecoveryCodesResponse> RecoveryCodes(
        TOTPsRecoveryCodesRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/totps/recovery_codes", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<TOTPsRecoveryCodesResponse>(responseBody);
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
    * Authenticate a recovery code for a TOTP instance.
    * @param data {@link TOTPsRecoverRequest}
    * @returns {@link TOTPsRecoverResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<TOTPsRecoverResponse> Recover(
        TOTPsRecoverRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/totps/recover", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<TOTPsRecoverResponse>(responseBody);
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

