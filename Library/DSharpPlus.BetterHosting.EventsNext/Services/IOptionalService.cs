namespace DSharpPlus.BetterHosting.EventsNext.Services;

public interface IOptionalService<TService>
{
    public TService? Service { get; }
}