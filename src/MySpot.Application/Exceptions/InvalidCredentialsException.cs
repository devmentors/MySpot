using MySpot.Core.Exceptions;

namespace MySpot.Application.Exceptions;

public class InvalidCredentialsException : CustomException
{
    public InvalidCredentialsException() : base("Invalid credentials.")
    {
    }
}