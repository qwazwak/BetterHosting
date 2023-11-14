using System;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;

namespace DSharpPlus.BetterHosting.CommandsNext.Services;

[TestFixture(TestOf = typeof(CommandsNextOptionConfigure))]
public class CommandsNextOptionConfigureTest
{
    Mock<IServiceProvider> mockProvider = default!;

    [SetUp]
    public void SetUp() => mockProvider = new(MockBehavior.Strict);

    [Test]
    public void ConstructorDoesNothing()
    {
        CommandsNextOptionConfigure result = new(mockProvider.Object);

        mockProvider.Verify();
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void ConfigureSetsProvider()
    {
        CommandsNextConfiguration config = new() { Services = Mock.Of<IServiceProvider>(MockBehavior.Strict) };

        CommandsNextOptionConfigure result = new(mockProvider.Object);
        result.Configure(config);

        Assert.That(config.GetServices(), Is.SameAs(mockProvider.Object));
        mockProvider.Verify();
    }

    [Test]
    public void WillApplyToAll()
    {
        CommandsNextOptionConfigure instance = new(mockProvider.Object);

        Assert.Multiple(() =>
        {
            Assert.That(instance, Is.AssignableTo<IConfigureOptions<CommandsNextConfiguration>>());
            Assert.That(instance, Is.Not.AssignableTo<IConfigureNamedOptions<CommandsNextConfiguration>>());
        });
    }
}

file static class Reflection
{
    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_Services")]
    public extern static IServiceProvider GetServices(this CommandsNextConfiguration config);
}
