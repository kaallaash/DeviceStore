using DeviceStore.Services.Warehouse.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DeviceStore.Services.Warehouse.Migrations;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DevicesDbContext>
{
    public DevicesDbContext CreateDbContext(params string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<DevicesDbContext>();
        optionsBuilder.UseNpgsql(
            config.GetConnectionString("WarehouseDb"),
            builder => builder.MigrationsAssembly(typeof(DesignTimeDbContextFactory)
            .Assembly.GetName().Name));

        return new DevicesDbContext(optionsBuilder.Options);
    }
}
