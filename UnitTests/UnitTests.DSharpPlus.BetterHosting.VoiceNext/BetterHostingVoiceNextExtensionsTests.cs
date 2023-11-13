using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System;
using DSharpPlus.BetterHosting.VoiceNext;
using DSharpPlus.BetterHosting.VoiceNext.Services.Configuration;

namespace UnitTests.DSharpPlus.BetterHosting.VoiceNext;

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

        BetterHostingVoiceNextExtensions.AddVoiceNext(mockServices.Object);

        mockServices.Verify();
    }
}
