using DeviceStore.Services.Users.Context;
using DeviceStore.Shared.Core.Database;

namespace DeviceStore.Services.Users.Migrations;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var cancellationToken = new CancellationToken();
        var service = new DatabaseMigrationService<UsersDbContext>();

        await service
            .Migrate(
                args,
                new DesignTimeDbContextFactory(),
                cancellationToken)
            .ConfigureAwait(false);
    }
}