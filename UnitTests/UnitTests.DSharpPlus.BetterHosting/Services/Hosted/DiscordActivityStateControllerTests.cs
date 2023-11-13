using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.BetterHosting.Services.Hosted;
using DSharpPlus.BetterHosting.Services.Interfaces;
using DSharpPlus.Entities;
using Microsoft.Extensions.Logging;

namespace UnitTests.DSharpPlus.BetterHosting.Services.Hosted;

[TestFixture(TestOf = typeof(DiscordActivityStateController))]
public class DiscordActivityStateControllerTests
{
    [Test]
    public void ConstructorDoesNothing()
    {
        Mock<IDefaultActivityProvider> mockProvider = new(MockBehavior.Strict);
        Mock<ILogger<DiscordActivityStateController>> mockLogger = new(MockBehavior.Loose);

        DiscordActivityStateController sut = new(mockLogger.Object, mockProvider.Object);
        Assert.That(sut, Is.Not.Null);
        mockLogger.Verify();
        mockProvider.Verify();
    }

    [Test]
    public async Task TestConstruction()
    {
        DiscordShardedClient client = new(new());
        DiscordActivity activity = new();
        Mock<IDefaultActivityProvider> mockProvider = new(MockBehavior.Strict);
        mockProvider.Setup(p => p.DefaultActivity).Returns(activity).Verifiable(Times.Once);
        Mock<ILogger<DiscordActivityStateController>> mockLogger = new(MockBehavior.Loose);

        DiscordActivityStateController sut = new(mockLogger.Object, mockProvider.Object);

        //Due to DSharpPlus's sealed classes w/o interfaces, there is nothing more we can test.
        await sut.AfterConnected(client, CancellationToken.None);

        mockLogger.Verify();
        mockProvider.Verify();
    }
}