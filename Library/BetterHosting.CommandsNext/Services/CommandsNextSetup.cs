using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using BetterHosting.Services.Implementation.Extensions;
using BetterHosting.Services.Interfaces.Extensions;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.Options;

namespace BetterHosting.CommandsNext.Services;

/// <inheritdoc />
[ExcludeFromCodeCoverage(Justification = CodeCoverageExclusionReasons.DSharpSealed)]
public sealed class CommandsNextSetup : ExtensionAdditionTemplate<CommandsNextExtension>
{
    private readonly CommandsNextConfiguration config;

    /// <inheritdoc />
    public CommandsNextSetup(IOptions<CommandsNextConfiguration> config, IEnumerable<IDiscordExtensionConfigurator<CommandsNextExtension>> configurators) : base(configurators) => this.config = config.Value;

    /// <inheritdoc />
    protected override Task<IReadOnlyDictionary<int, CommandsNextExtension>> UseExtension(DiscordShardedClient client) => client.UseCommandsNextAsync(config);
}
