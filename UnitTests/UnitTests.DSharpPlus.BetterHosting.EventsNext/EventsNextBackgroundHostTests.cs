using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.BetterHosting.EventsNext.Services;
using DSharpPlus.BetterHosting.EventsNext.Services.Implementations;
using DSharpPlus.BetterHosting.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace UnitTests.DSharpPlus.BetterHosting.EventsNext;

public class EventsNextBackgroundHostTests
{
    private static EventsNextBackgroundHost<IEventHandlerManager> BuildSUT(out Mock<IEventHandlerManager> mockManager, out Mock<IConnectedClientProvider> providerMock) => BuildSUT<IEventHandlerManager>(out mockManager, out providerMock);

    private static EventsNextBackgroundHost<TManager> BuildSUT<TManager>(out Mock<TManager> mockManager, out Mock<IConnectedClientProvider> providerMock) where TManager : class, IEventHandlerManager
    {
        mockManager = new(MockBehavior.Strict);
        providerMock = new(MockBehavior.Strict);
        ILogger<EventsNextBackgroundHost<TManager>> logger = Mock.Of<ILogger<EventsNextBackgroundHost<TManager>>>(MockBehavior.Loose);
        return new(logger, mockManager.Object, providerMock.Object);
    }

    [Test]
    public void NoHandlersExitFast()
    {
        EventsNextBackgroundHost<IEventHandlerManager> sut = BuildSUT(out Mock<IEventHandlerManager> mockManager, out Mock<IConnectedClientProvider> providerMock);
        DiscordShardedClient client = new(new());
        providerMock.Setup(p => p.GetClientAsync(It.IsAny<CancellationToken>())).ReturnsAsync(client).Verifiable(Times.Once);

        mockManager.Setup(m => m.CanBeTriggered(client)).Returns(false);
        sut.ExecuteAsync(CancellationToken.None);

        providerMock.Verify();
        mockManager.Verify();
    }
}

file static class Reflection
{
    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "ExecuteAsync")]
    public static extern Task ExecuteAsync(this EventsNextBackgroundHost<IEventHandlerManager> @this, CancellationToken stoppingToken);
}