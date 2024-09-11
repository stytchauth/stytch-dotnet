// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!

using Newtonsoft.Json;
using Stytch.net.Exceptions;
using Stytch.net.Models.Consumer;
using System.Text;




namespace Stytch.net.Clients.B2B
{
    public class Discovery
    {
        private readonly HttpClient _httpClient;
        public readonly DiscoveryIntermediateSessions IntermediateSessions;
        public readonly DiscoveryOrganizations Organizations;
        public Discovery(HttpClient client)
        {
            _httpClient = client;
            IntermediateSessions = new DiscoveryIntermediateSessions(_httpClient);
            Organizations = new DiscoveryOrganizations(_httpClient);
        }


    }

}

