using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.BetterHosting.Lavalink.Services.Implementations;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.Lavalink;

namespace UnitTests.DSharpPlus.BetterHosting.Lavalink.Services;

[TestFixture(TestOf = typeof(LavalinkSetup))]
public class LavalinkSetupTests
{
    private MockRepository repository;

    [SetUp]
    public void SetUp() => repository = new(MockBehavior.Strict);
    [TearDown]
    public void TearDown() => repository.Verify();

    [Test]
    public void UseExtensionUsesConfig()
    {
        DiscordShardedClient shard = new(new());

        LavalinkSetup setup = new(Enumerable.Empty<IDiscordExtensionConfigurator<LavalinkExtension>>());

        setup.UseExtension(shard);
    }
}

file static class Reflection
{
    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "UseExtension")]
    public static extern Task<IReadOnlyDictionary<int, LavalinkExtension>> UseExtension(this LavalinkSetup @this, DiscordShardedClient shard);
}