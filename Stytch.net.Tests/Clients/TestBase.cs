using Stytch.net.Clients;

namespace Stytch.net.Tests.Clients;

public class TestBase
{

    protected readonly ClientConfig _clientConfig;

    public TestBase()
    {
        string? projectId = Environment.GetEnvironmentVariable("PROJECT_ID");
        if (string.IsNullOrEmpty(projectId))
        {
            throw new InvalidOperationException("Required environment variable PROJECT_ID is not set.");
        }

        string? projectSecret = Environment.GetEnvironmentVariable("PROJECT_SECRET");
        if (string.IsNullOrEmpty(projectId))
        {
            throw new InvalidOperationException("Required environment variable PROJECT_SECRET is not set.");
        }

        _clientConfig = new ClientConfig
        {
            ProjectId = projectId,
            ProjectSecret = projectSecret,
        };
    }
}