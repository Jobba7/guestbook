using Guestbook.Domain;

namespace Guestbook.Services;

public interface IEntryService
{
  void CreateEntry(string content, Guid author);

  IEnumerable<Entry> GetEntries();
}
