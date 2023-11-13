using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Implementation.ExtensionConfigurators;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.VoiceNext;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.VoiceNext.Services.Configuration;

/// <inheritdoc/>
public sealed class VoiceNextSetup : ExtensionAdditionTemplate<VoiceNextExtension>
{
    private readonly VoiceNextConfiguration configuration;

    /// <inheritdoc/>
    public VoiceNextSetup(IOptions<VoiceNextConfiguration> configuration, IEnumerable<IVoiceNextConfigurator> explicitConfigurators, IEnumerable<IDiscordExtensionConfigurator<VoiceNextExtension>> configurators) : base(explicitConfigurators, configurators) => this.configuration = configuration.Value;

    /// <inheritdoc/>
    [ExcludeFromCodeCoverage(Justification = CoveCoverageExclusionReasons.DSharpSealed)]
    protected override Task<IReadOnlyDictionary<int, VoiceNextExtension>> UseExtension(DiscordShardedClient shard) => shard.UseVoiceNextAsync(configuration);
}