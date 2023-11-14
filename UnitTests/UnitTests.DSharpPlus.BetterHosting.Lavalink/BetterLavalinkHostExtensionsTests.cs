using System.Diagnostics.CodeAnalysis;
using System;
using DSharpPlus.BetterHosting.Lavalink;
using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.BetterHosting.Lavalink.Services.Implementations;
using DSharpPlus.Lavalink;
using DSharpPlus.BetterHosting.Lavalink.Services;
using DSharpPlus.BetterHosting.Lavalink.Services.Hosted;
using Microsoft.Extensions.Hosting;
using DSharpPlus.BetterHosting.Services.Hosted;
using DSharpPlus.BetterHosting.Services.Implementation;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;

namespace UnitTests.DSharpPlus.BetterHosting.Lavalink;

[TestFixture(TestOf = typeof(BetterLavalinkHostExtensions))]
[SuppressMessage("Roslynator", "RCS1196:Call extension method as instance method.", Justification = "Make SUT clear")]
public class BetterLavalinkHostExtensionsTests
{
    [Test]
    public void AddInteractivityConfig_ThrowOnNull() => Assert.Throws<ArgumentNullException>(() => BetterLavalinkHostExtensions.AddLavalink(null!));

    [Test]
    public void ReturnsSame()
    {
        IServiceCollection mockServices = Mock.Of<IServiceCollection>(MockBehavior.Loose);

        IServiceCollection result = BetterLavalinkHostExtensions.AddLavalink(mockServices);

        Assert.That(result, Is.SameAs(mockServices));
    }

    [Test]
    public void AddsSetup()
    {
        Mock<IServiceCollection> mockServices = new(MockBehavior.Strict);

        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient<LavalinkBackgroundService>())).Verifiable(Times.Once);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddSingleton<IHostedService, DiscordBackgroundServiceHost<LavalinkBackgroundService>>())).Verifiable(Times.Once);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient<IDiscordClientConfigurator, LavalinkSetup>())).Verifiable(Times.Once);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient<IDiscordExtensionConfigurator<LavalinkExtension>, DiscordExtensionConfiguratorAdapter<ILavalinkConfigurator, LavalinkExtension>>())).Verifiable(Times.Once);

        BetterLavalinkHostExtensions.AddLavalink(mockServices.Object);

        mockServices.Verify();
    }
}
