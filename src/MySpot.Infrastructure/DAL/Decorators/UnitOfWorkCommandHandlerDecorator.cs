using MySpot.Application.Abstractions;

namespace MySpot.Infrastructure.DAL.Decorators;

internal sealed class UnitOfWorkCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : class, ICommand
{
    private readonly ICommandHandler<TCommand> _commandHandler;
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkCommandHandlerDecorator(ICommandHandler<TCommand> commandHandler, IUnitOfWork unitOfWork)
    {
        _commandHandler = commandHandler;
        _unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(TCommand command)
    {
        await _unitOfWork.ExecuteAsync(() => _commandHandler.HandleAsync(command));
    }
}