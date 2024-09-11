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
  public class OAuth
  {
    private readonly HttpClient _httpClient;
    public OAuth(HttpClient client)
    {
      _httpClient = client;
    }







    /**
    * Generate an OAuth Attach Token to pre-associate an OAuth flow with an existing Stytch User. Pass the
    * returned `oauth_attach_token` to the same provider's OAuth Start endpoint to treat this OAuth flow as a
    * login for that user instead of a signup for a new user.
    * 
    * Exactly one of `user_id`, `session_token`, or `session_jwt` must be provided to identify the target
    * Stytch User.
    * 
    * This is an optional step in the OAuth flow. Stytch can often determine whether to create a new user or
    * log in an existing one based on verified identity provider information. This endpoint is useful for
    * cases where we can't, such as missing or unverified provider information.
    * @param data {@link OAuthAttachRequest}
    * @returns {@link OAuthAttachResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<OAuthAttachResponse> attach(
        OAuthAttachRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/oauth/attach", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<OAuthAttachResponse>(responseBody);
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
    * Authenticate a User given a `token`. This endpoint verifies that the user completed the OAuth flow by
    * verifying that the token is valid and hasn't expired. To initiate a Stytch session for the user while
    * authenticating their OAuth token, include `session_duration_minutes`; a session with the identity
    * provider, e.g. Google or Facebook, will always be initiated upon successful authentication.
    * @param data {@link OAuthAuthenticateRequest}
    * @returns {@link OAuthAuthenticateResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<OAuthAuthenticateResponse> authenticate(
        OAuthAuthenticateRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/oauth/authenticate", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<OAuthAuthenticateResponse>(responseBody);
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

