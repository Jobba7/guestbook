using Guestbook.Domain;

namespace Guestbook.Persistence;

public interface IEntryRepository
{
  public void Add(Entry entry);

  public IEnumerable<Entry> GetAll();
}
