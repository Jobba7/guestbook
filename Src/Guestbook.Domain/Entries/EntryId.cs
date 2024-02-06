using Guestbook.Domain.Abstractions;

namespace Guestbook.Domain.Entries;

public sealed class EntryId : EntityId<int>
{
  private EntryId(int value) : base(value)
  {
  }

  public static EntryId New() => new(0);
}
