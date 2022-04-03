using MySpot.Application.Abstractions;
using MySpot.Application.Exceptions;
using MySpot.Application.Security;
using MySpot.Core.Repositories;

namespace MySpot.Application.Commands.Handlers;

internal sealed class SignInHandler : ICommandHandler<SignIn>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthenticator _authenticator;
    private readonly IPasswordManager _passwordManager;
    private readonly ITokenStorage _tokenStorage;

    public SignInHandler(IUserRepository userRepository, IAuthenticator authenticator, IPasswordManager passwordManager,
        ITokenStorage tokenStorage)
    {
        _userRepository = userRepository;
        _authenticator = authenticator;
        _passwordManager = passwordManager;
        _tokenStorage = tokenStorage;
    }
    
    public async Task HandleAsync(SignIn command)
    {
        var user = await _userRepository.GetByEmailAsync(command.Email);
        if (user is null)
        {
            throw new InvalidCredentialsException();
        }

        if (!_passwordManager.Validate(command.Password, user.Password))
        {
            throw new InvalidCredentialsException();
        }

        var jwt = _authenticator.CreateToken(user.Id, user.Role);
        _tokenStorage.Set(jwt);
    }
}