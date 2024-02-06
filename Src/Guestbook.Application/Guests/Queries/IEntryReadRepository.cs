namespace Guestbook.Application.Guests.Queries;

public interface IEntryReadRepository
{
  IQueryable<EntryReadModel> GetAll();
}