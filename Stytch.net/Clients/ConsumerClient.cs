using Stytch.net.Clients.b2c;

namespace Stytch.net.Clients
{

  public class ConsumerClient
  {
    private readonly HttpClient _httpClient;
    public readonly CryptoWallets CryptoWallets;
    public readonly M2M M2M;
    public readonly MagicLinks MagicLinks;
    public readonly OAuth OAuth;
    public readonly OTPs OTPs;
    public readonly Passwords Passwords;
    public readonly Project Project;
    public readonly Sessions Sessions;
    public readonly TOTPs TOTPs;
    public readonly Users Users;
    public readonly WebAuthn WebAuthn;

    public ConsumerClient(HttpClient client)
    {
      _httpClient = client;
      CryptoWallets = new CryptoWallets(_httpClient);
      M2M = new M2M(_httpClient);
      MagicLinks = new MagicLinks(_httpClient);
      OAuth = new OAuth(_httpClient);
      OTPs = new OTPs(_httpClient);
      Passwords = new Passwords(_httpClient);
      Project = new Project(_httpClient);
      Sessions = new Sessions(_httpClient);
      TOTPs = new TOTPs(_httpClient);
      Users = new Users(_httpClient);
      WebAuthn = new WebAuthn(_httpClient);
    }
  }
}
