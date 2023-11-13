using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Implementation.ExtensionConfigurators;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.SlashCommands;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.SlashCommands.Services.Configuration;

internal sealed class SlashCommandsSetup : ExtensionAdditionTemplate<SlashCommandsExtension>
{
    private readonly SlashCommandsConfiguration configuration;

    public SlashCommandsSetup(IOptions<SlashCommandsConfiguration> configuration,
        IEnumerable<ISlashCommandsExtensionConfigurator> explicitConfigurators,
        IEnumerable<IDiscordExtensionConfigurator<SlashCommandsExtension>> configurators) : base(explicitConfigurators, configurators) => this.configuration = configuration.Value;

    [ExcludeFromCodeCoverage(Justification = CoveCoverageExclusionReasons.DSharpSealed)]
    protected override Task<IReadOnlyDictionary<int, SlashCommandsExtension>> UseExtension(DiscordShardedClient shard) => shard.UseSlashCommandsAsync(configuration);
}