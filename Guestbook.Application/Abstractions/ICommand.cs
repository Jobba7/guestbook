using Guestbook.Domain.Abstractions;
using MediatR;

namespace Guestbook.Application.Abstractions;
public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
