using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Implementation.ExtensionConfigurators;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.Interactivity.Services;

internal sealed class InteractivitySetup : ExtensionAdditionTemplate<InteractivityExtension>
{
    private readonly InteractivityConfiguration configuration;

    public InteractivitySetup(IOptions<InteractivityConfiguration> configuration, IEnumerable<IInteractivityConfigurator> explicitConfigurators, IEnumerable<IDiscordExtensionConfigurator<InteractivityExtension>> configurators) : base(explicitConfigurators, configurators) => this.configuration = configuration.Value;

    protected override Task<IReadOnlyDictionary<int, InteractivityExtension>> UseExtension(DiscordShardedClient shard) => shard.UseInteractivityAsync(configuration);
}