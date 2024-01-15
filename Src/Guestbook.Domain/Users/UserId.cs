using Guestbook.Domain.Abstractions;

namespace Guestbook.Domain.Users;

public sealed record UserId(Guid Value) : ValueObject
{
  public static UserId New() => new(Guid.NewGuid());
}
