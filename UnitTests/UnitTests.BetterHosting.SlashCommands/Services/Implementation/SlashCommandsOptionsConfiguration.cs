using System;
using System.Runtime.CompilerServices;
using BetterHosting.SlashCommands.Services.Implementation;
using DSharpPlus.SlashCommands;
using Microsoft.Extensions.Options;

namespace UnitTests.BetterHosting.SlashCommands.Services.Implementation;

[TestFixture(TestOf = typeof(SlashCommandsOptionsConfiguration))]
public class SlashCommandsOptionsConfigurationTest
{
    [Test]
    public void ConstructorDoesNothing()
    {
        Mock<IServiceProvider> mockProvider = new(MockBehavior.Strict);
        SlashCommandsOptionsConfiguration result = new(mockProvider.Object);

        mockProvider.Verify();
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void ConfigureSetsProvider()
    {
        IServiceProvider mockProvider = Mock.Of<IServiceProvider>(MockBehavior.Strict);
        SlashCommandsConfiguration config = new() { Services = Mock.Of<IServiceProvider>(MockBehavior.Strict) };

        SlashCommandsOptionsConfiguration result = new(mockProvider);
        result.Configure(config);

        Assert.That(config.GetServices(), Is.SameAs(mockProvider));
    }

    [Test]
    public void WillApplyToAll()
    {
        SlashCommandsOptionsConfiguration instance = new(Mock.Of<IServiceProvider>(MockBehavior.Strict));

        Assert.Multiple(() =>
        {
            Assert.That(instance, Is.AssignableTo<IConfigureOptions<SlashCommandsConfiguration>>());
            Assert.That(instance, Is.Not.AssignableTo<IConfigureNamedOptions<SlashCommandsConfiguration>>());
        });
    }
}

file static class Reflection
{
    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_Services")]
    public extern static IServiceProvider GetServices(this SlashCommandsConfiguration config);
}
