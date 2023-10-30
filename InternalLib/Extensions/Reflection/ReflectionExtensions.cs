using System;
using System.Linq;

namespace QLib.Extensions.Reflection;

public static class ReflectionExtensions
{
    public static bool HasInterface<TInterface>(this Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

        return type.GetInterface(typeof(TInterface).Name) != null || typeof(TInterface).IsAssignableFrom(type);
    }

    public static bool HasInterface(this Type type, Type interfaceType)
    {
        ArgumentNullException.ThrowIfNull(type);
        ArgumentNullException.ThrowIfNull(interfaceType);

        return type.GetInterface(interfaceType.Name) != null || interfaceType.IsAssignableFrom(type);
    }
}
