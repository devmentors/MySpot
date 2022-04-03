using Microsoft.Extensions.DependencyInjection;
using MySpot.Application.Abstractions;
using MySpot.Infrastructure.Logging.Decorators;

namespace MySpot.Infrastructure.Logging;

internal static class Extensions
{
    public static IServiceCollection AddCustomLogging(this IServiceCollection services)
    {
        services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));

        return services;
    }
}