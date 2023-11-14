using System.Diagnostics.CodeAnalysis;
using DSharpPlus.CommandsNext;

namespace DSharpPlus.BetterHosting.CommandsNext.Services;

internal class TypeHandlerAdder<T> : ICommandsNextConfigurator where T : BaseCommandModule
{
    [ExcludeFromCodeCoverage(Justification = CoveCoverageExclusionReasons.DSharpSealed)]
    public void Configure(int shardID, CommandsNextExtension extension) => extension.RegisterCommands<T>();
}