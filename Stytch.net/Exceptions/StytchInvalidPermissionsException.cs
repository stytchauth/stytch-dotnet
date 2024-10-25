using System;

namespace Stytch.net.Exceptions
{
    public class StytchInvalidPermissionsException : Exception
    {
        public override string ToString()
        {
            return "StytchInvalidPermissionsException: Member does not have permission to perform the requested action";
        }
    }
}
