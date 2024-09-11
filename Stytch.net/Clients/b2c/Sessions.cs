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
  public class Sessions
  {
    private readonly HttpClient _httpClient;
    public Sessions(HttpClient client)
    {
      _httpClient = client;
    }







    /// <summary>
    /// List all active Sessions for a given `user_id`. All timestamps are formatted according to the RFC 3339
    /// standard and are expressed in UTC, e.g. `2021-12-29T12:33:09Z`.
    /// </summary>
    public async Task<SessionsGetResponse> Get(
        SessionsGetRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/sessions", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<SessionsGetResponse>(responseBody);
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
    /// <summary>
    /// Authenticate a session token or session JWT and retrieve associated session data. If
    /// `session_duration_minutes` is included, update the lifetime of the session to be that many minutes from
    /// now. All timestamps are formatted according to the RFC 3339 standard and are expressed in UTC, e.g.
    /// `2021-12-29T12:33:09Z`. This endpoint requires exactly one `session_jwt` or `session_token` as part of
    /// the request. If both are included, you will receive a `too_many_session_arguments` error.
    /// 
    /// You may provide a JWT that needs to be refreshed and is expired according to its `exp` claim. A new JWT
    /// will be returned if both the signature and the underlying Session are still valid. See our
    /// [How to use Stytch Session JWTs](https://stytch.com/docs/guides/sessions/using-jwts) guide for more
    /// information.
    /// </summary>
    public async Task<SessionsAuthenticateResponse> Authenticate(
        SessionsAuthenticateRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/sessions/authenticate", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<SessionsAuthenticateResponse>(responseBody);
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
    /// <summary>
    /// Revoke a Session, immediately invalidating all of its session tokens. You can revoke a session in three
    /// ways: using its ID, or using one of its session tokens, or one of its JWTs. This endpoint requires
    /// exactly one of those to be included in the request. It will return an error if multiple are present.
    /// </summary>
    public async Task<SessionsRevokeResponse> Revoke(
        SessionsRevokeRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/sessions/revoke", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<SessionsRevokeResponse>(responseBody);
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
    /// <summary>
    /// Migrate a session from an external OIDC compliant endpoint. Stytch will call the external UserInfo
    /// endpoint defined in your Stytch Project settings in the [Dashboard](/dashboard), and then perform a
    /// lookup using the `session_token`. If the response contains a valid email address, Stytch will attempt to
    /// match that email address with an existing User and create a Stytch Session. You will need to create the
    /// user before using this endpoint.
    /// </summary>
    public async Task<SessionsMigrateResponse> Migrate(
        SessionsMigrateRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/sessions/migrate", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<SessionsMigrateResponse>(responseBody);
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
    /// <summary>
    /// Get the JSON Web Key Set (JWKS) for a project.
    /// 
    /// JWKS are rotated every ~6 months. Upon rotation, new JWTs will be signed using the new key set, and both
    /// key sets will be returned by this endpoint for a period of 1 month. 
    /// 
    /// JWTs have a set lifetime of 5 minutes, so there will be a 5 minute period where some JWTs will be signed
    /// by the old JWKS, and some JWTs will be signed by the new JWKS. The correct JWKS to use for validation is
    /// determined by matching the `kid` value of the JWT and JWKS. 
    /// 
    /// If you're using one of our [backend SDKs](https://stytch.com/docs/sdks), the JWKS roll will be handled
    /// for you.
    /// 
    /// If you're using your own JWT validation library, many have built-in support for JWKS rotation, and
    /// you'll just need to supply this API endpoint. If not, your application should decide which JWKS to use
    /// for validation by inspecting the `kid` value.
    /// 
    /// See our [How to use Stytch Session JWTs](https://stytch.com/docs/guides/sessions/using-jwts) guide for
    /// more information.
    /// </summary>
    public async Task<SessionsGetJWKSResponse> GetJWKS(
        SessionsGetJWKSRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/sessions/jwks/${params.project_id}", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<SessionsGetJWKSResponse>(responseBody);
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

