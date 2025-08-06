using Stytch.net.Models;

namespace Stytch.net.Tests.Utility;

public class RbacPolicy
{
    private class MockPolicyGetter : net.Utility.IB2BPolicyGetter
    {
        public B2BRBACPolicy MockPolicy { get; set; }

        public MockPolicyGetter(B2BRBACPolicy policy)
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

    private B2BRBACPolicy MockPolicy = new B2BRBACPolicy()
    {
        Resources = new List<B2BRBACPolicyResource>()
        {
            new B2BRBACPolicyResource()
            {
                ResourceId = "documents",
                Actions = new List<string>() { "create", "read", "write", "delete" }
            },
            new B2BRBACPolicyResource()
            {
                ResourceId = "images",
                Actions = new List<string>() { "create", "read", "delete" }
            }
        },
        Roles = new List<B2BRBACPolicyRole>()
        {
            new B2BRBACPolicyRole
            {
                RoleId = "default",
                Permissions = new List<B2BRBACPolicyRolePermission>() { },
            },
            new B2BRBACPolicyRole
            {
                RoleId = "organization_admin",
                Permissions = new List<B2BRBACPolicyRolePermission>()
                {
                    new B2BRBACPolicyRolePermission()
                    {
                        Actions = new List<string>() { "*" },
                        ResourceId = "documents",
                    },
                    new B2BRBACPolicyRolePermission()
                    {
                        Actions = new List<string>() { "*" },
                        ResourceId = "images",
                    }
                }
            },
            new B2BRBACPolicyRole
            {
                RoleId = "editor",
                Permissions = new List<B2BRBACPolicyRolePermission>()
                {
                    new B2BRBACPolicyRolePermission()
                    {
                        Actions = new List<string>() { "read", "write" },
                        ResourceId = "documents",
                    },
                    new B2BRBACPolicyRolePermission()
                    {
                        Actions = new List<string>() { "create", "read", "delete" },
                        ResourceId = "images",
                    }
                }
            },
            new B2BRBACPolicyRole
            {
                RoleId = "reader",
                Permissions = new List<B2BRBACPolicyRolePermission>()
                {
                    new B2BRBACPolicyRolePermission()
                    {
                        Actions = new List<string>() { "read", },
                        ResourceId = "documents",
                    },
                    new B2BRBACPolicyRolePermission()
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
