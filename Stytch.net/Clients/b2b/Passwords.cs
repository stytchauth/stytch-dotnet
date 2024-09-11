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
  public class Passwords
  {
    private readonly HttpClient _httpClient;
    public readonly PasswordsEmail Email;
    public readonly PasswordsSessions Sessions;
    public readonly PasswordsExistingPassword ExistingPassword;
    public Passwords(HttpClient client)
    {
      _httpClient = client;
        Email = new PasswordsEmail(_httpClient);
        Sessions = new PasswordsSessions(_httpClient);
        ExistingPassword = new PasswordsExistingPassword(_httpClient);
    }







    /// <summary>
    /// This API allows you to check whether the user’s provided password is valid, and to provide feedback to
    /// the user on how to increase the strength of their password.
    /// 
    /// This endpoint adapts to your Project's password strength configuration. If you're using
    /// [zxcvbn](https://stytch.com/docs/guides/passwords/strength-policy), the default, your passwords are
    /// considered valid if the strength score is >= 3. If you're using
    /// [LUDS](https://stytch.com/docs/guides/passwords/strength-policy), your passwords are considered valid if
    /// they meet the requirements that you've set with Stytch. You may update your password strength
    /// configuration in the [stytch dashboard](https://stytch.com/dashboard/password-strength-config).
    /// 
    /// ## Password feedback
    /// The zxcvbn_feedback and luds_feedback objects contains relevant fields for you to relay feedback to
    /// users that failed to create a strong enough password.
    /// 
    /// If you're using [zxcvbn](https://stytch.com/docs/guides/passwords/strength-policy), the feedback object
    /// will contain warning and suggestions for any password that does not meet the
    /// [zxcvbn](https://stytch.com/docs/guides/passwords/strength-policy) strength requirements. You can return
    /// these strings directly to the user to help them craft a strong password.
    /// 
    /// If you're using [LUDS](https://stytch.com/docs/guides/passwords/strength-policy), the feedback object
    /// will contain a collection of fields that the user failed or passed. You'll want to prompt the user to
    /// create a password that meets all requirements that they failed.
    /// </summary>
    public async Task<B2BPasswordsStrengthCheckResponse> StrengthCheck(
        B2BPasswordsStrengthCheckRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/b2b/passwords/strength_check", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<B2BPasswordsStrengthCheckResponse>(responseBody);
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
    /// Adds an existing password to a member's email that doesn't have a password yet. We support migrating
    /// members from passwords stored with bcrypt, scrypt, argon2, MD-5, SHA-1, and PBKDF2. This endpoint has a
    /// rate limit of 100 requests per second.
    /// 
    /// The member's email will be marked as verified when you use this endpoint.
    /// </summary>
    public async Task<B2BPasswordsMigrateResponse> Migrate(
        B2BPasswordsMigrateRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/b2b/passwords/migrate", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<B2BPasswordsMigrateResponse>(responseBody);
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
    /// Authenticate a member with their email address and password. This endpoint verifies that the member has
    /// a password currently set, and that the entered password is correct.
    /// 
    /// If you have breach detection during authentication enabled in your
    /// [password strength policy](https://stytch.com/docs/b2b/guides/passwords/strength-policies) and the
    /// member's credentials have appeared in the HaveIBeenPwned dataset, this endpoint will return a
    /// `member_reset_password` error even if the member enters a correct password. We force a password reset in
    /// this case to ensure that the member is the legitimate owner of the email address and not a malicious
    /// actor abusing the compromised credentials.
    /// 
    /// If the Member is required to complete MFA to log in to the Organization, the returned value of
    /// `member_authenticated` will be `false`, and an `intermediate_session_token` will be returned.
    /// The `intermediate_session_token` can be passed into the
    /// [OTP SMS Authenticate endpoint](https://stytch.com/docs/b2b/api/authenticate-otp-sms) to complete the
    /// MFA step and acquire a full member session.
    /// The `session_duration_minutes` and `session_custom_claims` parameters will be ignored.
    /// 
    /// If a valid `session_token` or `session_jwt` is passed in, the Member will not be required to complete an
    /// MFA step.
    /// </summary>
    public async Task<B2BPasswordsAuthenticateResponse> Authenticate(
        B2BPasswordsAuthenticateRequest request)
    {
        // Serialize the request model to JSON
        var jsonBody = JsonConvert.SerializeObject(request);

        // Create the content with the right content type
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Send the POST request to the specified URL
        var response = await _httpClient.PostAsync("/v1/b2b/passwords/authenticate", content);

        // Read the response body (even if the response is not successful)
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, deserialize and return the response
            return JsonConvert.DeserializeObject<B2BPasswordsAuthenticateResponse>(responseBody);
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

