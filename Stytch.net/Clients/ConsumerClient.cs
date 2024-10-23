using Stytch.net.Clients.Consumer;

namespace Stytch.net.Clients
{

    public class ConsumerClient : BaseClient
    {
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

        public ConsumerClient(ClientConfig config) : base(config)
        {
            CryptoWallets = new CryptoWallets(_httpClient, _config);
            M2M = new M2M(_httpClient, _config);
            MagicLinks = new MagicLinks(_httpClient, _config);
            OAuth = new OAuth(_httpClient, _config);
            OTPs = new OTPs(_httpClient, _config);
            Passwords = new Passwords(_httpClient, _config);
            Project = new Project(_httpClient, _config);
            Sessions = new Sessions(_httpClient, _config);
            TOTPs = new TOTPs(_httpClient, _config);
            Users = new Users(_httpClient, _config);
            WebAuthn = new WebAuthn(_httpClient, _config);
        }
    }

}
