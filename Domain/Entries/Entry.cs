using Guestbook.Domain.Abstractions;
using Guestbook.Domain.Users.Guests;

namespace Guestbook.Domain.Entries;

public sealed class Entry : AggregateRoot<EntryId>
{
  private Entry(EntryId id, string content, GuestId guestId) : base(id)
  {
    Content = content;
    GuestId = guestId;
  }

  public string Content { get; private set; }

  public GuestId GuestId { get; private set; }

  public static Entry Create(string content, GuestId guestId)
  {
    return new(EntryId.New(), content, guestId);
  }
}
