using MySpot.Application.Abstractions;

namespace MySpot.Application.Commands;

public record SignIn(string Email, string Password) : ICommand;
