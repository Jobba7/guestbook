namespace Guestbook.Domain.Abstractions;

public abstract class Entity
{
  protected Entity(Guid id) => Id = id;

  public Guid Id { get; private init; }

  public static bool operator ==(Entity? left, Entity? right)
  {
    return left?.Equals(right) ?? right is null;
  }

  public static bool operator !=(Entity? left, Entity? right)
  {
    return !(left == right);
  }

  public override bool Equals(object? obj)
  {
    return ReferenceEquals(this, obj) || IdentifierEquals(obj);
  }

  private bool IdentifierEquals(object? obj)
  {
    return obj is Entity entity &&
      GetType() == entity.GetType() &&
      Id == entity.Id;
  }

  public override int GetHashCode()
  {
    return HashCode.Combine(Id, GetType());
  }
}
