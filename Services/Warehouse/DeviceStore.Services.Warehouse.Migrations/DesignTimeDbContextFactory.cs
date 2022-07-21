using DeviceStore.Services.Warehouse.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DeviceStore.Services.Warehouse.Migrations;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<WarehouseDbContext>
{
    public WarehouseDbContext CreateDbContext(params string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<WarehouseDbContext>();
        optionsBuilder.UseNpgsql(
            config.GetConnectionString("WarehouseDb"),
            builder => builder.MigrationsAssembly(typeof(DesignTimeDbContextFactory)
            .Assembly.GetName().Name));

        return new WarehouseDbContext(optionsBuilder.Options);
    }
}
