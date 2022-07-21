using DeviceStore.Services.Warehouse.Context;
using DeviceStore.Shared.Core.Database;

namespace DeviceStore.Services.Warehouse.Migrations;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var cancellationToken = new CancellationToken();
        var service = new DatabaseMigrationService<DevicesDbContext>();

        await service
            .Migrate(
                args,
                new DesignTimeDbContextFactory(),
                cancellationToken)
            .ConfigureAwait(false);
    }
}