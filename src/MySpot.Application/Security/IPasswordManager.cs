namespace MySpot.Application.Security;

public interface IPasswordManager
{
    string Secure(string password);
    bool Validate(string password, string securedPassword);
}