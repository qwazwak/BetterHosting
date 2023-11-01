using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.CommandsNext.Services;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.Services.Implementation.ExtensionConfigurators;

/// <inheritdoc />
public sealed class CommandsNextSetup : ExtensionAdditionTemplate<CommandsNextExtension>
{
    private readonly CommandsNextConfiguration config;

    /// <inheritdoc />
    public CommandsNextSetup(IOptions<CommandsNextConfiguration> config, IEnumerable<ICommandsNextConfigurator> explicitConfigurators, IEnumerable<IDiscordExtensionConfigurator<CommandsNextExtension>> configurators) : base(explicitConfigurators, configurators) => this.config = config.Value;

    /// <inheritdoc />
    protected override Task<IReadOnlyDictionary<int, CommandsNextExtension>> UseExtension(DiscordShardedClient client)
    {
        CommandsNextConfiguration config = this.config;
        return client.UseCommandsNextAsync(config);
    }
}
