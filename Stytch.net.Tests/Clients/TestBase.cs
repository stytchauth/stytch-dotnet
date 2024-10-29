using Stytch.net.Clients;

namespace Stytch.net.Tests.Clients;

public class TestBase
{

    protected readonly ClientConfig _clientConfig;
    protected readonly net.Clients.ConsumerClient consumerClient;

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

        consumerClient = new Stytch.net.Clients.ConsumerClient(_clientConfig);
    }


    protected void AssertEqualTimestamps(DateTime? first, DateTime? second)
    {
        Assert.Equal(Assert.NotNull(first), Assert.NotNull(second), TimeSpan.FromSeconds(2));
    }
}