using Stytch.net.Models.Consumer;

namespace Stytch.net.Tests.Utility;

public class RbacPolicy
{
    private class MockPolicyGetter : net.Utility.IPolicyGetter
    {
        public Policy MockPolicy { get; set; }

        public MockPolicyGetter(Policy policy)
        {
            MockPolicy = policy;
        }

        public Task<B2BRBACPolicyResponse> Policy(B2BRBACPolicyRequest request)
        {
            return Task.FromResult(new B2BRBACPolicyResponse()
            {
                Policy = MockPolicy
            });
        }
    }

    private Policy MockPolicy = new Policy()
    {
        Resources = new List<PolicyResource>()
        {
            new PolicyResource()
            {
                ResourceId = "documents",
                Actions = new List<string>() { "create", "read", "write", "delete" }
            },
            new PolicyResource()
            {
                ResourceId = "images",
                Actions = new List<string>() { "create", "read", "delete" }
            }
        },
        Roles = new List<PolicyRole>()
        {
            new PolicyRole
            {
                RoleId = "default",
                Permissions = new List<PolicyRolePermission>() { },
            },
            new PolicyRole
            {
                RoleId = "organization_admin",
                Permissions = new List<PolicyRolePermission>()
                {
                    new PolicyRolePermission()
                    {
                        Actions = new List<string>() { "*" },
                        ResourceId = "documents",
                    },
                    new PolicyRolePermission()
                    {
                        Actions = new List<string>() { "*" },
                        ResourceId = "images",
                    }
                }
            },
            new PolicyRole
            {
                RoleId = "editor",
                Permissions = new List<PolicyRolePermission>()
                {
                    new PolicyRolePermission()
                    {
                        Actions = new List<string>() { "read", "write" },
                        ResourceId = "documents",
                    },
                    new PolicyRolePermission()
                    {
                        Actions = new List<string>() { "create", "read", "delete" },
                        ResourceId = "images",
                    }
                }
            },
            new PolicyRole
            {
                RoleId = "reader",
                Permissions = new List<PolicyRolePermission>()
                {
                    new PolicyRolePermission()
                    {
                        Actions = new List<string>() { "read", },
                        ResourceId = "documents",
                    },
                    new PolicyRolePermission()
                    {
                        Actions = new List<string>() { "read" },
                        ResourceId = "images",
                    }
                }
            }
        }
    };

    [Theory]
    [InlineData(new string[] { "default", "reader" }, "documents", "read", true)]
    [InlineData(new string[] { "default", "organization_admin" }, "documents", "read", true)]
    [InlineData(new string[] { "default", "reader", "editor", "organization_admin" }, "documents", "read", true)]
    [InlineData(new string[] { "default", "reader", "editor", "organization_admin" }, "images", "create", true)]
    [InlineData(new string[] { "default", "editor" }, "documents", "delete", false)]
    [InlineData(new string[] { "default", "editor" }, "images", "write", false)]
    public async void AuthorizeRbacRolesBehavesAsExpected(string[] roles, string resourceId, string action,
        bool expected)
    {
        var authorizationParams = new AuthorizationParams
        {
            ResourceID = resourceId,
            Action = action,
            Roles = new List<string>(roles)
        };

        var result = await net.Utility.AuthorizeRbacRoles(new MockPolicyGetter(MockPolicy), authorizationParams);

        Assert.Equal(expected, result);
    }
}