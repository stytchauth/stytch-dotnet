using System;

namespace Stytch.net.Exceptions
{
    public class StytchTenancyMismatchException : Exception
    {
        public StytchTenancyMismatchException(string callerOrganizationId, string targetOrganizationId)
        {
            CallerOrganizationId = callerOrganizationId;
            TargetOrganizationId = targetOrganizationId;
        }

        public override string ToString()
        {
            return
                $"StytchTenancyMismatchException: CallerOrganizationId={CallerOrganizationId}, TargetOrganizationId={TargetOrganizationId}";
        }

        public string TargetOrganizationId { get; set; }

        public string CallerOrganizationId { get; set; }
    }
}