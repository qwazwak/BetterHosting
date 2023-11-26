using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using BetterHosting.Services.Implementation.Extensions;
using BetterHosting.Services.Interfaces.Extensions;
using DSharpPlus;
using DSharpPlus.SlashCommands;
using Microsoft.Extensions.Options;

namespace BetterHosting.SlashCommands.Services.Configuration;

internal sealed class SlashCommandsSetup : ExtensionAdditionTemplate<SlashCommandsExtension>
{
    private readonly SlashCommandsConfiguration configuration;

    public SlashCommandsSetup(IOptions<SlashCommandsConfiguration> configuration, IEnumerable<IDiscordExtensionConfigurator<SlashCommandsExtension>> configurators) : base(configurators) => this.configuration = configuration.Value;

    [ExcludeFromCodeCoverage(Justification = CoveCoverageExclusionReasons.DSharpSealed)]
    protected override Task<IReadOnlyDictionary<int, SlashCommandsExtension>> UseExtension(DiscordShardedClient shard) => shard.UseSlashCommandsAsync(configuration);
}