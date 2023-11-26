using Microsoft.Extensions.DependencyInjection;
using System;
using BetterHosting.Services.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace BetterHosting;

[TestFixture]
[TestOf(typeof(ClientConfiguratorExtensions))]
[SuppressMessage("Roslynator", "RCS1196:Call extension method as instance method.", Justification = "Make SUT clear")]
[SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Suppression is required")]
public class ClientConfiguratorExtensionsTests
{
    [Test]
    public void AddConfiguratorThrowsOnNull() => Assert.Throws<ArgumentNullException>(() => ClientConfiguratorExtensions.AddConfigurator<IDiscordClientConfigurator>(null!));

    [Test]
    public void AddConfigurator()
    {
        Mock<IServiceCollection> mockServices = new(MockBehavior.Strict);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient<IDiscordClientConfigurator, IDiscordClientConfigurator>()))
            .Verifiable(Times.Once);

        ClientConfiguratorExtensions.AddConfigurator<IDiscordClientConfigurator>(mockServices.Object);

        mockServices.Verify();
    }

}