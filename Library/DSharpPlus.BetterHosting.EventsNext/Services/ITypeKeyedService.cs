namespace DSharpPlus.BetterHosting.EventsNext.Services;

public interface ITypeKeyedService<TKey, TService> where TService : class
{
    public TService Service { get; }
}
