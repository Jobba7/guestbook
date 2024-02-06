using Guestbook.Domain.Abstractions;
using Guestbook.Domain.Entries;

namespace Guestbook.Domain.Guests;

public sealed class Guest : AggregateRoot<GuestId>
{
  private readonly List<Entry> entries = [];

  private Guest(GuestId id, string name) : base(id)
  {
    Name = name;
  }

  public string Name { get; private set; }

  public IReadOnlyList<Entry> Entries => entries.AsReadOnly();

  public static Guest Create(string name)
  {
    return new(GuestId.New(), name);
  }

  public Result<Entry> CreateEntry(Content content, VisitDay? visitDay = null)
  {
    if (HasEntryOn(visitDay))
    {
      return Result.Failure<Entry>(GuestErrors.AlreadyEntryOnDate);
    }

    var entry = Entry.Create(Id, content, visitDay);

    entries.Add(entry);

    return Result.Success(entry);
  }

  private bool HasEntryOn(VisitDay? visited)
  {
    return visited is not null && entries.Exists(entry => entry.Visited != null && entry.Visited == visited);
  }

  public Result UpdateEntryVisitDay(EntryId id, VisitDay? visitDay)
  {
    var entry = entries.Find(entry => entry.Id == id);

    if (entry is null)
    {
      return Result.Failure(GuestErrors.EntryNotFound);
    }

    if (entry.Visited == visitDay)
    {
      return Result.Success();
    }

    if (HasEntryOn(visitDay))
    {
      return Result.Failure(GuestErrors.AlreadyEntryOnDate);
    }

    entry.Update(visitDay);

    return Result.Success();
  }

  public Result UpdateEntryContent(EntryId id, Content content)
  {
    var entry = entries.Find(entry => entry.Id == id);

    if (entry is null)
    {
      return Result.Failure(GuestErrors.EntryNotFound);
    }

    entry.Update(content);

    return Result.Success();
  }

  public void Remove(Entry entry)
  {
    entries.Remove(entry);
  }
}
