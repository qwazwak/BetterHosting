using System.Diagnostics.CodeAnalysis;

namespace DSharpPlus.EventsNext;
/// <summary>
/// Represents a configuration for <see cref="EventsNextExtensionBase"/>.
/// </summary>
public abstract class EventsNextConfigurationBase
{
    /// <summary>
    /// Creates a new instance of <see cref="EventsNextConfigurationBase"/>.
    /// </summary>
    private protected EventsNextConfigurationBase() { }

    /// <summary>
    /// Creates a new instance of <see cref="EventsNextConfigurationBase"/>, copying the properties of another configuration.
    /// </summary>
    /// <param name="other">Configuration the properties of which are to be copied.</param>
    [SetsRequiredMembers]
    [SuppressMessage("Roslynator", "RCS1163:Unused parameter.", Justification = "For the future")]
    [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "For the future")]
    private protected EventsNextConfigurationBase(EventsNextConfigurationBase other) { }
}
