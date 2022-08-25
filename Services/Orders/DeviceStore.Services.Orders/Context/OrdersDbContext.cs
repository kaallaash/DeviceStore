using DeviceStore.Services.Orders.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeviceStore.Services.Orders.Context;

public class OrdersDbContext : DbContext
{
    public DbSet<OrderRow> Orders { get; set; } = null!;

    public OrdersDbContext(DbContextOptions<OrdersDbContext> options)
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
            .Entity<OrderRow>()
            .HasIndex(o => o.Id);
        modelBuilder
            .Entity<OrderRow>()
            .Property(o => o.UserId);
        modelBuilder
            .Entity<OrderRow>()
            .Property(o => o.DeviceId);
        modelBuilder
            .Entity<OrderRow>()
            .Property(o => o.Count);
        modelBuilder
            .Entity<OrderRow>()
            .Property(o => o.DateCreated);

        modelBuilder
            .Entity<OrderRow>()
            .HasIndex(o => new { o.Id })
            .IsUnique();
    }
}
