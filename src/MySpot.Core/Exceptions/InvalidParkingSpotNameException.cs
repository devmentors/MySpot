namespace MySpot.Core.Exceptions;

public class InvalidParkingSpotNameException : CustomException
{
    public InvalidParkingSpotNameException() : base("Parking spot name is invalid.")
    {
    }
}