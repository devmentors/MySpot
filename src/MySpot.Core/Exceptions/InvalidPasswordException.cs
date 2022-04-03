namespace MySpot.Core.Exceptions;

public sealed class InvalidPasswordException : CustomException
{
    public InvalidPasswordException() : base("Invalid password.")
    {
    }
}