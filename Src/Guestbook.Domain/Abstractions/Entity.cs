namespace Guestbook.Domain.Abstractions;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull
{
  private readonly List<IDomainEvent> domainEvents = [];

  protected Entity(TId id) => this.Id = id;

  public TId Id { get; private init; }

  public IEnumerable<IDomainEvent> DomainEvents => this.domainEvents.AsReadOnly();

  public static bool operator ==(Entity<TId>? first, Entity<TId>? second)
  {
    return first is not null && second is not null && first.Equals(second);
  }

  public static bool operator !=(Entity<TId>? first, Entity<TId>? second)
  {
    return !(first == second);
  }

  public virtual bool Equals(Entity<TId>? other)
  {
    if (other is null)
    {
      return false;
    }

    if (other.GetType() != this.GetType())
    {
      return false;
    }

    if (other.Id.GetType() != this.Id.GetType())
    {
      return false;
    }

    return Id.Equals(other.Id);
  }

  public override bool Equals(object? obj)
  {
    if (obj is null)
    {
      return false;
    }

    if (obj.GetType() != this.GetType())
    {
      return false;
    }

    if (obj is not Entity<TId> entity)
    {
      return false;
    }

    if (entity.Id.GetType() != this.Id.GetType())
    {
      return false;
    }

    return Id.Equals(entity.Id);
  }

  public override int GetHashCode() => this.Id.GetHashCode();

  public override string ToString() => $"Entity {Id}";

  protected void Add(IDomainEvent domainEvent) => this.domainEvents.Add(domainEvent);
}
