using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DSharpPlus.EventsNext.Tools;

/// <summary>
/// Tools for finding/filtering event handler canidates
/// </summary>
public static class HandlerExtractor
{
    /// <summary>
    /// Gets all event handlers from an assembly
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static IEnumerable<Type> GetHandlerTypes(Assembly assembly)
    {
        ArgumentNullException.ThrowIfNull(assembly);
        Type[] types = assembly.GetExportedTypes();
        return types.Where(HandlerValidation.IsHandlerCanidate);
    }
}
