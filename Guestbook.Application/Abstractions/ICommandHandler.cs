using Guestbook.Domain.Abstractions;

namespace Guestbook.Application.Abstractions;
public interface ICommandHandler<TCommand>
  where TCommand : ICommand
{
  Task<Result> Handle(TCommand command, CancellationToken cancellationToken = default);
}

public interface ICommandHandler<TCommand, TResponse>
  where TCommand : ICommand<TResponse>
{
  Task<Result<TResponse>> Handle(TCommand command, CancellationToken cancellationToken = default);
}
