using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.BetterHosting.Services.Hosted;
using DSharpPlus.BetterHosting.Services.Interfaces;
using DSharpPlus.Entities;
using Microsoft.Extensions.Logging;
using Moq.AutoMock;

namespace UnitTests.DSharpPlus.BetterHosting.Services.Hosted;

[TestFixture(TestOf = typeof(DiscordActivityStateController))]
public class DiscordActivityStateControllerTests
{
    AutoMocker mocker = default!;
    Mock<IDefaultActivityProvider> provider = default!;
    DiscordActivityStateController controller = default!;

    [SetUp]
    public void SetUp()
    {
        mocker = new(MockBehavior.Strict);
        mocker.Use(new Mock<ILogger<DiscordActivityStateController>>(MockBehavior.Loose));
        provider = mocker.GetMock<IDefaultActivityProvider>();
        controller = mocker.CreateInstance<DiscordActivityStateController>();
    }

    [TearDown]
    public void TearDown() => mocker.Verify();

    [Test]
    public void ConstructorDoesNothing() { }

    [Test]
    public async Task TestConstruction()
    {
        DiscordActivity activity = new();
        provider.Setup(p => p.DefaultActivity).Returns(activity).Verifiable(Times.Once);

        DiscordShardedClient client = new(new());
        //Due to DSharpPlus's sealed classes w/o interfaces, there is nothing more we can test.
        await controller.AfterConnected(client, CancellationToken.None);
    }
}