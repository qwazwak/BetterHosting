using System;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.BetterHosting.EventsNext.Services;
using DSharpPlus.BetterHosting.EventsNext.Services.Implementations;
using DSharpPlus.BetterHosting.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Moq.AutoMock;

namespace UnitTests.DSharpPlus.BetterHosting.EventsNext;

[TestOf(typeof(EventsNextBackgroundHostBase))]
public class EventsNextBackgroundHostTests
{
    AutoMocker mocker = default!;
    Mock<IEventHandlerManager> manager = default!;
    Mock<IConnectedClientProvider> provider = default!;
    EventsNextBackgroundHostBase host = default!;

    [SetUp]
    public void SetUp()
    {
        mocker = new(MockBehavior.Strict);
        mocker.Use(new Mock<ILogger<EventsNextBackgroundHostBase>>(MockBehavior.Loose));
        manager = mocker.GetMock<IEventHandlerManager>();
        provider = mocker.GetMock<IConnectedClientProvider>();
        host = mocker.CreateInstance<EventsNextBackgroundHostBase>();
    }

    [TearDown]
    public void TearDown() => mocker.Verify();

    [Test]
    public void NoHandlersExitFast()
    {
        DiscordShardedClient client = new(new());
        manager.Setup(m => m.CanBeTriggered()).Returns(false);
        Task result = host.StartAsync(CancellationToken.None);
        Assert.That(result, Is.SameAs(Task.CompletedTask));
    }

    [Test]
    public async Task ExitAfterClient()
    {
        DiscordShardedClient client = new(new());
        manager.Setup(m => m.CanBeTriggered()).Returns(value: true);
        manager.Setup(m => m.CanBeTriggered(client)).Returns(false);
        provider.Setup(p => p.GetClientAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(client, TimeSpan.FromMilliseconds(5))
            .Verifiable(Times.Once);

        await host.StartAsync(CancellationToken.None);
    }

    [Test]
    public async Task ExecuteNothing()
    {
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