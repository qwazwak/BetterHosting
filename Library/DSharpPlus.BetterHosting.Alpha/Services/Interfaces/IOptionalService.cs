namespace DSharpPlus.BetterHosting.Services.Interfaces;

public interface IOptionalService<TService>
{
    public TService? Service { get; }
}