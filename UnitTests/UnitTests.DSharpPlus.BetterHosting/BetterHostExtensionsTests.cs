using DSharpPlus.BetterHosting.Services.Hosted;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using DSharpPlus.BetterHosting.Services;
using DSharpPlus.BetterHosting.Services.Interfaces.Internal;
using DSharpPlus.BetterHosting.Services.Implementation.Internal;
using DSharpPlus.BetterHosting.Services.Interfaces;

namespace DSharpPlus.BetterHosting;

[TestFixture(TestOf = typeof(BetterHostExtensions))]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator", "RCS1196:Call extension method as instance method.", Justification = "Make SUT clear")]
public class BetterHostExtensionsTests
{
    [Test]
    public void AddBetterHosting()
    {
        Mock<IServiceCollection> mockServices = new(MockBehavior.Strict);

        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient<IClientConstructor, ClientConstructor>()))
            .Verifiable(Times.Once);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient<IMasterClientConfigurator, MasterClientConfigurator>()))
            .Verifiable(Times.Once);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient<IShortClientConstructor, ShortClientConstructor>()))
            .Verifiable(Times.Once);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddSingleton<IClientManager, ClientManager>()))
            .Verifiable(Times.Once);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient<IConnectedClientProvider, ClientProvider>()))
            .Verifiable(Times.Once);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddSingleton<IHostedService, DiscordClientHost>()))
            .Verifiable(Times.Once);

        mockServices.Setup(s => s.Add(It.Is<ServiceDescriptor>(d => d.ServiceType == typeof(IServiceProvider) && NamedServices.RootServiceProvider.Equals(d.ServiceKey) && d.KeyedImplementationFactory != BetterHostExtensions.ServiceProviderFactory)))
            .Verifiable(Times.Once);
        mockServices.Setup(s => s.Add(It.Is<ServiceDescriptor>(d => d.ServiceType == typeof(IKeyedServiceProvider) && NamedServices.RootServiceProvider.Equals(d.ServiceKey) && d.KeyedImplementationFactory != BetterHostExtensions.KeyedServiceProviderFactory)))
            .Verifiable(Times.Once);
        BetterHostExtensions.AddBetterHosting(mockServices.Object);

        mockServices.Verify();
    }

    [Test]
    public void ServiceProviderFactoryTestSuccess()
    {
        IServiceProvider mockRootProvider = Mock.Of<IServiceProvider>(MockBehavior.Strict);
        Mock<IServiceProvider> mockProvider = new(MockBehavior.Strict);
        Mock<IHost> mockHost = new(MockBehavior.Strict);
        mockProvider.Setup(p => p.GetService(typeof(IHost)))
            .Returns(mockHost.Object)
            .Verifiable(Times.Once);

        mockHost.Setup(h => h.Services)
            .Returns(mockRootProvider);

        IServiceProvider rootProvider = BetterHostExtensions.ServiceProviderFactory(mockProvider.Object, Mock.Of<object>());

        mockProvider.Verify();
        Assert.That(rootProvider, Is.SameAs(mockRootProvider));
    }

    [Test]
    public void ServiceProviderFactoryTestSuccessNoHost()
    {
        Mock<IServiceProvider> mockProvider = new(MockBehavior.Strict);
        mockProvider.Setup(p => p.GetService(typeof(IHost)))
            .Returns((object?)null)
            .Verifiable(Times.Once);

        IServiceProvider rootProvider = BetterHostExtensions.ServiceProviderFactory(mockProvider.Object, Mock.Of<object>());

        mockProvider.Verify();
        Assert.That(rootProvider, Is.SameAs(mockProvider.Object));
    }

    [Test]
    public void KeyedServiceProviderFactoryTest()
    {
        IKeyedServiceProvider keyedProviderSentinal = Mock.Of<IKeyedServiceProvider>(MockBehavior.Strict);
        Mock<IKeyedServiceProvider> mockProvider = new(MockBehavior.Strict);
        mockProvider.Setup(p => p.GetRequiredKeyedService(typeof(IServiceProvider), NamedServices.RootServiceProvider))
            .Returns(keyedProviderSentinal)
            .Verifiable(Times.Once);

        IKeyedServiceProvider rootProvider = BetterHostExtensions.KeyedServiceProviderFactory(mockProvider.Object, Mock.Of<object>());

        mockProvider.Verify();
        Assert.That(rootProvider, Is.SameAs(keyedProviderSentinal));
    }
}