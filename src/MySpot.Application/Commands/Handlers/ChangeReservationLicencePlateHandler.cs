using MySpot.Application.Abstractions;
using MySpot.Application.Exceptions;
using MySpot.Core.Entities;
using MySpot.Core.Repositories;
using MySpot.Core.ValueObjects;

namespace MySpot.Application.Commands.Handlers;

public sealed class ChangeReservationLicencePlateHandler : ICommandHandler<ChangeReservationLicencePlate>
{
    private readonly IWeeklyParkingSpotRepository _repository;

    public ChangeReservationLicencePlateHandler(IWeeklyParkingSpotRepository repository)
        => _repository = repository;

    public async Task HandleAsync(ChangeReservationLicencePlate command)
    {
        var weeklyParkingSpot = await GetWeeklyParkingSpotByReservation(command.ReservationId);
        if (weeklyParkingSpot is null)
        {
            throw new WeeklyParkingSpotNotFoundException();
        }

        var reservationId = new ReservationId(command.ReservationId);
        var reservation = weeklyParkingSpot.Reservations
            .OfType<VehicleReservation>()
            .SingleOrDefault(x => x.Id == reservationId);

        if (reservation is null)
        {
            throw new ReservationNotFoundException(command.ReservationId);
        }
    
        reservation.ChangeLicencePlate(command.LicencePlate);
        await _repository.UpdateAsync(weeklyParkingSpot);
    }
    
    private async Task<WeeklyParkingSpot> GetWeeklyParkingSpotByReservation(ReservationId id)
        => (await _repository.GetAllAsync())
            .SingleOrDefault(x => x.Reservations.Any(r => r.Id == id));
}