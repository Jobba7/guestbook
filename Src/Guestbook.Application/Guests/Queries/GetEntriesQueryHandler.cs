using Guestbook.Application.Abstractions;

namespace Guestbook.Application.Guests.Queries;
public sealed class GetEntriesQueryHandler(IEntryReadRepository repository) : IQueryHandler<IGetEntriesQuery, IQueryable<EntryReadModel>>
{
  public Task<IQueryable<EntryReadModel>> Handle(IGetEntriesQuery query, CancellationToken cancellationToken = default)
  {
    return Task.FromResult(repository.GetAll());
  }
}
