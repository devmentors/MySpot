using MySpot.Core.Exceptions;

namespace MySpot.Core.ValueObjects;

public sealed record Role
{

    public static IEnumerable<string> AvailableRoles { get; } = new[] {"admin", "user"};

    public string Value { get; }

    public Role(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length > 30)
        {
            throw new InvalidRoleException(value);
        }

        if (!AvailableRoles.Contains(value))
        {
            throw new InvalidRoleException(value);
        }

        Value = value;
    }

    public static Role Admin() => new("admin");
    
    public static Role User() => new("user");

    public static implicit operator Role(string value) => new Role(value);

    public static implicit operator string(Role value) => value?.Value;

    public override string ToString() => Value;
}