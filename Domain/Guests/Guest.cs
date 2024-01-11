using Guestbook.Domain.Abstractions;
using Guestbook.Domain.Entries;

namespace Guestbook.Domain.Guests;

public sealed class Guest : AggregateRoot<GuestId>
{
  private readonly List<EntryId> entryIds = [];

  private Guest(GuestId id, string name) : base(id)
  {
    Name = name;
  }

  public string Name { get; private set; }

  public IReadOnlyList<EntryId> Entries => entryIds.AsReadOnly();

  public static Guest Create(string name)
  {
    return new(GuestId.New(), name);
  }

  public void AddEntry(EntryId entryId)
  {
    entryIds.Add(entryId);
  }
}
