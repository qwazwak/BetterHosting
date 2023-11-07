using DSharpPlus.BetterHosting.Services.Implementation;
using DSharpPlus.Entities;
using Microsoft.Extensions.Options;
using Moq;

namespace UnitTests.DSharpPlus.BetterHosting.Services.Implementation;

public class DiscordActivityOptionsAdapterTests
{
    [Test]
    public void ReturnsSame()
    {
        DiscordActivity activity = new();
        Mock<IOptions<DiscordActivity>> mockOptions = new(MockBehavior.Strict);
        mockOptions.Setup(o => o.Value).Returns(activity).Verifiable(Times.Once);

        DefaultActivityOptionsAdapter adapter = new(mockOptions.Object);

        DiscordActivity returned = adapter.DefaultActivity;
        mockOptions.Verify();
        Assert.That(returned, Is.SameAs(activity));
    }
}