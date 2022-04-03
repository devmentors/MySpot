using MySpot.Core.Exceptions;

namespace MySpot.Core.ValueObjects;

public sealed record LicencePlate
{
    public string Value { get; }

    public LicencePlate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidLicencePlateException(value);
        }
        if (value.Length is < 5 or > 8)
        {
            throw new InvalidLicencePlateException(value);
        }
        
        Value = value;
    }

    public static implicit operator string(LicencePlate licencePlate)
        => licencePlate.Value;

    public static implicit operator LicencePlate(string value)
        => new(value);
}