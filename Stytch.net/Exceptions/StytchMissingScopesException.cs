using System;
using System.Collections.Generic;

namespace Stytch.net.Exceptions
{
    public class StytchMissingScopesException : Exception
    {
        public StytchMissingScopesException()
        {
        }

        public string RequiredScope { get; set; }
        public List<string> ClientScopes { get; set; }
        public string ClientId { get; set; }

        public override string ToString()
        {
            return $"StytchMissingScopesException: {ClientId} needed {RequiredScope}, had {ClientScopes}";
        }
    }

}