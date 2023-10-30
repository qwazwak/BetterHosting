using System;
using System.Threading.Tasks;
using DSharpPlus.SlashCommands;

namespace DSharpPlus.BetterHosting.SlashCommands.Services;

public class SlashCommandRegisterConfigurator : ISlashCommandsExtensionConfigurator
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

public class SlashCommandRegisterConfigurator<TCommand> : SlashCommandRegisterConfigurator where TCommand : ApplicationCommandModule
{
    public SlashCommandRegisterConfigurator() : base(typeof(TCommand))
    {
    }
}