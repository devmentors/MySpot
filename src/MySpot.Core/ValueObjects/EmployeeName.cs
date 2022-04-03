using MySpot.Core.Exceptions;

namespace MySpot.Core.ValueObjects;

public sealed record EmployeeName(string Value)
{
    public string Value { get; } = Value ?? throw new InvalidEmployeeNameException();

    public static implicit operator string(EmployeeName name)
        => name.Value;
    
    public static implicit operator EmployeeName(string value)
        => new(value);
}