using System.Linq;
using System.Runtime.CompilerServices;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.BetterHosting.SlashCommands.Services.Configuration;
using DSharpPlus.BetterHosting.SlashCommands.Services;
using DSharpPlus.SlashCommands;
using Microsoft.Extensions.Options;

namespace UnitTests.DSharpPlus.BetterHosting.SlashCommands.Services.Configuration;

[TestFixture(TestOf = typeof(SlashCommandsSetup))]
public class SlashCommandsSetupTests
{
    [Test]
    public void ConstructorGetsConfig()
    {
        SlashCommandsConfiguration config = new();
        Mock<IOptions<SlashCommandsConfiguration>> mockOptions = new(MockBehavior.Strict);
        mockOptions.Setup(o => o.Value).Returns(config).Verifiable(Times.Once);

        SlashCommandsSetup setup = new(mockOptions.Object, Enumerable.Empty<ISlashCommandsExtensionConfigurator>(), Enumerable.Empty<IDiscordExtensionConfigurator<SlashCommandsExtension>>());

        Assert.That(setup.GetConfiguration(), Is.SameAs(config));
        mockOptions.Verify();
    }
}

file static class Reflection
{
    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "configuration")]
    public extern static ref SlashCommandsConfiguration GetConfiguration(this SlashCommandsSetup @this);
}