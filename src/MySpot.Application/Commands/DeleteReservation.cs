using MySpot.Application.Abstractions;

namespace MySpot.Application.Commands;

public sealed record DeleteReservation(Guid ReservationId) : ICommand;