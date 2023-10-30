#if false
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace QLib;

public class AutoWeakReference<T> where T : class?
{
    private static T CreateViaDefaultConstructor<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] T>()
    {
        try
        {
            return Activator.CreateInstance<T>();
        }
        catch (MissingMethodException)
        {
            throw new MissingMemberException("The lazily-initialized type does not have a public, parameterless constructor.");
        }
    }

    private const bool TrackResurrectionDefault = false;
    private readonly WeakReference<T> weakReference = new(null!);
    private readonly Func<T> factory;

    public AutoWeakReference() : this(TrackResurrectionDefault) { }
    public AutoWeakReference(bool trackResurrection) : this(null!, CreateViaDefaultConstructor<T>, trackResurrection) { }

    public AutoWeakReference(Func<T> factory) : this(factory, TrackResurrectionDefault) { }
    public AutoWeakReference(Func<T> factory, bool trackResurrection) : this(null!, factory, trackResurrection) => ArgumentNullException.ThrowIfNull(factory);

    public AutoWeakReference(T target) : this(target, TrackResurrectionDefault) { }
    public AutoWeakReference(T target, bool trackResurrection)
        : this(target, CreateViaDefaultConstructor<T>, trackResurrection)
    {
        ArgumentNullException.ThrowIfNull(target);
    }

    public AutoWeakReference(T target, Func<T> factory) : this(target, factory, TrackResurrectionDefault) { }
    public AutoWeakReference(T target, Func<T> factory, bool trackResurrection)
    {
        ArgumentNullException.ThrowIfNull(factory);
        this.factory = factory;
        weakReference = new WeakReference<T>(target, trackResurrection);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void GetTarget([NotNull] out T target) => target = GetTarget()!;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T GetTarget()
    {
        if (TryGetTarget(out T? target))
            return target;

        T newValue = factory() ?? throw new ArgumentNullException(null, "Factory returned null");
        weakReference.SetTarget(newValue);
        return newValue;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryGetTarget([MaybeNullWhen(false), NotNullWhen(true)] out T target) => weakReference.TryGetTarget(out target);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetTarget(T target) => weakReference.SetTarget(target);
}
#endif