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
            CryptoWallets = new CryptoWallets(_httpClient);
            M2M = new M2M(_httpClient, _config);
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
