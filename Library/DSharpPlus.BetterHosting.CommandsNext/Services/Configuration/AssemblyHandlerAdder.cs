using System;
using System.Reflection;
using DSharpPlus.CommandsNext;

namespace DSharpPlus.BetterHosting.CommandsNext.Services.Configuration;

internal class AssemblyHandlerAdder : ICommandsNextConfigurator
{
    private readonly Assembly handlerTypesAssembly;

    public AssemblyHandlerAdder(Assembly handlerTypesAssembly) => this.handlerTypesAssembly = handlerTypesAssembly;
    public static Func<AssemblyHandlerAdder> Factory(Assembly handlerTypesAssembly) => () => new(handlerTypesAssembly);

    public void Configure(int shardID, CommandsNextExtension extension) => extension.RegisterCommands(handlerTypesAssembly);
}