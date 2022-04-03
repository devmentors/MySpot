using MySpot.Core.Exceptions;

namespace MySpot.Application.Exceptions;

public class UserNotFoundException : CustomException
{
    public Guid UserId { get; private set; }

    public UserNotFoundException(Guid userId) : base($"User with ID: '{userId}' was not found.")
    {
        UserId = userId;
    }
}