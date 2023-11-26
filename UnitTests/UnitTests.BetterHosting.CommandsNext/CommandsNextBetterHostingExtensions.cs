using System;
using System.Diagnostics.CodeAnalysis;
using BetterHosting.CommandsNext;
using BetterHosting.CommandsNext.Services;
using BetterHosting.Services.Implementation.Extensions;
using BetterHosting.Services.Interfaces;
using BetterHosting.Services.Interfaces.Extensions;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace UnitTests.BetterHosting.CommandsNext;

[TestFixture(TestOf = typeof(CommandsNextBetterHostingExtensions))]
[SuppressMessage("Roslynator", "RCS1196:Call extension method as instance method.", Justification = "Make SUT clear")]
[SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Suppression is required")]
public class CommandsNextBetterHostingExtensionsTests
{
    [Test]
    public void AddCommandsNextThrowsOnNull()
    {
        ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => CommandsNextBetterHostingExtensions.AddCommandsNext(null!));

        Assert.That(ex.ParamName, Is.EqualTo("services"));
    }

    [Test]
    public void AddConfigurationThrowsOnNullServices()
    {
        ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => CommandsNextBetterHostingExtensions.AddCommandsNextConfiguration(null!, "FakePath"));

        Assert.That(ex.ParamName, Is.EqualTo("services"));
    }

    [Test]
    public void AddConfigurationThrowsOnNullString()
    {
        ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => CommandsNextBetterHostingExtensions.AddCommandsNextConfiguration(Mock.Of<IServiceCollection>(), null!));

        Assert.That(ex.ParamName, Is.EqualTo("configSectionPath"));
    }

    [Test]
    public void AddCommandsNext()
    {
        Mock<IServiceCollection> mockServices = new(MockBehavior.Strict);

        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient<IConfigureOptions<CommandsNextConfiguration>, CommandsNextOptionConfigure>()))
            .Verifiable(Times.Once);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient<IDiscordExtensionConfigurator<CommandsNextExtension>, DiscordExtensionConfiguratorAdapter<ICommandsNextConfigurator, CommandsNextExtension>>()))
            .Verifiable(Times.Once);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient<IDiscordClientConfigurator, CommandsNextSetup>()))
            .Verifiable(Times.Once);

        CommandsNextBetterHostingExtensions.AddCommandsNext(mockServices.Object);

        mockServices.Verify();
    }

    [Test]
    public void AddCommandsNextOptions()
    {
        Mock<IServiceCollection> mockServices = new(MockBehavior.Loose);

        mockServices.AddOptions();
        mockServices.Setup(s => s.Add(It.Is<ServiceDescriptor>(d =>
                d.IsKeyedService == false &&
                d.Lifetime == ServiceLifetime.Transient &&
                d.ServiceType.IsEquivalentTo(typeof(IConfigureOptions<CommandsNextConfiguration>)) &&
                d.ImplementationFactory != null)))
            .Verifiable(Times.Once);

        //IConfigureOptions<TOptions>>(new ConfigureNamedOptions<CommandsNextConfiguration>(Name, configureOptions)
        CommandsNextBetterHostingExtensions.AddCommandsNextConfiguration(mockServices.Object, "config section key for testing");

        mockServices.Verify();
    }
}
