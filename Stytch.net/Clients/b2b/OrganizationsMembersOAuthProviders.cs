// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Stytch.net.Exceptions;
using Stytch.net.Models.Consumer;




namespace Stytch.net.Clients.B2B
{
    public class OrganizationsMembersOAuthProviders
    {
        private readonly ClientConfig _config;
        private readonly HttpClient _httpClient;
        public OrganizationsMembersOAuthProviders(HttpClient client, ClientConfig config)
        {
            _httpClient = client;
            _config = config;
        }

        /// <summary>
        /// Retrieve the saved Google access token and ID token for a member. After a successful OAuth login, Stytch
        /// will save the 
        /// issued access token and ID token from the identity provider. If a refresh token has been issued, Stytch
        /// will refresh the 
        /// access token automatically.
        /// 
        /// Google One Tap does not return access tokens. If the member has only authenticated through Google One
        /// Tap and not through a regular Google OAuth flow, this endpoint will not return any tokens.
        /// 
        /// __Note:__ Google does not issue a refresh token on every login, and refresh tokens may expire if unused.
        /// To force a refresh token to be issued, pass the `?provider_prompt=consent` query param into the
        /// [Start Google OAuth flow](https://stytch.com/docs/b2b/api/oauth-google-start) endpoint.
        /// </summary>
        public async Task<B2BOrganizationsMembersOAuthProvidersGoogleResponse> Google(
            B2BOrganizationsMembersOAuthProvidersProviderInformationRequest request
        )
        {
            var method = HttpMethod.Get;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/organizations/{request.OrganizationId}/members/{request.MemberId}/oauth_providers/google"
            };
            uriBuilder.Query = Utility.BuildQueryString(new Dictionary<string, string> {
            {"include_refresh_token", (request.IncludeRefreshToken).ToString().ToLower()},
        });

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<B2BOrganizationsMembersOAuthProvidersGoogleResponse>(responseBody);
            }
            try
            {
                var apiException = JsonConvert.DeserializeObject<StytchApiException>(responseBody);
                throw apiException;
            }
            catch (JsonException)
            {
                throw new StytchNetworkException($"Unexpected error occurred: {responseBody}", response);
            }
        }
        /// <summary>
        /// Retrieve the saved Microsoft access token and ID token for a member. After a successful OAuth login,
        /// Stytch will save the
        /// issued access token and ID token from the identity provider. If a refresh token has been issued, Stytch
        /// will refresh the
        /// access token automatically.
        /// </summary>
        public async Task<B2BOrganizationsMembersOAuthProvidersMicrosoftResponse> Microsoft(
            B2BOrganizationsMembersOAuthProvidersProviderInformationRequest request
        )
        {
            var method = HttpMethod.Get;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/organizations/{request.OrganizationId}/members/{request.MemberId}/oauth_providers/microsoft"
            };
            uriBuilder.Query = Utility.BuildQueryString(new Dictionary<string, string> {
            {"include_refresh_token", (request.IncludeRefreshToken).ToString().ToLower()},
        });

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<B2BOrganizationsMembersOAuthProvidersMicrosoftResponse>(responseBody);
            }
            try
            {
                var apiException = JsonConvert.DeserializeObject<StytchApiException>(responseBody);
                throw apiException;
            }
            catch (JsonException)
            {
                throw new StytchNetworkException($"Unexpected error occurred: {responseBody}", response);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public async Task<B2BOrganizationsMembersOAuthProvidersSlackResponse> Slack(
            B2BOrganizationsMembersOAuthProvidersSlackRequest request
        )
        {
            var method = HttpMethod.Get;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/organizations/{request.OrganizationId}/members/{request.MemberId}/oauth_providers/slack"
            };

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<B2BOrganizationsMembersOAuthProvidersSlackResponse>(responseBody);
            }
            try
            {
                var apiException = JsonConvert.DeserializeObject<StytchApiException>(responseBody);
                throw apiException;
            }
            catch (JsonException)
            {
                throw new StytchNetworkException($"Unexpected error occurred: {responseBody}", response);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public async Task<B2BOrganizationsMembersOAuthProvidersHubspotResponse> Hubspot(
            B2BOrganizationsMembersOAuthProvidersProviderInformationRequest request
        )
        {
            var method = HttpMethod.Get;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/organizations/{request.OrganizationId}/members/{request.MemberId}/oauth_providers/hubspot"
            };
            uriBuilder.Query = Utility.BuildQueryString(new Dictionary<string, string> {
            {"include_refresh_token", (request.IncludeRefreshToken).ToString().ToLower()},
        });

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<B2BOrganizationsMembersOAuthProvidersHubspotResponse>(responseBody);
            }
            try
            {
                var apiException = JsonConvert.DeserializeObject<StytchApiException>(responseBody);
                throw apiException;
            }
            catch (JsonException)
            {
                throw new StytchNetworkException($"Unexpected error occurred: {responseBody}", response);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public async Task<B2BOrganizationsMembersOAuthProvidersGithubResponse> Github(
            B2BOrganizationsMembersOAuthProvidersProviderInformationRequest request
        )
        {
            var method = HttpMethod.Get;
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/organizations/{request.OrganizationId}/members/{request.MemberId}/oauth_providers/github"
            };
            uriBuilder.Query = Utility.BuildQueryString(new Dictionary<string, string> {
            {"include_refresh_token", (request.IncludeRefreshToken).ToString().ToLower()},
        });

            var httpReq = new HttpRequestMessage(method, uriBuilder.ToString());

            var response = await _httpClient.SendAsync(httpReq);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<B2BOrganizationsMembersOAuthProvidersGithubResponse>(responseBody);
            }
            try
            {
                var apiException = JsonConvert.DeserializeObject<StytchApiException>(responseBody);
                throw apiException;
            }
            catch (JsonException)
            {
                throw new StytchNetworkException($"Unexpected error occurred: {responseBody}", response);
            }
        }

    }

}

