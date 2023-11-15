using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Implementation.Extensions;
using DSharpPlus.BetterHosting.Services.Interfaces.Extensions;
using DSharpPlus.Lavalink;

namespace DSharpPlus.BetterHosting.Lavalink.Services.Implementations;

internal sealed class LavalinkSetup : ExtensionAdditionTemplate<LavalinkExtension>
{
    public LavalinkSetup(IEnumerable<IDiscordExtensionConfigurator<LavalinkExtension>> configurators) : base(configurators) { }

    protected override Task<IReadOnlyDictionary<int, LavalinkExtension>> UseExtension(DiscordShardedClient shard) => shard.UseLavalinkAsync();
}
