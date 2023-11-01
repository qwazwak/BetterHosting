using System;
using System.Diagnostics.CodeAnalysis;
using DSharpPlus.EventsNext.Entities;
using DSharpPlus.EventsNext.Tools;
using System.Reflection;
using System.Collections.Generic;
using DSharpPlus.EventsNext;
using System.Collections.ObjectModel;

namespace DSharpPlus.EventsNext.Plain;

/// <summary>
/// Represents a configuration for <see cref="EventsNextExtension"/>.
/// </summary>
public class EventsNextConfiguration : EventsNextConfigurationBase
{
    /// <summary>
    /// <para>Sets the service provider for this CommandsNext instance.</para>
    /// <para>Objects in this provider are used when instantiating command modules. This allows passing data around without resorting to static members.</para>
    /// <para>Defaults to null.</para>
    /// </summary>
    public required IServiceProvider Services { get; set; }

    public EventsNextConfiguration() { }

    [SetsRequiredMembers]
    public EventsNextConfiguration(EventsNextConfiguration other) : base(other)
    {
        Services = other.Services;
    }
}