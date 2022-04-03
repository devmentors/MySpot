using MySpot.Core.Exceptions;

namespace MySpot.Core.ValueObjects;

public sealed record ParkingSpotId
{
    public Guid Value { get; }

    public ParkingSpotId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }

    public static ParkingSpotId Create() => new(Guid.NewGuid());

    public static implicit operator Guid(ParkingSpotId date)
        => date.Value;
    
    public static implicit operator ParkingSpotId(Guid value)
        => new(value);

    public override string ToString() => Value.ToString("N");
}