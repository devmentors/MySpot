using Microsoft.EntityFrameworkCore;
using MySpot.Core.Entities;

namespace MySpot.Infrastructure.DAL;

internal sealed class MySpotDbContext : DbContext
{
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<WeeklyParkingSpot> WeeklyParkingSpots { get; set; }
    public DbSet<User> Users { get; set; }

    public MySpotDbContext(DbContextOptions<MySpotDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}