using Guestbook.Domain.Abstractions;

namespace Guestbook.Domain.Entries;

public sealed class EntryId : AggregateRootId
{
  private EntryId(Guid value) : base(value)
  {
  }

  public static EntryId New() => new(Guid.NewGuid());
}
