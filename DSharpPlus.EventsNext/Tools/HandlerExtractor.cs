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
#if true
        return types.Where(HandlerValidation.IsHandlerCanidate);
    }
#else
        return FilterHandlerTypesCore(types);
    }
    /// <summary>
    /// Fillter <paramref name="types"/> for only valid handlers
    /// </summary>
    /// <param name="types"></param>
    /// <returns></returns>
    public static IEnumerable<Type> FilterHandlerTypes(IEnumerable<Type> types)
    {
        ArgumentNullException.ThrowIfNull(types);
        return FilterHandlerTypesCore(types);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static IEnumerable<Type> FilterHandlerTypesCore(IEnumerable<Type> types) => types.Where(HandlerValidation.IsValidHandler);
#endif
}
