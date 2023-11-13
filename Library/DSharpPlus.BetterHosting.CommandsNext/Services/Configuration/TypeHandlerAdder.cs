using System;
using System.Collections.Generic;
using System.Diagnostics;
using DSharpPlus.CommandsNext;

namespace DSharpPlus.BetterHosting.CommandsNext.Services.Configuration;

internal class TypeHandlerAdder : ICommandsNextConfigurator
{
    private readonly object handlerTypes;

    public TypeHandlerAdder(Type handlerType) => handlerTypes = handlerType;
    public TypeHandlerAdder(ICollection<Type> handlerTypes) => this.handlerTypes = handlerTypes;

    public void Configure(int shardID, CommandsNextExtension extension)
    {
        if (handlerTypes is Type singleType)
        {
            extension.RegisterCommands(singleType);
        }
        else
        {
            Debug.Assert(handlerTypes is ICollection<Type>);
            foreach (Type handlerType in (ICollection<Type>)handlerTypes)
                extension.RegisterCommands(handlerType);
        }
    }
}
