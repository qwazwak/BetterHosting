using System;
using DSharpPlus.BetterHosting.CommandsNext;
using DSharpPlus.BetterHosting.CommandsNext.Services;
using DSharpPlus.BetterHosting.Services.Implementation.Extensions;
using DSharpPlus.BetterHosting.Services.Interfaces;
using DSharpPlus.BetterHosting.Services.Interfaces.Extensions;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace UnitTests.DSharpPlus.BetterHosting.CommandsNext;

[TestFixture(TestOf = typeof(CommandsNextBetterHostingExtensions))]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator", "RCS1196:Call extension method as instance method.", Justification = "Make SUT clear")]
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
}