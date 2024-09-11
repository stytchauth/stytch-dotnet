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
  public class Sessions
  {
    private readonly HttpClient _httpClient;
    public Sessions(HttpClient client)
    {
      _httpClient = client;
    }







    /**
    * Retrieves all active Sessions for a Member.
    * @param params {@link B2BSessionsGetRequest}
    * @returns {@link B2BSessionsGetResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<B2BSessionsGetResponse> Get(
        B2BSessionsGetRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/b2b/sessions", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<B2BSessionsGetResponse>(responseBody);
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
    * Authenticates a Session and updates its lifetime by the specified `session_duration_minutes`. If the
    * `session_duration_minutes` is not specified, a Session will not be extended. This endpoint requires
    * either a `session_jwt` or `session_token` be included in the request. It will return an error if both
    * are present.
    * 
    * You may provide a JWT that needs to be refreshed and is expired according to its `exp` claim. A new JWT
    * will be returned if both the signature and the underlying Session are still valid. See our
    * [How to use Stytch Session JWTs](https://stytch.com/docs/b2b/guides/sessions/resources/using-jwts) guide
    * for more information.
    * 
    * If an `authorization_check` object is passed in, this method will also check if the Member is authorized
    * to perform the given action on the given Resource in the specified Organization. A Member is authorized
    * if their Member Session contains a Role, assigned
    * [explicitly or implicitly](https://stytch.com/docs/b2b/guides/rbac/role-assignment), with adequate
    * permissions.
    * In addition, the `organization_id` passed in the authorization check must match the Member's
    * Organization.
    * 
    * If the Member is not authorized to perform the specified action on the specified Resource, or if the
    * `organization_id` does not match the Member's Organization, a 403 error will be thrown.
    * Otherwise, the response will contain a list of Roles that satisfied the authorization check.
    * @param data {@link B2BSessionsAuthenticateRequest}
    * @returns {@link B2BSessionsAuthenticateResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<B2BSessionsAuthenticateResponse> Authenticate(
        B2BSessionsAuthenticateRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/b2b/sessions/authenticate", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<B2BSessionsAuthenticateResponse>(responseBody);
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
    * Revoke a Session and immediately invalidate all its tokens. To revoke a specific Session, pass either
    * the `member_session_id`, `session_token`, or `session_jwt`. To revoke all Sessions for a Member, pass
    * the `member_id`.
    * @param data {@link B2BSessionsRevokeRequest}
    * @param options {@link B2BSessionsRevokeRequestOptions}
    * @returns {@link B2BSessionsRevokeResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<B2BSessionsRevokeResponse> Revoke(
        B2BSessionsRevokeRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/b2b/sessions/revoke", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<B2BSessionsRevokeResponse>(responseBody);
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
    * Use this endpoint to exchange a Member's existing session for another session in a different
    * Organization. This can be used to accept an invite, but not to create a new member via domain matching.
    * 
    * To create a new member via domain matching, use the
    * [Exchange Intermediate Session](https://stytch.com/docs/b2b/api/exchange-intermediate-session) flow
    * instead.
    * 
    * Only Email Magic Link, OAuth, and SMS OTP factors can be transferred between sessions. Other
    * authentication factors, such as password factors, will not be transferred to the new session.
    * Any OAuth Tokens owned by the Member will not be transferred to the new Organization.
    * SMS OTP factors can be used to fulfill MFA requirements for the target Organization if both the original
    * and target Member have the same phone number and the phone number is verified for both Members.
    * 
    * If the Member is required to complete MFA to log in to the Organization, the returned value of
    * `member_authenticated` will be `false`, and an `intermediate_session_token` will be returned.
    * The `intermediate_session_token` can be passed into the
    * [OTP SMS Authenticate endpoint](https://stytch.com/docs/b2b/api/authenticate-otp-sms) to complete the
    * MFA step and acquire a full member session.
    * The `intermediate_session_token` can also be used with the
    * [Exchange Intermediate Session endpoint](https://stytch.com/docs/b2b/api/exchange-intermediate-session)
    * or the
    * [Create Organization via Discovery endpoint](https://stytch.com/docs/b2b/api/create-organization-via-discovery) to join a different Organization or create a new one.
    * The `session_duration_minutes` and `session_custom_claims` parameters will be ignored.
    * @param data {@link B2BSessionsExchangeRequest}
    * @returns {@link B2BSessionsExchangeResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<B2BSessionsExchangeResponse> Exchange(
        B2BSessionsExchangeRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/b2b/sessions/exchange", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<B2BSessionsExchangeResponse>(responseBody);
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
    * Migrate a session from an external OIDC compliant endpoint. Stytch will call the external UserInfo
    * endpoint defined in your Stytch Project settings in the [Dashboard](/dashboard), and then perform a
    * lookup using the `session_token`. If the response contains a valid email address, Stytch will attempt to
    * match that email address with an existing Member in your Organization and create a Stytch Session. You
    * will need to create the member before using this endpoint.
    * @param data {@link B2BSessionsMigrateRequest}
    * @returns {@link B2BSessionsMigrateResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<B2BSessionsMigrateResponse> Migrate(
        B2BSessionsMigrateRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/b2b/sessions/migrate", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<B2BSessionsMigrateResponse>(responseBody);
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
    * Get the JSON Web Key Set (JWKS) for a project.
    * 
    * JWKS are rotated every ~6 months. Upon rotation, new JWTs will be signed using the new key set, and both
    * key sets will be returned by this endpoint for a period of 1 month. 
    * 
    * JWTs have a set lifetime of 5 minutes, so there will be a 5 minute period where some JWTs will be signed
    * by the old JWKS, and some JWTs will be signed by the new JWKS. The correct JWKS to use for validation is
    * determined by matching the `kid` value of the JWT and JWKS.  
    * 
    * If you're using one of our [backend SDKs](https://stytch.com/docs/b2b/sdks), the JWKS roll will be
    * handled for you.
    * 
    * If you're using your own JWT validation library, many have built-in support for JWKS rotation, and
    * you'll just need to supply this API endpoint. If not, your application should decide which JWKS to use
    * for validation by inspecting the `kid` value.
    * 
    * See our
    * [How to use Stytch Session JWTs](https://stytch.com/docs/b2b/guides/sessions/resources/using-jwts) guide
    * for more information.
    * @param params {@link B2BSessionsGetJWKSRequest}
    * @returns {@link B2BSessionsGetJWKSResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<B2BSessionsGetJWKSResponse> GetJWKS(
        B2BSessionsGetJWKSRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/b2b/sessions/jwks/${params.project_id}", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<B2BSessionsGetJWKSResponse>(responseBody);
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

