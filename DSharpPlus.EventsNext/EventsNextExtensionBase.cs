using System;

namespace DSharpPlus.EventsNext;

/// <summary>
/// This is the class which handles command registration, management, and execution.
/// </summary>
public abstract class EventsNextExtensionBase : BaseExtension
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0052:Remove unread private members", Justification = "For the future")]
    private readonly EventsNextConfigurationBase config;
    private bool IsDisposed;

    protected EventsNextExtensionBase(EventsNextConfigurationBase config) => this.config = config;

    #region DiscordClient Registration
    /// <summary>
    /// DO NOT USE THIS MANUALLY.
    /// </summary>
    /// <param name="client">DO NOT USE THIS MANUALLY.</param>
    /// <exception cref="InvalidOperationException"/>
    protected override void Setup(DiscordClient client)
    {
        if (Client != null)
            throw new InvalidOperationException("What did I tell you?");

        Client = client;
    }

    #endregion

    /// <inheritdoc cref="IDisposable.Dispose"/>
    protected virtual void Dispose(bool disposing)
    {
        if (!IsDisposed)
        {
            if (disposing)
            {
            }

            IsDisposed = true;
        }
    }

    /// <inheritdoc cref="IDisposable"/>
    public override void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
