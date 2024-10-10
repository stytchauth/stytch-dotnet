using System.Net.Http;
using System;

namespace Stytch.net.Exceptions
{
    public class StytchNetworkException : Exception
    {
        public HttpResponseMessage Response { get; set; }

        public StytchNetworkException(string message, HttpResponseMessage response)
            : base(message)
        {
            Response = response;
        }
    }
}
