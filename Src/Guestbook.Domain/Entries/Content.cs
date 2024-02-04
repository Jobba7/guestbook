using Guestbook.Domain.Abstractions;

namespace Guestbook.Domain.Entries;

public sealed class Content : ValueObject
{
  private Content(string value)
  {
    Value = value;
  }

  public string Value { get; private init; }

  public static Result<Content> From(string text)
  {
    if (string.IsNullOrWhiteSpace(text))
    {
      return Result.Failure<Content>(EntryErrors.EmptyContent);
    }

    return Result.Success(new Content(text));
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
