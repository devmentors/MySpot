using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Application.Security;
using MySpot.Core.Entities;

namespace MySpot.Infrastructure.Security;

internal static class Extensions
{
    public static IServiceCollection AddSecurity(this IServiceCollection services)
    {
        services
            .AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>()
            .AddSingleton<IPasswordManager, PasswordManager>();

        return services;
    }
}