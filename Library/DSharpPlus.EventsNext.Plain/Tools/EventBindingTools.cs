using System;
using System.Collections.Generic;
using DSharpPlus.EventsNext.Entities;
using DSharpPlus.EventsNext.Tools;

namespace DSharpPlus.EventsNext.Plain.Tools;

public static partial class EventBindingTools
{
    public static void BindAllHandlers(DiscordClient client, IEnumerable<Type> handlers)
    {
        foreach (Type handler in handlers)
            BindHandler(client, handler);
    }

    public static void BindHandler<THandler>(DiscordClient client) where THandler : class, IDiscordEventHandler
    {
        HandlerVerification.VerifyValidHandlerCanidate(typeof(THandler));
        BindHandlerCore(client, typeof(THandler));
    }

    public static void BindHandler(DiscordClient client, Type handler)
    {
        HandlerVerification.VerifyValidHandlerCanidate(handler);
        BindHandlerCore(client, handler);
    }
    public static void BindAllHandlers(DiscordShardedClient client, IEnumerable<Type> handlers)
    {
        foreach (Type handler in handlers)
            BindHandler(client, handler);
    }

    public static void BindHandler<THandler>(DiscordShardedClient client) where THandler : class, IDiscordEventHandler
    {
        HandlerVerification.VerifyValidHandlerCanidate(typeof(THandler));
        BindHandlerCore(client, typeof(THandler));
    }

    public static void BindHandler(DiscordShardedClient client, Type handler)
    {
        HandlerVerification.VerifyValidHandlerCanidate(handler);
        BindHandlerCore(client, handler);
    }
}
