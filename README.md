# Stytch dotnet Library

The Stytch .NET SDK makes it easy to use the Stytch user infrastructure API in server-side .NET applications.

It pairs well with the Stytch [Web SDK](https://www.npmjs.com/package/@stytch/vanilla-js) or your own custom authentication flow.


## Install

### Using .NET CLI:
```
dotnet add package Example.Stytch --version 1.0.2
```

## Usage

You can find your API credentials in the [Stytch Dashboard](https://stytch.com/dashboard/api-keys).

This client library supports all of Stytch's live products:

**B2C**

- [x] [Email Magic Links](https://stytch.com/docs/api/send-by-email)
- [x] [Embeddable Magic Links](https://stytch.com/docs/api/create-magic-link)
- [x] [OAuth logins](https://stytch.com/docs/api/oauth-google-start)
- [x] [SMS passcodes](https://stytch.com/docs/api/send-otp-by-sms)
- [x] [WhatsApp passcodes](https://stytch.com/docs/api/whatsapp-send)
- [x] [Email passcodes](https://stytch.com/docs/api/send-otp-by-email)
- [x] [Session Management](https://stytch.com/docs/api/session-auth)
- [x] [WebAuthn](https://stytch.com/docs/api/webauthn-register-start)
- [x] [User Management](https://stytch.com/docs/api/create-user)
- [x] [Time-based one-time passcodes (TOTPs)](https://stytch.com/docs/api/totp-create)
- [x] [Crypto wallets](https://stytch.com/docs/api/crypto-wallet-authenticate-start)
- [x] [Passwords](https://stytch.com/docs/api/password-create)

**B2B**

- [x] [Organizations](https://stytch.com/docs/b2b/api/organization-object)
- [x] [Members](https://stytch.com/docs/b2b/api/member-object)
- [x] [RBAC](https://stytch.com/docs/b2b/api/rbac-resource-object)
- [x] [Email Magic Links](https://stytch.com/docs/b2b/api/send-login-signup-email)
- [x] [OAuth logins](https://stytch.com/docs/b2b/api/oauth-google-start)
- [x] [Session Management](https://stytch.com/docs/b2b/api/session-object)
- [x] [Single-Sign On](https://stytch.com/docs/b2b/api/sso-authenticate-start)
- [x] [Discovery](https://stytch.com/docs/b2b/api/discovered-organization-object)
- [x] [Passwords](https://stytch.com/docs/b2b/api/passwords-authenticate)
- [x] [SMS OTP (MFA)](https://stytch.com/docs/b2b/api/otp-sms-send)
- [x] [M2M](https://stytch.com/docs/b2b/api/m2m-client)


### Example B2C usage

Create an API client:

```csharp
using Stytch;

var client = new ConsumerClient(new ClientConfig
{
    ProjectId = "project-live-c60c0abe-c25a-4472-a9ed-320c6667d317",
    Secret = "secret-live-80JASucyk7z_G8Z-7dVwZVGXL5NT_qGAQ2I="
});
```

Send a magic link by email:

```csharp
client.OTPs.Email.LoginOrCreate({
    Email = "sandbox@stytch.com",
    LoginMagicLinkUrl = "https://example.com/authenticate",
    SignupMagicLinkUrl = "https://example.com/authenticate"
});
```

Authenticate the token from the magic link:

```csharp
client.MagicLinks.Authenticate(new AuthenticateRequest
{
    Token = "DOYoip3rvIMMW5lgItikFK-Ak1CfMsgjuiCyI7uuU94="
});
```

### Example B2B usage

Create an API client:

```csharp
using Stytch;

var client = new B2BClient(new ClientConfig
{
    ProjectId = "project-live-c60c0abe-c25a-4472-a9ed-320c6667d317",
    Secret = "secret-live-80JASucyk7z_G8Z-7dVwZVGXL5NT_qGAQ2I="
});
```

Create an organization

```csharp
client.organizations.create({
    OrganizationName = "Acme Co",
    OrganizationSlug = "acme-co",
    EmailAllowedDomains = ["acme.co"],
});
```

Log the first user into the organization

```csharp
client.magicLinks.loginOrSignup({
    OrganizationId = "organization-id-from-create-response-...",
    EmailAddress = "admin@acme.co",
}));
```

## Documentation

See example requests and responses for all the endpoints in the [Stytch API Reference](https://stytch.com/docs/api).

Follow one of the [integration guides](https://stytch.com/docs/home#guides) or start with one of our [example apps](https://stytch.com/docs/home#example-apps).

## Support

If you've found a bug, [open an issue](https://github.com/stytchauth/stytch-otnet/issues/new)!

If you have questions or want help troubleshooting, join us in [Slack](https://stytch.com/docs/resources/support/overview) or email support@stytch.com.

If you've found a security vulnerability, please follow our [responsible disclosure instructions](https://stytch.com/docs/resources/security-and-trust/security#:~:text=Responsible%20disclosure%20program).


### TODO:
- [x] Update user-agent to be Stytch-dotnet
- [x] Move Magic Links to nested client attribute - Client.magicLinks.email.send
- [x] Infer Env from project ID
- [x] Codegen Bonanza
- [x] Docstrings
- [ ] Better tests
- [x] Run linter/formatter
- [ ] Example App
- [ ] Add JWT Manual support
- [ ] Add M2M Manual support
- [ ] Add CODEOWNERS, COC.md, DEVELOPMENT.md
- [ ] Polish README
- [ ] Set up auto publish workflow