using Guestbook.Domain.Abstractions;

namespace Guestbook.Domain.Guests;

public sealed record GuestId(Guid Value) : ValueObject
{
  public static GuestId New() => new(Guid.NewGuid());
}
