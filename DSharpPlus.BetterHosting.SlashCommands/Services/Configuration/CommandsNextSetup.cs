using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Implementation.ExtensionConfigurators;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.SlashCommands;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.SlashCommands.Services.Configuration;

public sealed class SlashCommandsSetup : ExtensionAdditionTemplate<SlashCommandsExtension>
{
    private readonly SlashCommandsConfiguration configuration;

    public SlashCommandsSetup(IOptions<SlashCommandsConfiguration> configuration,
        IEnumerable<ISlashCommandsExtensionConfigurator> explicitConfigurators,
        IEnumerable<IDiscordExtensionConfigurator<SlashCommandsExtension>> configurators) : base(explicitConfigurators, configurators) => this.configuration = configuration.Value;

    protected override async Task<IReadOnlyDictionary<int, SlashCommandsExtension>> UseExtension(DiscordShardedClient shard) => await shard.UseSlashCommandsAsync(configuration);
}