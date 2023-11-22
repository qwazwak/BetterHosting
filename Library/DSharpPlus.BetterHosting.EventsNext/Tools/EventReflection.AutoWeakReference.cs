using System;
using System.Runtime.CompilerServices;

namespace DSharpPlus.BetterHosting.EventsNext.Tools;

internal static partial class EventReflection
{
    private readonly struct AutoWeakReference<T>(Func<T> factory) where T : class?
    {
        public AutoWeakReference() : this(Activator.CreateInstance<T>) { }

        private readonly Func<T> factory = factory;
        private readonly WeakReference<T> weakReference = new(null!);

        //
        // We are exposing TryGetTarget instead of a simple getter to avoid a common problem where people write incorrect code like:
        //
        //      WeakReference ref = ...;
        //      if (ref.Target != null)
        //          DoSomething(ref.Target)
        //
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly void GetTarget(out T target)
        {
            if (weakReference.TryGetTarget(out T? cached) && cached != null)
            {
                target = cached;
            }
            else
            {
                T newValue = factory.Invoke();
                weakReference.SetTarget(newValue);
                target = newValue;
            }
        }

        public readonly void SetTarget(T target) => weakReference.SetTarget(target);
    }
}