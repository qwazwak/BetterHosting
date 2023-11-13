using System;
using System.Diagnostics.CodeAnalysis;
using DSharpPlus.BetterHosting.Interactivity.Services;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTests.DSharpPlus.BetterHosting.Interactivity;

[TestFixture(TestOf = typeof(BetterHostingInteractivityExtensions))]
[SuppressMessage("Roslynator", "RCS1196:Call extension method as instance method.", Justification = "Make SUT clear")]
public class BetterHostingInteractivityExtensionsTests
{
    [Test]
    public void AddInteractivityConfig_ThrowOnNull() => Assert.Throws<ArgumentNullException>(() => BetterHostingInteractivityExtensions.AddInteractivity(null!));

    [Test]
    public void ReturnsSame()
    {
        IServiceCollection mockServices = Mock.Of<IServiceCollection>(MockBehavior.Loose);

        IServiceCollection result = BetterHostingInteractivityExtensions.AddInteractivity(mockServices);

        Assert.That(result, Is.SameAs(mockServices));
    }

    [Test]
    public void AddsSetup()
    {
        Mock<IServiceCollection> mockServices = new(MockBehavior.Strict);

        ServiceDescriptor setupDescriptor = new(typeof(IDiscordClientConfigurator), typeof(InteractivitySetup), ServiceLifetime.Transient);

        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient<IDiscordClientConfigurator, InteractivitySetup>())).Verifiable(Times.Once);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient<IDiscordExtensionConfigurator<InteractivityExtension>, DiscordExtensionConfiguratorAdapter<IInteractivityConfigurator, InteractivityExtension>>())).Verifiable(Times.Once);
        BetterHostingInteractivityExtensions.AddInteractivity(mockServices.Object);

        mockServices.Verify();
    }
}
