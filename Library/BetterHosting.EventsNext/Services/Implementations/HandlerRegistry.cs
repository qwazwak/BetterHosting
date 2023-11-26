using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using BetterHosting.EventsNext.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace BetterHosting.EventsNext.Services.Implementations;

/// <summary>
/// Default implementation of <see cref="IServiceCollection"/>.
/// </summary>
[DebuggerDisplay("{DebuggerToString(),nq}")]
[DebuggerTypeProxy(typeof(HandlerRegistryDebugView))]
//TODO: rename to HandlerRegistryBuilder
internal class HandlerRegistry : IHandlerRegistry
{
    private readonly List<HandlerDescriptor> descriptors = new();

    /// <inheritdoc />
    public int Count => descriptors.Count;

    /// <inheritdoc />
    public bool IsReadOnly { get; private set; }

    /// <inheritdoc />
    public HandlerDescriptor this[int index]
    {
        get => descriptors[index];
        set
        {
            CheckReadOnly();
            descriptors[index] = value;
        }
    }

    /// <inheritdoc />
    public void Clear()
    {
        CheckReadOnly();
        descriptors.Clear();
    }

    void ICollection<HandlerDescriptor>.Add(HandlerDescriptor item)
    {
        CheckReadOnly();
        descriptors.Add(item);
    }

    /// <inheritdoc />
    public void Insert(int index, HandlerDescriptor item)
    {
        CheckReadOnly();
        descriptors.Insert(index, item);
    }

    /// <inheritdoc />
    public bool Contains(HandlerDescriptor item) => descriptors.Contains(item);

    /// <inheritdoc />
    public int IndexOf(HandlerDescriptor item) => descriptors.IndexOf(item);

    /// <inheritdoc />
    public bool Remove(HandlerDescriptor item)
    {
        CheckReadOnly();
        return descriptors.Remove(item);
    }

    /// <inheritdoc />
    public void RemoveAt(int index)
    {
        CheckReadOnly();
        descriptors.RemoveAt(index);
    }

    /// <inheritdoc />
    public IEnumerator<HandlerDescriptor> GetEnumerator() => descriptors.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <inheritdoc />
    public void CopyTo(HandlerDescriptor[] array, int arrayIndex) => descriptors.CopyTo(array, arrayIndex);

    /// <summary>
    /// Makes this collection read-only.
    /// </summary>
    /// <remarks>
    /// After the collection is marked as read-only, any further attempt to modify it throws an <see cref="InvalidOperationException" />.
    /// </remarks>
    public void MakeReadOnly() => IsReadOnly = true;

    private void CheckReadOnly()
    {
        if (IsReadOnly)
            ThrowReadOnlyException();
    }

    [DoesNotReturn]
    private static void ThrowReadOnlyException() => throw new InvalidOperationException("The handler collection cannot be modified because it is read-only.");

    public override string ToString() => $"HandlerRegistry (Count = {descriptors.Count})";

    private string DebuggerToString()
    {
        string debugText = $"Count = {descriptors.Count}";
        if (IsReadOnly)
            debugText += ", IsReadOnly = true";
        return debugText;
    }

    private class HandlerRegistryDebugView(HandlerRegistry handlers)
    {
        private readonly HandlerRegistry handlers = handlers;

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public HandlerDescriptor[] Items
        {
            get
            {
                HandlerDescriptor[] items = new HandlerDescriptor[handlers.Count];
                handlers.CopyTo(items, 0);
                return items;
            }
        }
    }
}