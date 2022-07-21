using DeviceStore.Services.Warehouse.Context;
using DeviceStore.Services.Warehouse.Contract;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DeviceStore.Services.Warehouse;

public static class Registration
{
    public static IServiceCollection AddWarehouse(
       this IServiceCollection services,
       IConfiguration configuration)
    {
        services.AddDbContextPool<WarehouseDbContext>(
            (s, b) =>
                b.UseNpgsql(configuration.GetConnectionString("WarehouseDb")));

        services.AddScoped<IDevicesService, DevicesService>();

        return services;
    }
}
