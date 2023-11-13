using System.Linq;
using System.Runtime.CompilerServices;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.BetterHosting.VoiceNext.Services.Configuration;
using DSharpPlus.VoiceNext;
using Microsoft.Extensions.Options;

namespace UnitTests.DSharpPlus.BetterHosting.VoiceNext.Services.Configuration;

[TestFixture(TestOf = typeof(VoiceNextSetup))]
public class VoiceNextSetupTests
{
    [Test]
    public void ConstructorGetsConfig()
    {
        VoiceNextConfiguration config = new();
        Mock<IOptions<VoiceNextConfiguration>> mockOptions = new(MockBehavior.Strict);
        mockOptions.Setup(o => o.Value).Returns(config).Verifiable(Times.Once);

        VoiceNextSetup setup = new(mockOptions.Object, Enumerable.Empty<IDiscordExtensionConfigurator<VoiceNextExtension>>());

        Assert.That(setup.GetConfiguration(), Is.SameAs(config));
        mockOptions.Verify();
    }
}

file static class Reflection
{
    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "configuration")]
    public extern static ref VoiceNextConfiguration GetConfiguration(this VoiceNextSetup @this);
}