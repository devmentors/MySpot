using MySpot.Core.ValueObjects;

namespace MySpot.Core.Exceptions;

public sealed class ParkingSpotCapacityExceededException : CustomException
{
    public ParkingSpotId ParkingSpotId { get; }

    public ParkingSpotCapacityExceededException(ParkingSpotId parkingSpotId) 
        : base($"Parking spot with ID: {parkingSpotId} exceeded its reservation capacity.")
    {
        ParkingSpotId = parkingSpotId;
    }
}