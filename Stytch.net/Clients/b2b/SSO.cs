// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!

using Newtonsoft.Json;
using Stytch.net.Models.Consumer;
using System.Text;




namespace Stytch.net.Clients.B2B
{
    public class SSO
    {
        private readonly HttpClient _httpClient;
        public readonly SSOOIDC OIDC;
        public readonly SSOSAML SAML;
        public SSO(HttpClient client)
        {
            _httpClient = client;
            OIDC = new SSOOIDC(_httpClient);
            SAML = new SSOSAML(_httpClient);
        }







        /// <summary>
        /// Get all SSO Connections owned by the organization.
        /// </summary>
        public async Task<B2BSSOGetConnectionsResponse> GetConnections(
            B2BSSOGetConnectionsRequest request)
        {
            // Serialize the request model to JSON
            var jsonBody = JsonConvert.SerializeObject(request);

            // Create the content with the right content type
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            // Send the POST request to the specified URL
            var response = await _httpClient.PostAsync("/v1/b2b/sso/${params.organization_id}", content);

            // Read the response body (even if the response is not successful)
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                // If the response is successful, deserialize and return the response
                return JsonConvert.DeserializeObject<B2BSSOGetConnectionsResponse>(responseBody);
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
        /// Delete an existing SSO connection.
        /// </summary>
        public async Task<B2BSSODeleteConnectionResponse> DeleteConnection(
            B2BSSODeleteConnectionRequest request)
        {
            // Serialize the request model to JSON
            var jsonBody = JsonConvert.SerializeObject(request);

            // Create the content with the right content type
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            // Send the POST request to the specified URL
            var response = await _httpClient.PostAsync("/v1/b2b/sso/${data.organization_id}/connections/${data.connection_id}", content);

            // Read the response body (even if the response is not successful)
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                // If the response is successful, deserialize and return the response
                return JsonConvert.DeserializeObject<B2BSSODeleteConnectionResponse>(responseBody);
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
        /// Authenticate a user given a token. 
        /// This endpoint verifies that the user completed the SSO Authentication flow by verifying that the token
        /// is valid and hasn't expired.
        /// Provide the `session_duration_minutes` parameter to set the lifetime of the session. 
        /// If the `session_duration_minutes` parameter is not specified, a Stytch session will be created with a 60
        /// minute duration.
        /// To link this authentication event to an existing Stytch session, include either the `session_token` or
        /// `session_jwt` param.
        /// 
        /// If the Member is required to complete MFA to log in to the Organization, the returned value of
        /// `member_authenticated` will be `false`, and an `intermediate_session_token` will be returned.
        /// The `intermediate_session_token` can be passed into the
        /// [OTP SMS Authenticate endpoint](https://stytch.com/docs/b2b/api/authenticate-otp-sms),
        /// [TOTP Authenticate endpoint](https://stytch.com/docs/b2b/api/authenticate-totp),
        /// or [Recovery Codes Recover endpoint](https://stytch.com/docs/b2b/api/recovery-codes-recover) to complete
        /// the MFA step and acquire a full member session.
        /// The `session_duration_minutes` and `session_custom_claims` parameters will be ignored.
        /// 
        /// If a valid `session_token` or `session_jwt` is passed in, the Member will not be required to complete an
        /// MFA step.
        /// </summary>
        public async Task<B2BSSOAuthenticateResponse> Authenticate(
            B2BSSOAuthenticateRequest request)
        {
            // Serialize the request model to JSON
            var jsonBody = JsonConvert.SerializeObject(request);

            // Create the content with the right content type
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            // Send the POST request to the specified URL
            var response = await _httpClient.PostAsync("/v1/b2b/sso/authenticate", content);

            // Read the response body (even if the response is not successful)
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                // If the response is successful, deserialize and return the response
                return JsonConvert.DeserializeObject<B2BSSOAuthenticateResponse>(responseBody);
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

