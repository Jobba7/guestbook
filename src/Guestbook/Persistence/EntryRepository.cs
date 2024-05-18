using Guestbook.Domain;

namespace Guestbook.Persistence;

public class EntryRepository : IEntryRepository
{
  private readonly List<Entry> entries = [];

  public void Add(Entry entry)
  {
    entries.Add(entry);
  }

  public IEnumerable<Entry> GetAll()
  {
    return entries.AsReadOnly();
  }
}
