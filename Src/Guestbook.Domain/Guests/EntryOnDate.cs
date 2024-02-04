using Guestbook.Domain.Abstractions;
using Guestbook.Domain.Entries;

namespace Guestbook.Domain.Guests;

public sealed class EntryOnDate : ValueObject
{
  private EntryOnDate(EntryId id, DateOnly visited)
  {
    Id = id;
    Visited = visited;
  }

  public EntryId Id { get; private init; }

  public DateOnly Visited { get; private init; }

  public static implicit operator EntryOnDate(Entry entry)
  {
    return new EntryOnDate(entry.Id, entry.Visited);
  }

  public static EntryOnDate ToEntryOnDate(Entry entry)
  {
    return new EntryOnDate(entry.Id, entry.Visited);
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Id;
    yield return Visited;
  }
}
