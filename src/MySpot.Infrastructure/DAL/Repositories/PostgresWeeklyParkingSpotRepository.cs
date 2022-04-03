using Microsoft.EntityFrameworkCore;
using MySpot.Core.Entities;
using MySpot.Core.Repositories;
using MySpot.Core.ValueObjects;

namespace MySpot.Infrastructure.DAL.Repositories;

internal sealed class PostgresWeeklyParkingSpotRepository : IWeeklyParkingSpotRepository
{
    private readonly MySpotDbContext _dbContext;
    private readonly DbSet<WeeklyParkingSpot> _weeklyParkingSpots;

    public PostgresWeeklyParkingSpotRepository(MySpotDbContext dbContext)
    {
        _dbContext = dbContext;
        _weeklyParkingSpots = _dbContext.WeeklyParkingSpots;
    }

    public async Task<IEnumerable<WeeklyParkingSpot>> GetAllAsync()
        => await _weeklyParkingSpots
            .Include(x => x.Reservations)
            .ToListAsync();
    
    public async Task<IEnumerable<WeeklyParkingSpot>> GetByWeekAsync(Week week)
        => await _weeklyParkingSpots
            .Include(x => x.Reservations)
            .Where(x => x.Week == week)
            .ToListAsync();

    public async Task<WeeklyParkingSpot> GetAsync(ParkingSpotId id)
        => await _weeklyParkingSpots
            .Include(x => x.Reservations)
            .SingleOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(WeeklyParkingSpot weeklyParkingSpot)
    {
        await _weeklyParkingSpots.AddAsync(weeklyParkingSpot);
    }

    public Task UpdateAsync(WeeklyParkingSpot weeklyParkingSpot)
    {
        _weeklyParkingSpots.Update(weeklyParkingSpot);
        return Task.CompletedTask;
    }
}