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
  public class CryptoWallets
  {
    private readonly HttpClient _httpClient;
    public CryptoWallets(HttpClient client)
    {
      _httpClient = client;
    }







    /// <summary>
    /// Initiate the authentication of a crypto wallet. After calling this endpoint, the user will need to sign
    /// a message containing the returned `challenge` field.
    /// 
    /// For Ethereum crypto wallets, you can optionally use the Sign In With Ethereum (SIWE) protocol for the
    /// message by passing in the `siwe_params`. The only required fields are `domain` and `uri`.
    /// If the crypto wallet detects that the domain in the message does not match the website's domain, it will
    /// display a warning to the user.
    /// 
    /// If not using the SIWE protocol, the message will simply consist of the project name and a random string.
    /// </summary>
    public async Task<CryptoWalletsAuthenticateStartResponse> AuthenticateStart(
        CryptoWalletsAuthenticateStartRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/crypto_wallets/authenticate/start", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<CryptoWalletsAuthenticateStartResponse>(responseBody);
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
    /// Complete the authentication of a crypto wallet by passing the signature.
    /// </summary>
    public async Task<CryptoWalletsAuthenticateResponse> Authenticate(
        CryptoWalletsAuthenticateRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/crypto_wallets/authenticate", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<CryptoWalletsAuthenticateResponse>(responseBody);
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

