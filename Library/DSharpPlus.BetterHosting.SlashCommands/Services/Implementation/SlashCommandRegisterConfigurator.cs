using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using DSharpPlus.SlashCommands;

namespace DSharpPlus.BetterHosting.SlashCommands.Services;

internal class SlashCommandRegisterConfigurator<TCommand> : ISlashCommandsExtensionConfigurator where TCommand : ApplicationCommandModule
{
    [ExcludeFromCodeCoverage(Justification = CoveCoverageExclusionReasons.DSharpSealed)]
    public ValueTask Configure(int shardID, SlashCommandsExtension slashCommands)
    {
        slashCommands.RegisterCommands<TCommand>();
        return ValueTask.CompletedTask;
    }
}