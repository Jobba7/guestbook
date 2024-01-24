using Guestbook.Domain.Abstractions;

namespace Guestbook.Domain.Guests;

public sealed class GuestId : AggregateRootId
{
  private GuestId(Guid value) : base(value)
  {
  }

  public static GuestId New() => new(Guid.NewGuid());
}
