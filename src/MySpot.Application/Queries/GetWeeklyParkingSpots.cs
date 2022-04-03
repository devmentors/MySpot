using MySpot.Application.Abstractions;
using MySpot.Application.DTO;

namespace MySpot.Application.Queries;

public class GetWeeklyParkingSpots : IQuery<IEnumerable<WeeklyParkingSpotDto>>
{
    public DateTime? Date { get; set; }
}