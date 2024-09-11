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
  public class MagicLinksEmail
  {
    private readonly HttpClient _httpClient;
    public MagicLinksEmail(HttpClient client)
    {
      _httpClient = client;
    }







    /**
    * Send a magic link to an existing Stytch user using their email address. If you'd like to create a user
    * and send them a magic link by email with one request, use our
    * [log in or create endpoint](https://stytch.com/docs/api/log-in-or-create-user-by-email).
    * 
    * ### Add an email to an existing user
    * This endpoint also allows you to add a new email address to an existing Stytch User. Including a
    * `user_id`, `session_token`, or `session_jwt` in your Send Magic Link by email request will add the new,
    * unverified email address to the existing Stytch User. If the user successfully authenticates within 5
    * minutes, the new email address will be marked as verified and remain permanently on the existing Stytch
    * User. Otherwise, it will be removed from the User object, and any subsequent login requests using that
    * email address will create a new User.
    * 
    * ### Next steps
    * The user is emailed a magic link which redirects them to the provided
    * [redirect URL](https://stytch.com/docs/guides/magic-links/email-magic-links/redirect-routing). Collect
    * the `token` from the URL query parameters, and call
    * [Authenticate magic link](https://stytch.com/docs/api/authenticate-magic-link) to complete
    * authentication.
    * @param data {@link MagicLinksEmailSendRequest}
    * @returns {@link MagicLinksEmailSendResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<MagicLinksEmailSendResponse> Send(
        MagicLinksEmailSendRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/magic_links/email/send", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<MagicLinksEmailSendResponse>(responseBody);
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
    * Send either a login or signup Magic Link to the User based on if the email is associated with a User
    * already. A new or pending User will receive a signup Magic Link. An active User will receive a login
    * Magic Link. For more information on how to control the status your Users are created in see the
    * `create_user_as_pending` flag.
    * 
    * ### Next steps
    * The User is emailed a Magic Link which redirects them to the provided
    * [redirect URL](https://stytch.com/docs/guides/magic-links/email-magic-links/redirect-routing). Collect
    * the `token` from the URL query parameters and call
    * [Authenticate Magic Link](https://stytch.com/docs/api/authenticate-magic-link) to complete
    * authentication.
    * @param data {@link MagicLinksEmailLoginOrCreateRequest}
    * @returns {@link MagicLinksEmailLoginOrCreateResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<MagicLinksEmailLoginOrCreateResponse> LoginOrCreate(
        MagicLinksEmailLoginOrCreateRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/magic_links/email/login_or_create", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<MagicLinksEmailLoginOrCreateResponse>(responseBody);
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
    * Create a User and send an invite Magic Link to the provided `email`. The User will be created with a
    * `pending` status until they click the Magic Link in the invite email.
    * 
    * ### Next steps
    * The User is emailed a Magic Link which redirects them to the provided
    * [redirect URL](https://stytch.com/docs/guides/magic-links/email-magic-links/redirect-routing). Collect
    * the `token` from the URL query parameters and call
    * [Authenticate Magic Link](https://stytch.com/docs/api/authenticate-magic-link) to complete
    * authentication.
    * @param data {@link MagicLinksEmailInviteRequest}
    * @returns {@link MagicLinksEmailInviteResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<MagicLinksEmailInviteResponse> Invite(
        MagicLinksEmailInviteRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/magic_links/email/invite", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<MagicLinksEmailInviteResponse>(responseBody);
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
    * Revoke a pending invite based on the `email` provided.
    * @param data {@link MagicLinksEmailRevokeInviteRequest}
    * @returns {@link MagicLinksEmailRevokeInviteResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<MagicLinksEmailRevokeInviteResponse> RevokeInvite(
        MagicLinksEmailRevokeInviteRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/magic_links/email/revoke_invite", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<MagicLinksEmailRevokeInviteResponse>(responseBody);
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

