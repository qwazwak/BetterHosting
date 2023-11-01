namespace DSharpPlus.EventsNext.BetterHosting;

/// <inheritdoc/>
public class EventsNextExtension : EventsNextExtensionBase
{
    /// <inheritdoc/>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0052:Remove unread private members", Justification = "For the future")]
    private readonly EventsNextConfiguration config;

    internal EventsNextExtension(EventsNextConfiguration config) : base(config) => this.config = config;
}
