using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Implementation.ExtensionConfigurators;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.Lavalink;

namespace DSharpPlus.BetterHosting.Lavalink.Services.Implementations;

internal sealed class LavalinkSetup : ExtensionAdditionTemplate<LavalinkExtension>
{
    public LavalinkSetup(IEnumerable<ILavalinkConfigurator> explicitConfigurators, IEnumerable<IDiscordExtensionConfigurator<LavalinkExtension>> configurators) : base(explicitConfigurators, configurators) { }

    protected override Task<IReadOnlyDictionary<int, LavalinkExtension>> UseExtension(DiscordShardedClient shard) => shard.UseLavalinkAsync();
}
