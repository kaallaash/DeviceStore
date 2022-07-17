using DeviceStore.Services.Users.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DeviceStore.Services.Users.Migrations;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<UsersDbContext>
{
    public UsersDbContext CreateDbContext(params string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<UsersDbContext>();
        optionsBuilder.UseNpgsql(
            config.GetConnectionString("UsersDb"),
            builder => builder.MigrationsAssembly(typeof(DesignTimeDbContextFactory)
            .Assembly.GetName().Name));

        return new UsersDbContext(optionsBuilder.Options);
    }
}
