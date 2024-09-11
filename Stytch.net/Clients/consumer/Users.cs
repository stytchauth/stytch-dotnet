// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!

using Newtonsoft.Json;
using Stytch.net.Models.Consumer;
using System.Text;




namespace Stytch.net.Clients.Consumer
{
    public class Users
    {
        private readonly HttpClient _httpClient;
        public Users(HttpClient client)
        {
            _httpClient = client;
        }

        /// <summary>
        /// Add a User to Stytch. A `user_id` is returned in the response that can then be used to perform other
        /// operations within Stytch. An `email` or a `phone_number` is required.
        /// </summary>
        public async Task<UsersCreateResponse> Create(
            UsersCreateRequest request)
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder($"/v1/users");

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());
            var jsonBody = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            httpReq.Content = content;

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<UsersCreateResponse>(responseBody)!;
            }
            else
            {
                // Optionally, throw an exception or return null or an error object
                throw new HttpRequestException(
                    $"Request failed with status code {response.StatusCode}: {responseBody}");
            }
        }
        /// <summary>
        /// Get information about a specific User.
        /// </summary>
        public async Task<UsersGetResponse> Get(
            UsersGetRequest request)
        {
            var method = HttpMethod.Get;
            var uriBuilder = new UriBuilder($"/v1/users/${request.UserId}");
            var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
            uriBuilder.Query = query.ToString();

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<UsersGetResponse>(responseBody)!;
            }
            else
            {
                // Optionally, throw an exception or return null or an error object
                throw new HttpRequestException(
                    $"Request failed with status code {response.StatusCode}: {responseBody}");
            }
        }
        /// <summary>
        /// Search for Users within your Stytch Project. Submit an empty `query` in the request to return all Users.
        /// </summary>
        public async Task<UsersSearchResponse> Search(
            UsersSearchRequest request)
        {
            var method = HttpMethod.Post;
            var uriBuilder = new UriBuilder($"/v1/users/search");

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());
            var jsonBody = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            httpReq.Content = content;

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<UsersSearchResponse>(responseBody)!;
            }
            else
            {
                // Optionally, throw an exception or return null or an error object
                throw new HttpRequestException(
                    $"Request failed with status code {response.StatusCode}: {responseBody}");
            }
        }
        /// <summary>
        /// Update a User's attributes.
        /// 
        /// **Note:** In order to add a new email address or phone number to an existing User object, pass the new
        /// email address or phone number into the respective `/send` endpoint for the authentication method of your
        /// choice. If you specify the existing User's `user_id` while calling the `/send` endpoint, the new,
        /// unverified email address or phone number will be added to the existing User object. If the user
        /// successfully authenticates within 5 minutes of the `/send` request, the new email address or phone
        /// number will be marked as verified and remain permanently on the existing Stytch User. Otherwise, it will
        /// be removed from the User object, and any subsequent login requests using that phone number will create a
        /// new User. We require this process to guard against an account takeover vulnerability.
        /// </summary>
        public async Task<UsersUpdateResponse> Update(
            UsersUpdateRequest request)
        {
            var method = HttpMethod.Put;
            var uriBuilder = new UriBuilder($"/v1/users/${request.UserId}");

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());
            var jsonBody = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            httpReq.Content = content;

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<UsersUpdateResponse>(responseBody)!;
            }
            else
            {
                // Optionally, throw an exception or return null or an error object
                throw new HttpRequestException(
                    $"Request failed with status code {response.StatusCode}: {responseBody}");
            }
        }
        /// <summary>
        /// Exchange a user's email address or phone number for another.
        /// 
        /// Must pass either an `email_address` or a `phone_number`.
        /// 
        /// This endpoint only works if the user has exactly one factor. You are able to exchange the type of factor
        /// for another as well, i.e. exchange an `email_address` for a `phone_number`.
        /// 
        /// Use this endpoint with caution as it performs an admin level action.
        /// </summary>
        public async Task<UsersExchangePrimaryFactorResponse> ExchangePrimaryFactor(
            UsersExchangePrimaryFactorRequest request)
        {
            var method = HttpMethod.Put;
            var uriBuilder = new UriBuilder($"/v1/users/${request.UserId}/exchange_primary_factor");

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());
            var jsonBody = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            httpReq.Content = content;

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<UsersExchangePrimaryFactorResponse>(responseBody)!;
            }
            else
            {
                // Optionally, throw an exception or return null or an error object
                throw new HttpRequestException(
                    $"Request failed with status code {response.StatusCode}: {responseBody}");
            }
        }
        /// <summary>
        /// Delete a User from Stytch.
        /// </summary>
        public async Task<UsersDeleteResponse> Delete(
            UsersDeleteRequest request)
        {
            var method = HttpMethod.Delete;
            var uriBuilder = new UriBuilder($"/v1/users/${request.UserId}");

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());
            var jsonBody = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            httpReq.Content = content;

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<UsersDeleteResponse>(responseBody)!;
            }
            else
            {
                // Optionally, throw an exception or return null or an error object
                throw new HttpRequestException(
                    $"Request failed with status code {response.StatusCode}: {responseBody}");
            }
        }
        /// <summary>
        /// Delete an email from a User.
        /// </summary>
        public async Task<UsersDeleteEmailResponse> DeleteEmail(
            UsersDeleteEmailRequest request)
        {
            var method = HttpMethod.Delete;
            var uriBuilder = new UriBuilder($"/v1/users/emails/${request.EmailId}");

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());
            var jsonBody = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            httpReq.Content = content;

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<UsersDeleteEmailResponse>(responseBody)!;
            }
            else
            {
                // Optionally, throw an exception or return null or an error object
                throw new HttpRequestException(
                    $"Request failed with status code {response.StatusCode}: {responseBody}");
            }
        }
        /// <summary>
        /// Delete a phone number from a User.
        /// </summary>
        public async Task<UsersDeletePhoneNumberResponse> DeletePhoneNumber(
            UsersDeletePhoneNumberRequest request)
        {
            var method = HttpMethod.Delete;
            var uriBuilder = new UriBuilder($"/v1/users/phone_numbers/${request.PhoneId}");

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());
            var jsonBody = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            httpReq.Content = content;

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<UsersDeletePhoneNumberResponse>(responseBody)!;
            }
            else
            {
                // Optionally, throw an exception or return null or an error object
                throw new HttpRequestException(
                    $"Request failed with status code {response.StatusCode}: {responseBody}");
            }
        }
        /// <summary>
        /// Delete a WebAuthn registration from a User.
        /// </summary>
        public async Task<UsersDeleteWebAuthnRegistrationResponse> DeleteWebAuthnRegistration(
            UsersDeleteWebAuthnRegistrationRequest request)
        {
            var method = HttpMethod.Delete;
            var uriBuilder = new UriBuilder($"/v1/users/webauthn_registrations/${request.WebAuthnRegistrationId}");

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());
            var jsonBody = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            httpReq.Content = content;

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<UsersDeleteWebAuthnRegistrationResponse>(responseBody)!;
            }
            else
            {
                // Optionally, throw an exception or return null or an error object
                throw new HttpRequestException(
                    $"Request failed with status code {response.StatusCode}: {responseBody}");
            }
        }
        /// <summary>
        /// Delete a biometric registration from a User.
        /// </summary>
        public async Task<UsersDeleteBiometricRegistrationResponse> DeleteBiometricRegistration(
            UsersDeleteBiometricRegistrationRequest request)
        {
            var method = HttpMethod.Delete;
            var uriBuilder = new UriBuilder($"/v1/users/biometric_registrations/${request.BiometricRegistrationId}");

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());
            var jsonBody = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            httpReq.Content = content;

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<UsersDeleteBiometricRegistrationResponse>(responseBody)!;
            }
            else
            {
                // Optionally, throw an exception or return null or an error object
                throw new HttpRequestException(
                    $"Request failed with status code {response.StatusCode}: {responseBody}");
            }
        }
        /// <summary>
        /// Delete a TOTP from a User.
        /// </summary>
        public async Task<UsersDeleteTOTPResponse> DeleteTOTP(
            UsersDeleteTOTPRequest request)
        {
            var method = HttpMethod.Delete;
            var uriBuilder = new UriBuilder($"/v1/users/totps/${request.TOTPId}");

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());
            var jsonBody = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            httpReq.Content = content;

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<UsersDeleteTOTPResponse>(responseBody)!;
            }
            else
            {
                // Optionally, throw an exception or return null or an error object
                throw new HttpRequestException(
                    $"Request failed with status code {response.StatusCode}: {responseBody}");
            }
        }
        /// <summary>
        /// Delete a crypto wallet from a User.
        /// </summary>
        public async Task<UsersDeleteCryptoWalletResponse> DeleteCryptoWallet(
            UsersDeleteCryptoWalletRequest request)
        {
            var method = HttpMethod.Delete;
            var uriBuilder = new UriBuilder($"/v1/users/crypto_wallets/${request.CryptoWalletId}");

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());
            var jsonBody = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            httpReq.Content = content;

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<UsersDeleteCryptoWalletResponse>(responseBody)!;
            }
            else
            {
                // Optionally, throw an exception or return null or an error object
                throw new HttpRequestException(
                    $"Request failed with status code {response.StatusCode}: {responseBody}");
            }
        }
        /// <summary>
        /// Delete a password from a User.
        /// </summary>
        public async Task<UsersDeletePasswordResponse> DeletePassword(
            UsersDeletePasswordRequest request)
        {
            var method = HttpMethod.Delete;
            var uriBuilder = new UriBuilder($"/v1/users/passwords/${request.PasswordId}");

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());
            var jsonBody = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            httpReq.Content = content;

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<UsersDeletePasswordResponse>(responseBody)!;
            }
            else
            {
                // Optionally, throw an exception or return null or an error object
                throw new HttpRequestException(
                    $"Request failed with status code {response.StatusCode}: {responseBody}");
            }
        }
        /// <summary>
        /// Delete an OAuth registration from a User.
        /// </summary>
        public async Task<UsersDeleteOAuthRegistrationResponse> DeleteOAuthRegistration(
            UsersDeleteOAuthRegistrationRequest request)
        {
            var method = HttpMethod.Delete;
            var uriBuilder = new UriBuilder($"/v1/users/oauth/${request.OAuthUserRegistrationId}");

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());
            var jsonBody = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            httpReq.Content = content;

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<UsersDeleteOAuthRegistrationResponse>(responseBody)!;
            }
            else
            {
                // Optionally, throw an exception or return null or an error object
                throw new HttpRequestException(
                    $"Request failed with status code {response.StatusCode}: {responseBody}");
            }
        }

    }

}

