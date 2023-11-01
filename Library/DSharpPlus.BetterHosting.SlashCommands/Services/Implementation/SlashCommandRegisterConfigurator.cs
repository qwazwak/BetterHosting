using System;
using System.Data;
using System.Threading.Tasks;
using DSharpPlus.SlashCommands;

namespace DSharpPlus.BetterHosting.SlashCommands.Services;

internal class SlashCommandRegisterConfigurator<TCommand> : ISlashCommandsExtensionConfigurator where TCommand : ApplicationCommandModule
{
    public ValueTask Configure(int shardID, SlashCommandsExtension slashCommands)
    {
        slashCommands.RegisterCommands<TCommand>();
        return ValueTask.CompletedTask;
    }
}

internal class SlashCommandRegisterConfigurator : ISlashCommandsExtensionConfigurator
{
    private readonly Type commandType;

    public SlashCommandRegisterConfigurator(Type commandType)
    {
        if (commandType.IsAssignableTo(typeof(ApplicationCommandModule)))
            throw new ArgumentException("Command type was not derived from ApplicationCommandModule", nameof(commandType));
        this.commandType = commandType;
    }
    public ValueTask Configure(int shardID, SlashCommandsExtension slashCommands)
    {
        slashCommands.RegisterCommands(commandType);
        return ValueTask.CompletedTask;
    }
}
