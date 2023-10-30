using System;
using System.Collections.Generic;
using System.Reflection;

namespace DSharpPlus.BetterHosting.CommandsNext;

internal sealed class CommandsNextSetupItems
{
    public List<Type> Handlers { get; } = new();
    public List<Assembly> HandlerAssemblies { get; } = new();
}