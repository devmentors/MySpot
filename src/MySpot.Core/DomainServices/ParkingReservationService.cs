using MySpot.Core.Abstractions;
using MySpot.Core.Entities;
using MySpot.Core.Exceptions;
using MySpot.Core.Policies;
using MySpot.Core.ValueObjects;

namespace MySpot.Core.DomainServices;

public sealed class ParkingReservationService : IParkingReservationService
{
    private readonly IEnumerable<IReservationPolicy> _policies;
    private readonly IClock _clock;

    public ParkingReservationService(IEnumerable<IReservationPolicy> policies, IClock clock)
    {
        _policies = policies;
        _clock = clock;
    }

    public void ReserveSpotForVehicle(IEnumerable<WeeklyParkingSpot> allParkingSpots, JobTitle jobTitle,
        WeeklyParkingSpot parkingSpotToReserve,
        VehicleReservation reservation)
    {
        var parkingSpotId = parkingSpotToReserve.Id;
        var policy = _policies.SingleOrDefault(x => x.CanBeApplied(jobTitle));

        if (policy is null)
        {
            throw new NoReservationPolicyFoundException(jobTitle);
        }

        if (!policy.CanReserve(allParkingSpots, reservation.EmployeeName))
        {
            throw new CannotReserveParkingSpotException(parkingSpotId);
        }

        parkingSpotToReserve.AddReservation(reservation, new Date(_clock.Current()));
    }

    public void ReserveParkingForCleaning(IEnumerable<WeeklyParkingSpot> allParkingSpots, Date date)
    {
        foreach (var parkingSpot in allParkingSpots)
        {
            var reservationsForSameDate = parkingSpot.Reservations.Where(x => x.Date == date);
            parkingSpot.RemoveReservations(reservationsForSameDate);
            parkingSpot.AddReservation(new CleaningReservation(ReservationId.Create(), date),
                new Date(_clock.Current()));
        }
    }
}