using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace UnitTestHelpers;

public static partial class ItMore
{
    public static partial class ServiceDescriptorFrom
    {
        public static class Options
        {
            public static ServiceDescriptor AddSingletonOption<TOption>(TOption Instance) where TOption : class => It.Is<ServiceDescriptor>(d =>
                                                                                                                   d.Lifetime == ServiceLifetime.Singleton &&
                                                                                                                   d.ServiceType == typeof(IOptions<TOption>) &&
                                                                                                                   d.ImplementationInstance is IOptions<TOption> &&
                                                                                                                   ((IOptions<TOption>)d.ImplementationInstance).Value == Instance &&
                                                                                                                   d.ServiceKey == null);
        }
    }
}
