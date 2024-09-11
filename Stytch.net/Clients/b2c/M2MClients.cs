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
  public class M2MClients
  {
    private readonly HttpClient _httpClient;
    public readonly M2MClientsSecrets Secrets;
    public M2MClients(HttpClient client)
    {
      _httpClient = client;
        Secrets = new M2MClientsSecrets(_httpClient);
    }







    /// <summary>
    /// Gets information about an existing M2M Client.
    /// </summary>
    public async Task<M2MClientsGetResponse> Get(
        M2MClientsGetRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/m2m/clients/${params.client_id}", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<M2MClientsGetResponse>(responseBody);
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
    /// Search for M2M Clients within your Stytch Project. Submit an empty `query` in the request to return all
    /// M2M Clients.
    /// 
    /// The following search filters are supported today:
    /// - `client_id`: Pass in a list of client IDs to get many clients in a single request
    /// - `client_name`: Search for clients by exact match on client name
    /// - `scopes`: Search for clients assigned a specific scope
    /// </summary>
    public async Task<M2MClientsSearchResponse> Search(
        M2MClientsSearchRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/m2m/clients/search", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<M2MClientsSearchResponse>(responseBody);
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
    /// Updates an existing M2M Client. You can use this endpoint to activate or deactivate a M2M Client by
    /// changing its `status`. A deactivated M2M Client will not be allowed to perform future token exchange
    /// flows until it is reactivated.
    /// 
    /// **Important:** Deactivating a M2M Client will not invalidate any existing JWTs issued to the client,
    /// only prevent it from receiving new ones.
    /// To protect more-sensitive routes, pass a lower `max_token_age` value
    /// when[authenticating the token](https://stytch.com/docs/b2b/api/authenticate-m2m-token)[authenticating the token](https://stytch.com/docs/api/authenticate-m2m-token).
    /// </summary>
    public async Task<M2MClientsUpdateResponse> Update(
        M2MClientsUpdateRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/m2m/clients/${data.client_id}", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<M2MClientsUpdateResponse>(responseBody);
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
    /// Deletes the M2M Client.
    /// 
    /// **Important:** Deleting a M2M Client will not invalidate any existing JWTs issued to the client, only
    /// prevent it from receiving new ones.
    /// To protect more-sensitive routes, pass a lower `max_token_age` value
    /// when[authenticating the token](https://stytch.com/docs/b2b/api/authenticate-m2m-token)[authenticating the token](https://stytch.com/docs/api/authenticate-m2m-token).
    /// </summary>
    public async Task<M2MClientsDeleteResponse> Delete(
        M2MClientsDeleteRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/m2m/clients/${data.client_id}", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<M2MClientsDeleteResponse>(responseBody);
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
    /// Creates a new M2M Client. On initial client creation, you may pass in a custom `client_id` or
    /// `client_secret` to import an existing M2M client. If you do not pass in a custom `client_id` or
    /// `client_secret`, one will be generated automatically. The `client_id` must be unique among all clients
    /// in your project.
    /// 
    /// **Important:** This is the only time you will be able to view the generated `client_secret` in the API
    /// response. Stytch stores a hash of the `client_secret` and cannot recover the value if lost. Be sure to
    /// persist the `client_secret` in a secure location. If the `client_secret` is lost, you will need to
    /// trigger a secret rotation flow to receive another one.
    /// </summary>
    public async Task<M2MClientsCreateResponse> Create(
        M2MClientsCreateRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/m2m/clients", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<M2MClientsCreateResponse>(responseBody);
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

