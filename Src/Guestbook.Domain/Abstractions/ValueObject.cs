namespace Guestbook.Domain.Abstractions;
public abstract class ValueObject
{
  public static bool operator ==(ValueObject? left, ValueObject? right)
  {
    return left?.Equals(right) ?? right is null;
  }

  public static bool operator !=(ValueObject? left, ValueObject? right)
  {
    return !(left == right);
  }

  public override bool Equals(object? obj)
  {
    return ReferenceEquals(this, obj) || StructuralEquals(obj);
  }

  private bool StructuralEquals(object? obj)
  {
    return obj is ValueObject other &&
      GetType() == other.GetType() &&
      GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
  }

  public override int GetHashCode()
  {
    return GetEqualityComponents()
        .Select(x => x != null ? x.GetHashCode() : 0)
        .Aggregate((x, y) => x ^ y);
  }

  protected abstract IEnumerable<object> GetEqualityComponents();
}
