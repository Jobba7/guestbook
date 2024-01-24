namespace Guestbook.Domain.Abstractions;

public abstract class Entity<TId>
  where TId : ValueObject
{
  protected Entity(TId id) => Id = id;

  public TId Id { get; private init; }

  public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
  {
    return left?.Equals(right) ?? right is null;
  }

  public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
  {
    return !(left == right);
  }

  public override bool Equals(object? obj)
  {
    return ReferenceEquals(this, obj) || IdentifierEquals(obj);
  }

  private bool IdentifierEquals(object? obj)
  {
    return obj is Entity<TId> entity &&
      GetType() == entity.GetType() &&
      Id == entity.Id;
  }

  public override int GetHashCode()
  {
    return HashCode.Combine(Id, GetType());
  }
}
