using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.BetterHosting.Interactivity.Services;
using DSharpPlus.BetterHosting.Services.Interfaces.Extensions;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.Options;

namespace UnitTests.DSharpPlus.BetterHosting.Interactivity.Services;

public class InteractivitySetupTests
{
    private MockRepository repository;

    [SetUp]
    public void SetUp() => repository = new(MockBehavior.Strict);
    [TearDown]
    public void TearDown() => repository.Verify();

    [Test]
    public void UseExtensionUsesConfig()
    {
        InteractivityConfiguration config = new();
        DiscordShardedClient shard = new(new());
        Mock<IOptions<InteractivityConfiguration>> mockOptions = repository.Create<IOptions<InteractivityConfiguration>>();
        mockOptions.Setup(o => o.Value).Returns(config).Verifiable(Times.Once());

        InteractivitySetup setup = new(mockOptions.Object, Enumerable.Empty<IDiscordExtensionConfigurator<InteractivityExtension>>());

        setup.UseExtension(shard);
    }
}

file static class Reflection
{
    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "UseExtension")]
    public static extern Task<IReadOnlyDictionary<int, InteractivityExtension>> UseExtension(this InteractivitySetup @this, DiscordShardedClient shard);
}