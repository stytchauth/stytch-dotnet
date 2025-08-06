using System;
using Stytch.net.Clients.B2B;

namespace Stytch.net.Clients
{

    public class B2BClient : BaseClient
    {
        public readonly ConnectedApp ConnectedApp;
        public readonly Discovery Discovery;
        public readonly Fraud Fraud;
        public readonly Impersonation Impersonation;
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
            ConnectedApp = new ConnectedApp(_httpClient, _config);
            Discovery = new Discovery(_httpClient, _config);
            Fraud = new Fraud(_fraudClient, _config);
            Impersonation = new Impersonation(_httpClient, _config);
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

            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/v1/b2b/sessions/jwks/{config.ProjectId}"
            };
            _config.JwksUri = uriBuilder.ToString();
        }
    }

}
