using Stytch.net.Clients.b2b;

namespace Stytch.net.Clients
{

  public class B2BClient
  {
    private readonly HttpClient _httpClient;
    public readonly Discovery Discovery;
    public readonly M2M M2M;
    public readonly MagicLinks MagicLinks;
    public readonly OAuth OAuth;
    public readonly OTPs OTPs;
    public readonly Organizations Organizations;
    public readonly Passwords Passwords;
    public readonly Project Project;
    public readonly RBAC RBAC;
    public readonly RecoveryCodes RecoveryCodes;
    public readonly SCIM SCIM;
    public readonly SSO SSO;
    public readonly Sessions Sessions;
    public readonly TOTPs TOTPs;

    public B2BClient(HttpClient client)
    {
      _httpClient = client;
      Discovery = new Discovery(_httpClient);
      M2M = new M2M(_httpClient);
      MagicLinks = new MagicLinks(_httpClient);
      OAuth = new OAuth(_httpClient);
      OTPs = new OTPs(_httpClient);
      Organizations = new Organizations(_httpClient);
      Passwords = new Passwords(_httpClient);
      Project = new Project(_httpClient);
      RBAC = new RBAC(_httpClient);
      RecoveryCodes = new RecoveryCodes(_httpClient);
      SCIM = new SCIM(_httpClient);
      SSO = new SSO(_httpClient);
      Sessions = new Sessions(_httpClient);
      TOTPs = new TOTPs(_httpClient);
    }
  }
}