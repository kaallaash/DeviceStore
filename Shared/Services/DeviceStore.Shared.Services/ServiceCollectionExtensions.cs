using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DeviceStore.Shared.Services;

public static class ServiceCollectionExtensions
{
    public static void AddServiceClient<TServiceContract, TImplementation>(
        this IServiceCollection services,
        string serviceUriName)
        where TServiceContract : class
        where TImplementation : class, TServiceContract

    {
        services.AddHttpClient<TServiceContract, TImplementation>(
            (sp, client) =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var baseAddress = configuration.GetServiceUri(serviceUriName);
                client.BaseAddress = baseAddress;
            });
    }
}