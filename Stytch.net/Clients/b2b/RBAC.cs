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
  public class RBAC
  {
    private readonly HttpClient _httpClient;
    public RBAC(HttpClient client)
    {
      _httpClient = client;
    }







    /**
    * Get the active RBAC Policy for your current Stytch Project. An RBAC Policy is the canonical document
    * that stores all defined Resources and Roles within your RBAC permissioning model. 
    * 
    * When using the backend SDKs, the RBAC Policy will be cached to allow for local evaluations, eliminating
    * the need for an extra request to Stytch. The policy will be refreshed if an authorization check is
    * requested and the RBAC policy was last updated more than 5 minutes ago.
    * 
    * Resources and Roles can be created and managed within the [Dashboard](/dashboard/rbac). Additionally,
    * [Role assignment](https://stytch.com/docs/b2b/guides/rbac/role-assignment) can be programmatically
    * managed through certain Stytch API endpoints.
    * 
    * Check out the [RBAC overview](https://stytch.com/docs/b2b/guides/rbac/overview) to learn more about
    * Stytch's RBAC permissioning model.
    * @param params {@link B2BRBACPolicyRequest}
    * @returns {@link B2BRBACPolicyResponse}
    * @async
    * @throws A {@link StytchError} on a non-2xx response from the Stytch API
    * @throws A {@link RequestError} when the Stytch API cannot be reached
    */
    public async Task<B2BRBACPolicyResponse> policy(
        B2BRBACPolicyRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/b2b/rbac/policy", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<B2BRBACPolicyResponse>(responseBody);
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

