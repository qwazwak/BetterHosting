using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Implementation.ExtensionConfigurators;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.BetterHosting.VoiceNext.Services;
using DSharpPlus.VoiceNext;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.VoiceNext.Services.Configuration;

public sealed class VoiceNextSetup : ExtensionAdditionTemplate<VoiceNextExtension>
{
    private readonly VoiceNextConfiguration configuration;

    public VoiceNextSetup(IOptions<VoiceNextConfiguration> configuration, IEnumerable<IVoiceNextConfigurator> explicitConfigurators, IEnumerable<IDiscordExtensionConfigurator<VoiceNextExtension>> configurators) : base(explicitConfigurators, configurators) => this.configuration = configuration.Value;

    protected override async Task<IReadOnlyDictionary<int, VoiceNextExtension>> UseExtension(DiscordShardedClient shard) => await shard.UseVoiceNextAsync(configuration);
}