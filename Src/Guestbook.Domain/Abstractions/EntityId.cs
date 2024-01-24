namespace Guestbook.Domain.Abstractions;

public abstract class EntityId<TValue> : ValueObject
  where TValue : notnull
{
  protected EntityId(TValue value) => Value = value;

  public TValue Value { get; private init; }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
