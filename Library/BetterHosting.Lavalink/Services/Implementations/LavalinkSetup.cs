using System.Collections.Generic;
using System.Threading.Tasks;
using BetterHosting.Services.Implementation.Extensions;
using BetterHosting.Services.Interfaces.Extensions;
using DSharpPlus;
using DSharpPlus.Lavalink;

namespace BetterHosting.Lavalink.Services.Implementations;

internal sealed class LavalinkSetup : ExtensionAdditionTemplate<LavalinkExtension>
{
    public LavalinkSetup(IEnumerable<IDiscordExtensionConfigurator<LavalinkExtension>> configurators) : base(configurators) { }

    protected override Task<IReadOnlyDictionary<int, LavalinkExtension>> UseExtension(DiscordShardedClient shard) => shard.UseLavalinkAsync();
}
