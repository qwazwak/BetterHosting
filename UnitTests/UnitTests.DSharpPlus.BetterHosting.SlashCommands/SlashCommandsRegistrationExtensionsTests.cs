using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System;
using DSharpPlus.SlashCommands;
using DSharpPlus.BetterHosting.SlashCommands.Services;
using System.Reflection;
using DSharpPlus.BetterHosting.SlashCommands;

namespace UnitTests.DSharpPlus.BetterHosting.SlashCommands;

[TestFixture(TestOf = typeof(SlashCommandsRegistrationExtensions))]
[TestFixtureSource(typeof(SlashCommandModuleTestData), nameof(SlashCommandModuleTestData.ApplicationCommandModuleType))]
[TestFixtureSource(typeof(SlashCommandModuleTestData), nameof(SlashCommandModuleTestData.DerivedTypes))]
[SuppressMessage("Roslynator", "RCS1196:Call extension method as instance method.", Justification = "Make SUT clear")]
public class SlashCommandsRegistrationExtensionsTests<TCommand> where TCommand : ApplicationCommandModule
{
    [Test]
    public void RegisterWithNull() => Assert.Throws<ArgumentNullException>(() => SlashCommandsRegistrationExtensions.RegisterSlashCommand<TCommand>(null!));

    [Test]
    public void AddsRegister()
    {
        Mock<IServiceCollection> mockServices = new(MockBehavior.Strict);

        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient<ISlashCommandsExtensionConfigurator, SlashCommandRegisterConfigurator<TCommand>>())).Verifiable(Times.Once);

        SlashCommandsRegistrationExtensions.RegisterSlashCommand<TCommand>(mockServices.Object);

        mockServices.Verify();
    }

    [Test]
    public void ReturnsSame_RegisterSingle()
    {
        IServiceCollection mockServices = Mock.Of<IServiceCollection>(MockBehavior.Loose);

        IServiceCollection result = SlashCommandsRegistrationExtensions.RegisterSlashCommand<TCommand>(mockServices);

        Assert.That(result, Is.SameAs(mockServices));
    }

    [Test]
    public void ReturnsSame_RegisterAssembly()
    {
        IServiceCollection mockServices = Mock.Of<IServiceCollection>(MockBehavior.Loose);
        Assembly assembly = typeof(string).Assembly;

        IServiceCollection result = SlashCommandsRegistrationExtensions.RegisterSlashCommands(mockServices, assembly);

        Assert.That(result, Is.SameAs(mockServices));
    }

    [Test]
    public void RegisterByAssembly()
    {
        Mock<IServiceCollection> mockServices = new(MockBehavior.Loose);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.Factory.AddTransient<ISlashCommandsExtensionConfigurator, SlashCommandsAutoRegisterConfigurator>()));
        Assembly assembly = typeof(string).Assembly;

        IServiceCollection result = SlashCommandsRegistrationExtensions.RegisterSlashCommands(mockServices.Object, assembly);
        mockServices.Verify();
    }

    [Test]
    public void RegisterByType()
    {
        Mock<IServiceCollection> mockServices = new(MockBehavior.Loose);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.Factory.AddTransient<ISlashCommandsExtensionConfigurator, SlashCommandRegisterConfigurator<TCommand>>()));

        IServiceCollection result = SlashCommandsRegistrationExtensions.RegisterSlashCommand<TCommand>(mockServices.Object);
        mockServices.Verify();
    }
}
