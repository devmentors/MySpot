using MySpot.Core.Entities;
using MySpot.Core.ValueObjects;

namespace MySpot.Core.Policies;

internal sealed class ManagerReservationPolicy : IReservationPolicy
{
    public bool CanBeApplied(JobTitle jobTitle)
        => jobTitle == JobTitle.Manager;

    public bool CanReserve(IEnumerable<WeeklyParkingSpot> weeklyParkingSpots, EmployeeName employeeName)
    {
        var totalEmployeeReservations = weeklyParkingSpots
            .SelectMany(x => x.Reservations)
            .OfType<VehicleReservation>()
            .Count(x => x.EmployeeName == employeeName);

        return totalEmployeeReservations <= 4;
    }
}