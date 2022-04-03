using MySpot.Application.Abstractions;

namespace MySpot.Application.Commands;

public sealed record ChangeReservationLicencePlate(Guid ReservationId, string LicencePlate) : ICommand;