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
  public class RecoveryCodes
  {
    private readonly HttpClient _httpClient;
    public RecoveryCodes(HttpClient client)
    {
      _httpClient = client;
    }







    /**
    * Allows a Member to complete an MFA flow by consuming a recovery code. This consumes the recovery code
    * and returns a session token that can be used to authenticate the Member.
    * @param data {@link B2BRecoveryCodesRecoverRequest}
    * @returns {@link B2BRecoveryCodesRecoverResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<B2BRecoveryCodesRecoverResponse> recover(
        B2BRecoveryCodesRecoverRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/b2b/recovery_codes/recover", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<B2BRecoveryCodesRecoverResponse>(responseBody);
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
    * Returns a Member's full set of active recovery codes.
    * @param params {@link B2BRecoveryCodesGetRequest}
    * @returns {@link B2BRecoveryCodesGetResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<B2BRecoveryCodesGetResponse> get(
        B2BRecoveryCodesGetRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/b2b/recovery_codes/${params.organization_id}/${params.member_id}", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<B2BRecoveryCodesGetResponse>(responseBody);
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
    * Rotate a Member's recovery codes. This invalidates all existing recovery codes and generates a new set
    * of recovery codes.
    * @param data {@link B2BRecoveryCodesRotateRequest}
    * @returns {@link B2BRecoveryCodesRotateResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<B2BRecoveryCodesRotateResponse> rotate(
        B2BRecoveryCodesRotateRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/b2b/recovery_codes/rotate", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<B2BRecoveryCodesRotateResponse>(responseBody);
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

