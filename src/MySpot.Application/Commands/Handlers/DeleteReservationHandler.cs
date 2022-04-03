using MySpot.Application.Abstractions;
using MySpot.Application.Exceptions;
using MySpot.Core.Entities;
using MySpot.Core.Repositories;
using MySpot.Core.ValueObjects;

namespace MySpot.Application.Commands.Handlers;

public sealed class DeleteReservationHandler : ICommandHandler<DeleteReservation>
{
    private readonly IWeeklyParkingSpotRepository _repository;

    public DeleteReservationHandler(IWeeklyParkingSpotRepository repository)
        => _repository = repository;
    
    public async Task HandleAsync(DeleteReservation command)
    {
        var weeklyParkingSpot = await GetWeeklyParkingSpotByReservation(command.ReservationId);
        if (weeklyParkingSpot is null)
        {
            throw new WeeklyParkingSpotNotFoundException();
        }

        weeklyParkingSpot.RemoveReservation(command.ReservationId);
        await _repository.UpdateAsync(weeklyParkingSpot);
    }
    
    private async Task<WeeklyParkingSpot> GetWeeklyParkingSpotByReservation(ReservationId id)
        => (await _repository.GetAllAsync())
            .SingleOrDefault(x => x.Reservations.Any(r => r.Id == id));
}