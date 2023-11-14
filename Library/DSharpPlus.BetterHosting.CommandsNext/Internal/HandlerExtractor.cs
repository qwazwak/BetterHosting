using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DSharpPlus.BetterHosting.CommandsNext.Internal;

internal static class HandlerExtractor
{
    public static bool IsCanidate(Type type) => IsCanidate(type.GetTypeInfo());
    public static bool IsCanidate(TypeInfo typeInfo) =>  !typeInfo.IsNested && CommandsNextReflector.Utilities.IsModuleCandidateType(typeInfo);
    public static IEnumerable<Type> GetCanidates(Assembly assembly) =>  assembly.ExportedTypes.Where(IsCanidate);
}