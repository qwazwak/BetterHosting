using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System;

namespace DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

internal static class HandlerRegistryHelper
{
    public static Guid GenerateKey(HashSet<Guid> usedKeys)
    {
        Guid key = Guid.NewGuid();
        if (usedKeys.Add(key))
            return key;

        return GetKeySlow(usedKeys);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static Guid GetKeySlow(HashSet<Guid> usedKeys)
    {
        Guid key;
        do
        {
            key = Guid.NewGuid();
        } while (!usedKeys.Add(key));
        return key;
    }
}
