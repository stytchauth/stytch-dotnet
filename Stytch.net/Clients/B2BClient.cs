using Stytch.net.Clients.B2B;
using M2M = Stytch.net.Clients.Consumer.M2M;
using Project = Stytch.net.Clients.Consumer.Project;

namespace Stytch.net.Clients
{

    public class B2BClient : BaseClient
    {
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

        public B2BClient(ClientConfig config) : base(config)
        {
            Discovery = new Discovery(_httpClient, _config);
            M2M = new M2M(_httpClient, _config);
            MagicLinks = new MagicLinks(_httpClient, _config);
            OAuth = new OAuth(_httpClient, _config);
            OTPs = new OTPs(_httpClient, _config);
            Organizations = new Organizations(_httpClient, _config);
            Passwords = new Passwords(_httpClient, _config);
            Project = new Project(_httpClient, _config);
            RBAC = new RBAC(_httpClient, _config);
            RecoveryCodes = new RecoveryCodes(_httpClient, _config);
            SCIM = new SCIM(_httpClient, _config);
            SSO = new SSO(_httpClient, _config);
            Sessions = new Sessions(_httpClient, _config);
            TOTPs = new TOTPs(_httpClient, _config);
        }
    }

    // MANUAL(ConsumerClients)(types)
    // ADDIMPORT: using M2M = Stytch.net.Clients.Consumer.M2M;
    // ADDIMPORT: using Project = Stytch.net.Clients.Consumer.Project;
    // ENDMANUAL(ConsumerClients)

}
