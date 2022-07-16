using DeviceStore.Services.Users.Context.Entities;

using Microsoft.EntityFrameworkCore;

namespace DeviceStore.Services.Users.Context;

public class UsersDbContext : DbContext
{
    public DbSet<UserRow> Users { get; set; } = null!;

    public UsersDbContext(DbContextOptions<UsersDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        BuildUserRow(modelBuilder);
    }

    private static void BuildUserRow(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<UserRow>()
            .HasIndex(s => s.Id);
        modelBuilder
            .Entity<UserRow>()
            .Property(s => s.FirstName);
        modelBuilder
            .Entity<UserRow>()
            .Property(s => s.LastName);
        modelBuilder
            .Entity<UserRow>()
            .Property(s => s.Phone);
        modelBuilder
            .Entity<UserRow>()
            .Property(s => s.Email);
        modelBuilder
            .Entity<UserRow>()
            .Property(s => s.Login);
        modelBuilder
            .Entity<UserRow>()
            .Property(s => s.Password);
        modelBuilder
            .Entity<UserRow>()
            .Property(s => s.DateCreated);
        modelBuilder
           .Entity<UserRow>()
           .Property(s => s.DateUpdated);

        modelBuilder
            .Entity<UserRow>()
            .HasIndex(s => new { s.Id, s.Phone })
            .IsUnique();
    }
}
