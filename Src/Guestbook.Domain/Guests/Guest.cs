using Guestbook.Domain.Abstractions;
using Guestbook.Domain.Guests.Entries;

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

  public Result UpdateEntryVisitDay(EntryId id, VisitDay? visitDay)
  {
    var result = GetEntry(id);

    if (result.IsFailure)
    {
      return result;
    }

    var entry = result.Value;

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
    var result = GetEntry(id);

    if (result.IsFailure)
    {
      return result;
    }

    var entry = result.Value;

    entry.Update(content);

    return Result.Success();
  }

  public void Remove(Entry entry)
  {
    entries.Remove(entry);
  }

  private bool HasEntryOn(VisitDay? visited)
  {
    return visited is not null && entries.Exists(entry => entry.Visited != null && entry.Visited == visited);
  }

  private Result<Entry> GetEntry(EntryId id)
  {
    var entry = entries.Find(entry => entry.Id == id);

    if (entry is null)
    {
      return Result.Failure<Entry>(EntryErrors.NotFound);
    }

    return Result.Success(entry);
  }
}
