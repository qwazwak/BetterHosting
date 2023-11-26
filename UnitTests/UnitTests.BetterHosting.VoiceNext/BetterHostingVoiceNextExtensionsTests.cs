using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System;
using BetterHosting.VoiceNext;
using BetterHosting.VoiceNext.Services.Configuration;
using DSharpPlus.VoiceNext;
using BetterHosting.VoiceNext.Services;
using BetterHosting.Services.Interfaces;
using BetterHosting.Services.Implementation.Extensions;
using BetterHosting.Services.Interfaces.Extensions;

namespace UnitTests.BetterHosting.VoiceNext;

[TestFixture(TestOf = typeof(BetterHostingVoiceNextExtensions))]
[SuppressMessage("Roslynator", "RCS1196:Call extension method as instance method.", Justification = "Make SUT clear")]
public class BetterHostingVoiceNextExtensionsTests
{
    [Test]
    public void AddInteractivityConfig_ThrowOnNull() => Assert.Throws<ArgumentNullException>(() => BetterHostingVoiceNextExtensions.AddVoiceNext(null!));

    [Test]
    public void ReturnsSame()
    {
        IServiceCollection mockServices = Mock.Of<IServiceCollection>(MockBehavior.Loose);

        IServiceCollection result = BetterHostingVoiceNextExtensions.AddVoiceNext(mockServices);

        Assert.That(result, Is.SameAs(mockServices));
    }

    [Test]
    public void AddsSetup()
    {
        Mock<IServiceCollection> mockServices = new(MockBehavior.Strict);

        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient<IDiscordClientConfigurator, VoiceNextSetup>())).Verifiable(Times.Once);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient<IDiscordExtensionConfigurator<VoiceNextExtension>, DiscordExtensionConfiguratorAdapter<IVoiceNextConfigurator, VoiceNextExtension>>())).Verifiable(Times.Once);

        BetterHostingVoiceNextExtensions.AddVoiceNext(mockServices.Object);

        mockServices.Verify();
    }
}
