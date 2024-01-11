namespace Guestbook.Domain.Abstractions;
public abstract class AggregateRoot : Entity<Guid>
{
  protected AggregateRoot(Guid id) : base(id)
  {
  }
}
