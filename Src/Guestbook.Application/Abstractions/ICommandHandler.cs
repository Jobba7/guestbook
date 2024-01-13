using Guestbook.Domain.Abstractions;
using MediatR;

namespace Guestbook.Application.Abstractions;
public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
  where TCommand : ICommand
{
  public new Task<Result> Handle(TCommand command, CancellationToken cancellationToken = default);
}

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
  where TCommand : ICommand<TResponse>
{
  public new Task<Result<TResponse>> Handle(TCommand command, CancellationToken cancellationToken = default);
}
