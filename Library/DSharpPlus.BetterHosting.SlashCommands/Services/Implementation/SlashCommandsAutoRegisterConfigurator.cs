using System.Reflection;
using System.Threading.Tasks;
using DSharpPlus.SlashCommands;

namespace DSharpPlus.BetterHosting.SlashCommands.Services;

internal class SlashCommandsAutoRegisterConfigurator : ISlashCommandsExtensionConfigurator
{
    private readonly Assembly assembly;

    public SlashCommandsAutoRegisterConfigurator(Assembly assembly) => this.assembly = assembly;
    public ValueTask Configure(int shardID, SlashCommandsExtension slashCommands)
    {
        slashCommands.RegisterCommands(assembly);
        return ValueTask.CompletedTask;
    }
}