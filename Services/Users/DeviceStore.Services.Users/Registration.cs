using DeviceStore.Services.Users.Context;
using DeviceStore.Services.Users.Contract;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DeviceStore.Services.Users;

public static class Registration
{
    public static IServiceCollection AddUsers(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContextPool<UsersDbContext>(
            (s, b) =>
                b.UseNpgsql(configuration.GetConnectionString("UsersDb")));

        services.AddScoped<IUsersService, UsersService>();

        return services;
    }
}
