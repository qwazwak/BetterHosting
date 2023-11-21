using System.Linq;
using DSharpPlus.BetterHosting.EventsNext.Services;

namespace UnitTests.DSharpPlus.BetterHosting.EventsNext;

public static partial class HandlerTypesTestData
{
    public static class Mocks
    {
        public static readonly IDiscordEventHandler[] SpecificHandlerInterfaces = HandlerTypesTestData.SpecificHandlerInterfaces.Select(MockTools.CreateMockObject).Cast<IDiscordEventHandler>().ToArray();
    }
}
