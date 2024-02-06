using Guestbook.Application.Abstractions;

namespace Guestbook.Application.Guests.Queries;
public interface IGetEntriesQuery : IQuery<IQueryable<EntryReadModel>>
{
}
