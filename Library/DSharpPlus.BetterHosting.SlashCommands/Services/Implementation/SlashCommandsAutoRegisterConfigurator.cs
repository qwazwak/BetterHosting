using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using DSharpPlus.SlashCommands;

namespace DSharpPlus.BetterHosting.SlashCommands.Services;

internal class SlashCommandsAutoRegisterConfigurator : ISlashCommandsExtensionConfigurator
{
    private readonly Assembly assembly;

    [ExcludeFromCodeCoverage(Justification = "Nothing to test")]
    public SlashCommandsAutoRegisterConfigurator(Assembly assembly) => this.assembly = assembly;

    [ExcludeFromCodeCoverage(Justification = CoveCoverageExclusionReasons.DSharpSealed)]
    public void Configure(int shardID, SlashCommandsExtension slashCommands) => slashCommands.RegisterCommands(assembly);
}
