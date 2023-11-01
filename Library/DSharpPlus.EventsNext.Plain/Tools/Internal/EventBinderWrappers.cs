using System;
using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.EventArgs;
using System.Diagnostics;
using DSharpPlus.EventsNext.Entities;
using DSharpPlus.AsyncEvents;
using System.IO;
using System.Threading.Tasks;
using DSharpPlus.EventsNext.Tools.Internal;

namespace DSharpPlus.EventsNext.Plain.Tools.Internal;
internal static partial class EventBinderWrappers
{
#if WrapCore
    public static AsyncEventHandler<DiscordClient, TArgs> WrapCore<THandler, TInterface, TArgs>(Func<TInterface, DiscordClient, TArgs, Task> invokeFactory)
        where THandler : class, TInterface
        where TInterface : IDiscordEventHandler<TArgs>
        where TArgs : DiscordEventArgs
        => WrapCore(typeof(THandler), invokeFactory);

    public static AsyncEventHandler<DiscordClient, TArgs> WrapCore<TInterface, TArgs>(Type handler, Func<TInterface, DiscordClient, TArgs, Task> invokeFactory)
        where TInterface : IDiscordEventHandler<TArgs>
        where TArgs : DiscordEventArgs
    {
        Debug.Assert(handler.IsAssignableTo(typeof(TInterface)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            TInterface instance = (TInterface)scope.ServiceProvider.GetRequiredService(handler);
            await invokeFactory(instance, client, args);
        };
    }
    private static AsyncEventHandler<DiscordClient, TArgs> WrapCore<THandler, TInterface, TArgs>(Func<TInterface, DiscordClient, TArgs, Task> invokeFactory)
        where THandler : class, TInterface
        where TInterface : IDiscordEventHandler<TArgs>
        where TArgs : DiscordEventArgs
    {
        return async (client, args) =>
        {
            EventsNextMinimalExtension ctx = client.GetExtension<EventsNextMinimalExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            TInterface instance = scope.ServiceProvider.GetRequiredService<THandler>();
            await AutoCaller.CallEventHandler<TInterface, TArgs>(instance, client, args);
        };
    }

    private static AsyncEventHandler<DiscordClient, TArgs> WrapCore<TInterface, TArgs>(Type handler)
        where TInterface : IDiscordEventHandler<TArgs>
        where TArgs : DiscordEventArgs
    {
        Debug.Assert(handler.IsAssignableTo(typeof(TInterface)));

        return async (client, args) =>
        {
            EventsNextMinimalExtension ctx = client.GetExtension<EventsNextMinimalExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            TInterface instance = (TInterface)scope.ServiceProvider.GetRequiredService(handler);
            await AutoCaller.CallEventHandler<TInterface, TArgs>(instance, client, args);
        };
    }
#endif
}