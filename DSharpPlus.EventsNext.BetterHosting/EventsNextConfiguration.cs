using System.Diagnostics.CodeAnalysis;

namespace DSharpPlus.EventsNext.BetterHosting;

/// <inheritdoc/>
public class EventsNextConfiguration : EventsNextConfigurationBase
{
    /// <inheritdoc/>
    public EventsNextConfiguration() { }

    /// <inheritdoc/>
    [SetsRequiredMembers]
    public EventsNextConfiguration(EventsNextConfiguration other) : base(other) { }
}
