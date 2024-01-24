namespace Guestbook.Domain.Abstractions;
public abstract class AggregateRoot<TId> : Entity<TId>
  where TId : AggregateRootId
{
  protected AggregateRoot(TId id) : base(id)
  {
  }
}
