using System;
using System.Collections.Generic;
using DSharpPlus.BetterHosting.CommandsNext.Services;
using DSharpPlus.BetterHosting.CommandsNext.Services.Configuration;
using DSharpPlus.BetterHosting.SlashCommands;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTests.DSharpPlus.BetterHosting.CommandsNext;

[TestFixture(TestOf = typeof(CommandsNextRegistrationExtensions))]
[TestFixtureSource(typeof(TestData), nameof(TestData.Types))]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator", "RCS1196:Call extension method as instance method.", Justification = "Make SUT clear")]
public class CommandsNextRegistrationExtensionsTests<TCommand> where TCommand : BaseCommandModule
{
    [Test]
    public void RegisterCommand()
    {
        Mock<IServiceCollection> mockServices = new(MockBehavior.Strict);

        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient<TCommand>()))
            .Verifiable(Times.Once);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient<ICommandsNextConfigurator, TypeHandlerAdder<TCommand>>()))
            .Verifiable(Times.Once);

        CommandsNextRegistrationExtensions.RegisterCommand<TCommand>(mockServices.Object);

        mockServices.Verify();
    }
    [Test]
    public void RegisterCommandByType()
    {
        Mock<IServiceCollection> mockServices = new(MockBehavior.Strict);

        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient<TCommand>()))
            .Verifiable(Times.Once);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient<ICommandsNextConfigurator, TypeHandlerAdder<TCommand>>()))
            .Verifiable(Times.Once);

        CommandsNextRegistrationExtensions.RegisterCommand(mockServices.Object, typeof(TCommand));

        mockServices.Verify();
    }
}

file static class TestData
{
    public static IEnumerable<Type> Types()
    {
        yield return typeof(BaseCommandModule);
        yield return typeof(DerivedModule);
    }
}

file class DerivedModule : BaseCommandModule { }