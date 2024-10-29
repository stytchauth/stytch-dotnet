using System.Collections.Generic;
using System.Linq;
using Stytch.net.Models.Consumer;

namespace Stytch.net
{
    public class AuthorizationParams
    {
        public string ResourceID { get; set; }
        public string Action { get; set; }
        public List<string> Roles { get; set; }
    }


    public class RbacPolicy
    {
        private const string Wildcard = "*";

        private readonly Policy _policy;
        public RbacPolicy(Policy policyDocument)
        {
            _policy = policyDocument;
        }

        public bool IsAuthorized(AuthorizationParams authorizationParams)
        {
            var matched = _policy.Roles
                .Where(role => authorizationParams.Roles.Contains(role.RoleId))
                .SelectMany(role => role.Permissions)
                .Where(permission =>
                {
                    var hasMatchingAction = permission.Actions.Contains(authorizationParams.Action) ||
                                            permission.Actions.Contains(Wildcard);
                    var hasMatchingResource = authorizationParams.ResourceID == permission.ResourceId;
                    return hasMatchingResource && hasMatchingAction;
                }).Count();

            return matched > 0;
        }
    }
}
