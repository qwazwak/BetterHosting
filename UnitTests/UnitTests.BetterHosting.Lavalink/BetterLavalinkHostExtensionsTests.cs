using System.Diagnostics.CodeAnalysis;
using System;
using BetterHosting.Lavalink;
using Microsoft.Extensions.DependencyInjection;
using BetterHosting.Lavalink.Services.Implementations;
using DSharpPlus.Lavalink;
using BetterHosting.Lavalink.Services;
using BetterHosting.Lavalink.Services.Hosted;
using Microsoft.Extensions.Hosting;
using BetterHosting.Services.Hosted;
using BetterHosting.Services.Interfaces;
using BetterHosting.Services.Implementation.Extensions;
using BetterHosting.Services.Interfaces.Extensions;

namespace UnitTests.BetterHosting.Lavalink;

[TestFixture(TestOf = typeof(BetterLavalinkHostExtensions))]
[SuppressMessage("Roslynator", "RCS1196:Call extension method as instance method.", Justification = "Make SUT clear")]
[SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Suppression is required")]
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

    [Test]
    public void AddOptions()
    {
        Mock<IServiceCollection> mockServices = new(MockBehavior.Loose);
        LavalinkConfiguration config = new();

        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.Options.AddSingletonOption(config))).Verifiable(Times.Once);

        BetterLavalinkHostExtensions.AddLavalinkConfig(mockServices.Object, config);
        mockServices.Verify();
    }
}
