using DeviceStore.Services.Orders.Context;
using DeviceStore.Services.Orders.Contract;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DeviceStore.Services.Orders;

public static class Registration
{
    public static IServiceCollection AddOrders(
       this IServiceCollection services,
       IConfiguration configuration)
    {
        services.AddDbContextPool<OrdersDbContext>(
            (s, b) =>
                b.UseNpgsql(configuration.GetConnectionString("OrdersDb")));

        services.AddScoped<IOrdersService, OrdersService>();

        return services;
    }
}
