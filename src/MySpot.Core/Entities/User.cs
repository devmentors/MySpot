using MySpot.Core.ValueObjects;

namespace MySpot.Core.Entities;

public class User
{
    public UserId Id { get; private set; }
    public Email Email { get; private set; }
    public Username Username { get; private set; }
    public Password Password { get; private set; }
    public FullName FullName { get; private set; }
    public Role Role { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public User(UserId id, Email email, Username username, Password password, FullName fullName, Role role,
        DateTime createdAt)
    {
        Id = id;
        Email = email;
        Username = username;
        Password = password;
        FullName = fullName;
        Role = role;
        CreatedAt = createdAt;
    }
}