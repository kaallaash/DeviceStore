using DeviceStore.Services.Warehouse.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeviceStore.Services.Warehouse.Context;

public class WarehouseDbContext : DbContext
{
    public DbSet<DeviceRow> Devices { get; set; } = null!;

    public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        BuildDeviceRow(modelBuilder);
    }

    private static void BuildDeviceRow(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<DeviceRow>()
            .HasIndex(d => d.Id);
        modelBuilder
            .Entity<DeviceRow>()
            .Property(d => d.Name);
        modelBuilder
            .Entity<DeviceRow>()
            .Property(d => d.Count);
        modelBuilder
            .Entity<DeviceRow>()
            .Property(d => d.Price);
        modelBuilder
            .Entity<DeviceRow>()
            .Property(d => d.DateCreated);
        modelBuilder
           .Entity<DeviceRow>()
           .Property(d => d.DateUpdated);

        modelBuilder
            .Entity<DeviceRow>()
            .HasIndex(d => new { d.Id })
            .IsUnique();
    }
}
