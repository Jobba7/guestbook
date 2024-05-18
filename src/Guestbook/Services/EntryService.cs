using Guestbook.Domain;
using Guestbook.Persistence;

namespace Guestbook.Services;

public class EntryService(IEntryRepository repository) : IEntryService
{
  public void CreateEntry(string content, Guid author)
  {
    var entry = Entry.Create(content, author);

    repository.Add(entry);
  }

  public IEnumerable<Entry> GetEntries()
  {
    return repository.GetAll();
  }
}
