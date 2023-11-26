using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace BetterHosting.CommandsNext.Internal;

internal static class HandlerExtractor
{
    private static class Reflection
    {
        public static readonly Func<TypeInfo, bool> IsModuleCandidateTypeHandler;
        static Reflection()
        {
            Type utilType = typeof(DSharpPlus.CommandsNext.CommandsNextUtilities);
            MethodInfo method = utilType.GetMethod("IsModuleCandidateType", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, new Type[] { typeof(TypeInfo) })!;
            IsModuleCandidateTypeHandler = method.CreateDelegate<Func<TypeInfo, bool>>();
        }
    }

    public static bool IsModuleCandidateType(Type type) => Reflection.IsModuleCandidateTypeHandler.Invoke(type.GetTypeInfo());
    public static bool IsModuleCandidateType(TypeInfo type) => Reflection.IsModuleCandidateTypeHandler.Invoke(type);

    public static void ThrowIfNotCanidate(Type type) => ThrowIfNotCanidate(type.GetTypeInfo());
    public static void ThrowIfNotCanidate(TypeInfo type)
    {
        if (!IsModuleCandidateType(type))
            ThrowNotCanidate(type);
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void ThrowNotCanidate(TypeInfo type) => throw new ArgumentException("Command type was not a valid CommandsNext command", nameof(type));

    public static IEnumerable<Type> GetCanidates(Assembly assembly) =>  assembly.ExportedTypes.Where(IsModuleCandidateType);
}