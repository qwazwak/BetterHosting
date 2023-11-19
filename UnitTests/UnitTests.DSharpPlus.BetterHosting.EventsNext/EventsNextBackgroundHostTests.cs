using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.BetterHosting.EventsNext.Services;
using DSharpPlus.BetterHosting.EventsNext.Services.Implementations;
using DSharpPlus.BetterHosting.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Moq.AutoMock;

namespace UnitTests.DSharpPlus.BetterHosting.EventsNext;

[TestFixture(TestOf = typeof(EventsNextBackgroundHost<>))]
public class EventsNextBackgroundHostTests
{
    AutoMocker mocker = default!;
    Mock<IEventHandlerManager> manager = default!;
    Mock<IConnectedClientProvider> provider = default!;
    EventsNextBackgroundHost<IEventHandlerManager> host = default!;

    [SetUp]
    public void SetUp()
    {
        mocker = new(MockBehavior.Strict);
        mocker.Use(new Mock<ILogger<EventsNextBackgroundHost<IEventHandlerManager>>>(MockBehavior.Loose));
        manager = mocker.GetMock<IEventHandlerManager>();
        provider = mocker.GetMock<IConnectedClientProvider>();
        host = mocker.CreateInstance<EventsNextBackgroundHost<IEventHandlerManager>>();
    }

    [TearDown]
    public void TearDown() => mocker.Verify();

    [Test]
    public async Task NoHandlersExitFast()
    {
        DiscordShardedClient client = new(new());
        provider.Setup(p => p.GetClientAsync(It.IsAny<CancellationToken>())).ReturnsAsync(client).Verifiable(Times.Once);

        manager.Setup(m => m.CanBeTriggered(client)).Returns(false);
        Task result = host.StartAsync(CancellationToken.None);
        Assert.That(result, Is.SameAs(Task.CompletedTask));
        await result;
    }

    [Test]
    public async Task CallStop()
    {
        manager.Setup(m => m.Stop()).Verifiable(Times.Once);
        Task result = host.StopAsync(CancellationToken.None);
        Assert.That(result, Is.SameAs(Task.CompletedTask));
        await result;
    }
}