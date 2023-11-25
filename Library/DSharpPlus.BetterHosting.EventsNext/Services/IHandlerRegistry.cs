﻿using System;
using System.Collections.Generic;
using DSharpPlus.BetterHosting.EventsNext.Entities;

namespace DSharpPlus.BetterHosting.EventsNext.Services;

//TODO: Rename to IHandlerRegistryBuilder
internal interface IHandlerRegistry : IList<HandlerDescriptor>
{
    /// <summary>
    /// Makes this collection read-only.
    /// </summary>
    /// <remarks>
    /// After the collection is marked as read-only, any further attempt to modify it throws an <see cref="InvalidOperationException" />.
    /// </remarks>
    public void MakeReadOnly();
}