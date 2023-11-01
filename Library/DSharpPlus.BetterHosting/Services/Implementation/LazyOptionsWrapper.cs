using System;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.Services.Implementation;

/// <summary>
/// <see cref="IOptions{TOptions}"/> wrapper that returns the options instance.
/// </summary>
/// <typeparam name="TOptions">Options type.</typeparam>
internal class LazyOptionsWrapper<TOptions> : IOptions<TOptions> where TOptions : class
{
    private readonly Lazy<TOptions> lazyValue;

    /// <summary>
    /// The options instance.
    /// </summary>
    public TOptions Value => lazyValue.Value;

    /// <summary>
    /// Initializes the wrapper with the delegate to load an options instance to return.
    /// </summary>
    /// <param name="lazyValue">The lazily initialized options to return.</param>
    public LazyOptionsWrapper(Func<TOptions> lazyValue)
    {
        ArgumentNullException.ThrowIfNull(lazyValue);
        this.lazyValue = new(lazyValue);
    }

    /// <summary>
    /// Initializes the wrapper with the delegate to load an options instance to return.
    /// </summary>
    /// <param name="lazyValue">The lazily initialized options to return.</param>
    public LazyOptionsWrapper(Lazy<TOptions> lazyValue)
    {
        ArgumentNullException.ThrowIfNull(lazyValue);
        this.lazyValue = lazyValue;
    }
}