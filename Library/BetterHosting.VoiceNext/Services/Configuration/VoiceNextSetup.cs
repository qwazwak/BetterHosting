using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using BetterHosting.Services.Implementation.Extensions;
using BetterHosting.Services.Interfaces.Extensions;
using DSharpPlus;
using DSharpPlus.VoiceNext;
using Microsoft.Extensions.Options;

namespace BetterHosting.VoiceNext.Services.Configuration;

/// <inheritdoc/>
public sealed class VoiceNextSetup : ExtensionAdditionTemplate<VoiceNextExtension>
{
    private readonly VoiceNextConfiguration configuration;

    /// <inheritdoc/>
    public VoiceNextSetup(IOptions<VoiceNextConfiguration> configuration, IEnumerable<IDiscordExtensionConfigurator<VoiceNextExtension>> configurators) : base(configurators) => this.configuration = configuration.Value;

    /// <inheritdoc/>
    [ExcludeFromCodeCoverage(Justification = CodeCoverageExclusionReasons.DSharpSealed)]
    protected override Task<IReadOnlyDictionary<int, VoiceNextExtension>> UseExtension(DiscordShardedClient shard) => shard.UseVoiceNextAsync(configuration);
}