using MySpot.Application.DTO;

namespace MySpot.Application.Security;

public interface IAuthenticator
{
    JwtDto CreateToken(Guid userId, string role);
}