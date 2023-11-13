using System;
using System.Diagnostics.CodeAnalysis;
using DSharpPlus.BetterHosting.Interactivity.Services;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
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

        BetterHostingInteractivityExtensions.AddInteractivity(mockServices.Object);

        mockServices.Verify();
    }

    [Test]
    public void AddsSetupFull()
    {
        ServiceCollection services = new();
        Assert.That(services, Is.Empty);

        BetterHostingInteractivityExtensions.AddInteractivity(services);
        Assert.That(services, Has.Count.EqualTo(1));
        ServiceDescriptor setupDescriptor = services[0];

        Assert.That(setupDescriptor, IsDescriptor.From.AddTransient<IDiscordClientConfigurator, InteractivitySetup>());
    }
}
