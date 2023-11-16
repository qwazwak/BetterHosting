﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Implementation.Extensions;
using DSharpPlus.BetterHosting.Services.Interfaces.Extensions;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.CommandsNext.Services;

/// <inheritdoc />
[ExcludeFromCodeCoverage(Justification = CoveCoverageExclusionReasons.DSharpSealed)]
public sealed class CommandsNextSetup : ExtensionAdditionTemplate<CommandsNextExtension>
{
    private readonly CommandsNextConfiguration config;

    /// <inheritdoc />
    public CommandsNextSetup(IOptions<CommandsNextConfiguration> config, IEnumerable<IDiscordExtensionConfigurator<CommandsNextExtension>> configurators) : base(configurators) => this.config = config.Value;

    /// <inheritdoc />
    protected override Task<IReadOnlyDictionary<int, CommandsNextExtension>> UseExtension(DiscordShardedClient client) => client.UseCommandsNextAsync(config);
}
