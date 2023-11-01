using System;
using System.Reflection;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;

namespace DSharpPlus.BetterHosting.CommandsNext.Services.Configuration;

internal class HandlerAdder : ICommandsNextConfigurator
{
    private readonly CommandsNextSetupItems items;

    public HandlerAdder(CommandsNextSetupItems items) => this.items = items;

    public ValueTask Configure(int shardID, CommandsNextExtension extension)
    {
        foreach (Type handler in items.Handlers)
            extension.RegisterCommands(handler);

        foreach (Assembly handlerAssembly in items.HandlerAssemblies)
            extension.RegisterCommands(handlerAssembly);

        return ValueTask.CompletedTask;
    }
}