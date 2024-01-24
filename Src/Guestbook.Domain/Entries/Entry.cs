using Guestbook.Domain.Abstractions;
using Guestbook.Domain.Guests;

namespace Guestbook.Domain.Entries;

public sealed class Entry : AggregateRoot<EntryId>
{
  private Entry(EntryId id, string text, GuestId guestId) : base(id)
  {
    Text = text;
    GuestId = guestId;
  }

  public string Text { get; private set; }

  public GuestId GuestId { get; private set; }

  public static Entry Create(string text, GuestId guestId)
  {
    return new(EntryId.New(), text, guestId);
  }
}
