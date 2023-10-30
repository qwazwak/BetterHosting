using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;

namespace DSharpPlus.BetterHosting.CommandsNext.Services.Configuration;

internal class TypeHandlerAdder : ICommandsNextConfigurator
{
    private readonly IEnumerable<Type> handlerTypes;

    public TypeHandlerAdder(IEnumerable<Type> handlerTypes) => this.handlerTypes = handlerTypes;
    public TypeHandlerAdder(params Type[] handlerTypes) => this.handlerTypes = handlerTypes;
    public static Func<TypeHandlerAdder> Factory(IEnumerable<Type> handlerType) => () => new(handlerType);
    public static Func<TypeHandlerAdder> Factory(params Type[] handlerType) => () => new(handlerType);

    public ValueTask Configure(int shardID, CommandsNextExtension extension)
    {
        foreach (Type handlerType in handlerTypes)
            extension.RegisterCommands(handlerType);
        return ValueTask.CompletedTask;
    }
}
