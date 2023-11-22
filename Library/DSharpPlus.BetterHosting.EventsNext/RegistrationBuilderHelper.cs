using Microsoft.Extensions.DependencyInjection;
using System;

namespace DSharpPlus.BetterHosting.EventsNext;

internal static class RegistrationBuilderHelper
{
    public static bool CanAddService(IServiceCollection services, Type serviceType, object? serviceKey)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(serviceType);

        int count = services.Count;
        for (int i = 0; i < count; i++)
        {
            ServiceDescriptor service = services[i];
            if (service.ServiceType == serviceType && service.ServiceKey == serviceKey)
            {
                // Already added
                return false;
            }
        }

        return true;
    }
}