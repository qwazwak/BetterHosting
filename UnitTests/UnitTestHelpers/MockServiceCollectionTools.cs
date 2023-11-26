using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace UnitTests.BetterHosting.CommandsNext;

public static class MockServiceCollectionTools
{
    public static void AddOptions(this Mock<IServiceCollection> mockServices)
    {
        //mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddScoped(typeof(IOptions<>), typeof(UnnamedOptionsManager<>))))
        //    .Verifiable(Times.Once);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddSingleton(typeof(IOptionsMonitorCache<>), typeof(OptionsCache<>))))
            .Verifiable(Times.Once);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient(typeof(IOptionsMonitor<>), typeof(OptionsMonitor<>))))
            .Verifiable(Times.Once);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddSingleton(typeof(IOptionsMonitorCache<>), typeof(OptionsCache<>))))
            .Verifiable(Times.Once);
    }
}