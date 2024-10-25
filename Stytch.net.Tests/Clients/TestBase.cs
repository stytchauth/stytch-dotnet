using Stytch.net.Clients;

namespace Stytch.net.Tests.Clients;

public class TestBase
{
    protected void AssertEqualTimestamps(DateTime? first, DateTime? second)
    {
        Assert.Equal(Assert.NotNull(first), Assert.NotNull(second), TimeSpan.FromSeconds(2));
    }
}

public class ConsumerTestBase : TestBase
{
    protected readonly ClientConfig _clientConfig;
    protected readonly net.Clients.ConsumerClient consumerClient;

    public ConsumerTestBase()
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

        consumerClient = new Stytch.net.Clients.ConsumerClient(_clientConfig);
    }
}

public class B2BTestBase : TestBase
{
    protected readonly ClientConfig _clientConfig;
    protected readonly net.Clients.B2BClient b2bClient;

    public B2BTestBase()
    {
        string? projectId = Environment.GetEnvironmentVariable("B2B_PROJECT_ID");
        if (string.IsNullOrEmpty(projectId))
        {
            throw new InvalidOperationException("Required environment variable B2B_PROJECT_ID is not set.");
        }

        string? projectSecret = Environment.GetEnvironmentVariable("B2B_PROJECT_SECRET");
        if (string.IsNullOrEmpty(projectId))
        {
            throw new InvalidOperationException("Required environment variable B2B_PROJECT_SECRET is not set.");
        }

        _clientConfig = new ClientConfig
        {
            ProjectId = projectId,
            ProjectSecret = projectSecret,
        };

        b2bClient = new Stytch.net.Clients.B2BClient(_clientConfig);
    }
}