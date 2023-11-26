using System.Diagnostics.CodeAnalysis;
using DSharpPlus.SlashCommands;

namespace BetterHosting.SlashCommands.Services;

internal class SlashCommandRegisterConfigurator<TCommand> : ISlashCommandsExtensionConfigurator where TCommand : ApplicationCommandModule
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageExclusionReasons.DSharpSealed)]
    public void Configure(int shardID, SlashCommandsExtension slashCommands) => slashCommands.RegisterCommands<TCommand>();
}