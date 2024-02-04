using Guestbook.Domain.Abstractions;
using Guestbook.Domain.Entries;

namespace Guestbook.Domain.Guests;

public sealed class Guest : AggregateRoot<GuestId>
{
  private readonly List<EntryOnDate> entryOnDates = [];

  private Guest(GuestId id, string name) : base(id)
  {
    Name = name;
  }

  public string Name { get; private set; }

  public IReadOnlyList<EntryId> EntryIds => entryOnDates.Select(entry => entry.Id).ToList().AsReadOnly();

  public static Guest Create(string name)
  {
    return new(GuestId.New(), name);
  }

  public Result Add(Entry entry)
  {
    if (EntryIds.Contains(entry.Id))
    {
      return Result.Success();
    }

    if (entryOnDates.Select(entry => entry.Visited).Contains(entry.Visited))
    {
      return Result.Failure(GuestErrors.AlreadyEntryOnDate);
    }

    entryOnDates.Add(entry);

    return Result.Success();
  }

  public void Remove(Entry entry)
  {
    entryOnDates.Remove(entry);
  }
}
