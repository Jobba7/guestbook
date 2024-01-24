using Guestbook.Domain.Abstractions;

namespace Guestbook.Domain.Users;

public sealed class UserId : AggregateRootId
{
  private UserId(Guid value) : base(value)
  {
  }

  public static UserId New() => new(Guid.NewGuid());
}
