using Guestbook.Domain.Abstractions;

namespace Guestbook.Application.Abstractions;

public interface IQueryHandler<TQuery, TResponse>
  where TQuery : IQuery<TResponse>
{
  Task<Result<TResponse>> Handle(TQuery query, CancellationToken cancellationToken = default);
}
