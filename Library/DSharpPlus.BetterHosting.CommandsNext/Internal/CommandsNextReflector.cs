using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace DSharpPlus.BetterHosting.CommandsNext.Internal;

internal static class CommandsNextReflector
{
    public static class Utilities
    {
#if manual
        private static readonly Func<TypeInfo, bool> IsModuleCandidateTypeHandler;
        static Utilities()
        {
            Type utilType = typeof(DSharpPlus.CommandsNext.CommandsNextUtilities);
            IsModuleCandidateTypeHandler = (Func<TypeInfo, bool>)Delegate.CreateDelegate(utilType, utilType.GetMethod("IsModuleCandidateType", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, new Type[] { typeof(TypeInfo) })!);
        }

        public static bool IsModuleCandidateType(Type type) => IsModuleCandidateTypeHandler.Invoke(type.GetTypeInfo());
        public static bool IsModuleCandidateType(TypeInfo type) => IsModuleCandidateTypeHandler.Invoke(type);
#else
        public static bool IsModuleCandidateType(Type type) => IsModuleCandidateType(type.GetTypeInfo());
        [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "IsModuleCandidateType")]
        public extern static bool IsModuleCandidateType(TypeInfo type);

        public static void ThrowIfNotCanidate(Type type) => ThrowIfNotCanidate(type.GetTypeInfo());
        public static void ThrowIfNotCanidate(TypeInfo type)
        {
            if (!IsModuleCandidateType(type))
                throw new ArgumentException("Command type was not a valid CommandsNext command", nameof(type));
        }

#endif
    }
}
