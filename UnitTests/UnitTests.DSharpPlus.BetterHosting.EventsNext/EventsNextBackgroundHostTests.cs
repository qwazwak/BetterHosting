using System.Runtime.CompilerServices;
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
    public void NoHandlersExitFast()
    {
        DiscordShardedClient client = new(new());
        provider.Setup(p => p.GetClientAsync(It.IsAny<CancellationToken>())).ReturnsAsync(client).Verifiable(Times.Once);

        manager.Setup(m => m.CanBeTriggered(client)).Returns(false);
        host.ExecuteAsync(CancellationToken.None);
    }
}

file static class Reflection
{
    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "ExecuteAsync")]
    public static extern Task ExecuteAsync(this EventsNextBackgroundHost<IEventHandlerManager> @this, CancellationToken stoppingToken);
}