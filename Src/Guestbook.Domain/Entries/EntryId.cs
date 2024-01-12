using Guestbook.Domain.Abstractions;

namespace Guestbook.Domain.Entries;

public sealed record EntryId(Guid Value) : ValueObject
{
  public static EntryId New() => new(Guid.NewGuid());
}
