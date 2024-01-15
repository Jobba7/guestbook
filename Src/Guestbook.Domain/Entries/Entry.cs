using Guestbook.Domain.Abstractions;
using Guestbook.Domain.Guests;

namespace Guestbook.Domain.Entries;

public sealed class Entry : AggregateRoot
{
  private Entry(Guid id, string content, GuestId guestId) : base(id)
  {
    Content = content;
    GuestId = guestId;
  }

  public string Content { get; private set; }

  public GuestId GuestId { get; private set; }

  public static Entry Create(string content, GuestId guestId)
  {
    return new(Guid.NewGuid(), content, guestId);
  }
}
