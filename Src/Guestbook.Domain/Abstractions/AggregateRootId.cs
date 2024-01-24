namespace Guestbook.Domain.Abstractions;
public abstract class AggregateRootId : EntityId<Guid>
{
  protected AggregateRootId(Guid value) : base(value)
  {
  }
}
