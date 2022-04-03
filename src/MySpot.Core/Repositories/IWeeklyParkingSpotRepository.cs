using MySpot.Core.Entities;
using MySpot.Core.ValueObjects;

namespace MySpot.Core.Repositories;

public interface IWeeklyParkingSpotRepository
{
    Task<IEnumerable<WeeklyParkingSpot>> GetAllAsync();
    Task<IEnumerable<WeeklyParkingSpot>> GetByWeekAsync(Week week) => throw new NotImplementedException();
    Task<WeeklyParkingSpot> GetAsync(ParkingSpotId id);
    Task AddAsync(WeeklyParkingSpot weeklyParkingSpot);
    Task UpdateAsync(WeeklyParkingSpot weeklyParkingSpot);
}