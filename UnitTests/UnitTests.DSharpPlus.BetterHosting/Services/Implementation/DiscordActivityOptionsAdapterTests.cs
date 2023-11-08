using DSharpPlus.BetterHosting.Services.Implementation;
using DSharpPlus.Entities;
using Microsoft.Extensions.Options;

namespace UnitTests.DSharpPlus.BetterHosting.Services.Implementation;

public class DiscordActivityOptionsAdapterTests
{
    [Test]
    public void ConstructDoesNothing()
    {
        Mock<IOptions<DiscordActivity>> mockOptions = new(MockBehavior.Strict);
        DefaultActivityOptionsAdapter adapter = new(mockOptions.Object);
        Assert.That(adapter, Is.Not.Null);
        mockOptions.VerifyNoOtherCalls();
    }

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