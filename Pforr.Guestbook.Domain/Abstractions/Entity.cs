namespace Pforr.Guestbook.Domain.Abstractions;

public abstract class Entity<TId> : IEquatable<Entity<TId>> where TId : EntityId
{
  private readonly List<IDomainEvent> domainEvents = [];

  protected Entity(TId id) => Id = id;

  public TId Id { get; private init; }

  public IEnumerable<IDomainEvent> DomainEvents => domainEvents.AsReadOnly();

  protected void Raise(IDomainEvent domainEvent) => domainEvents.Add(domainEvent);


  public static bool operator ==(Entity<TId>? first, Entity<TId>? second)
  {
    return first is not null && second is not null && first.Equals(second);
  }

  public static bool operator !=(Entity<TId>? first, Entity<TId>? second)
  {
    return !(first == second);
  }

  public bool Equals(Entity<TId>? other)
  {
    if (other is null)
    {
      return false;
    }

    if (other.GetType() != GetType())
    {
      return false;
    }

    if (other.Id.GetType() != Id.GetType())
    {
      return false;
    }

    return other.Id == Id;
  }

  public override bool Equals(object? obj)
  {
    if (obj is null)
    {
      return false;
    }

    if (obj.GetType() != GetType())
    {
      return false;
    }

    if (obj is not Entity<TId> entity)
    {
      return false;
    }

    if (entity.Id.GetType() != Id.GetType())
    {
      return false;
    }

    return entity.Id == Id;
  }

  public override int GetHashCode()
  {
    return Id.GetHashCode();
  }

  public override string ToString()
  {
    return $"Entity {Id.Value}";
  }
}
