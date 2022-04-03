using MySpot.Application.Abstractions;

namespace MySpot.Application.Commands;

public record ReserveParkingSpotForCleaning(DateTime Date) : ICommand;