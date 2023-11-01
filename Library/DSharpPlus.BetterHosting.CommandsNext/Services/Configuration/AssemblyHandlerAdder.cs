using System;
using System.Reflection;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;

namespace DSharpPlus.BetterHosting.CommandsNext.Services.Configuration;

internal class AssemblyHandlerAdder : ICommandsNextConfigurator
{
    private readonly Assembly handlerTypesAssembly;

    public AssemblyHandlerAdder(Assembly handlerTypesAssembly) => this.handlerTypesAssembly = handlerTypesAssembly;
    public static Func<AssemblyHandlerAdder> Factory(Assembly handlerTypesAssembly) => () => new(handlerTypesAssembly);

    public ValueTask Configure(int shardID, CommandsNextExtension extension)
    {
        extension.RegisterCommands(handlerTypesAssembly);
        return ValueTask.CompletedTask;
    }
}