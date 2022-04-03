using MySpot.Application.Abstractions;

namespace MySpot.Application.Commands;

public sealed record ReserveParkingSpotForVehicle(Guid ParkingSpotId, Guid ReservationId, Guid UserId,
    string LicencePlate, int Capacity, DateTime Date) : ICommand;