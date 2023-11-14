using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.Services.Implementation.ExtensionConfigurators;

/// <inheritdoc />
public sealed class CommandsNextSetup : ExtensionAdditionTemplate<CommandsNextExtension>
{
    private readonly CommandsNextConfiguration config;

    /// <inheritdoc />
    public CommandsNextSetup(IOptions<CommandsNextConfiguration> config, IEnumerable<IDiscordExtensionConfigurator<CommandsNextExtension>> configurators) : base(configurators) => this.config = config.Value;

    /// <inheritdoc />
    [ExcludeFromCodeCoverage(Justification = CoveCoverageExclusionReasons.DSharpSealed)]
    protected override Task<IReadOnlyDictionary<int, CommandsNextExtension>> UseExtension(DiscordShardedClient client) => client.UseCommandsNextAsync(config);
}
