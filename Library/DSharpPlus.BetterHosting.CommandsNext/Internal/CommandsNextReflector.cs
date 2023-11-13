using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace DSharpPlus.BetterHosting.CommandsNext.Internal;

internal static class CommandsNextReflector
{
    public static class Utilities
    {
        public static bool IsModuleCandidateType(Type type) => IsModuleCandidateType(type.GetTypeInfo());
        [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "IsModuleCandidateType")]
        public extern static bool IsModuleCandidateType(TypeInfo type);

        public static void ThrowIfNotCanidate(Type type) => ThrowIfNotCanidate(type.GetTypeInfo());
        public static void ThrowIfNotCanidate(TypeInfo type)
        {
            if (!IsModuleCandidateType(type))
                ThrowNotCanidate(type);
        }
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void ThrowNotCanidate(TypeInfo type) => throw new ArgumentException("Command type was not a valid CommandsNext command", nameof(type));
    }
}
