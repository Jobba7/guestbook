using Guestbook.Domain.Abstractions;
using System.Globalization;

namespace Guestbook.Domain.Users;

public sealed record Name
{
  public const int MinLength = 3;
  public const int MaxLength = 70;

  private const char Space = ' ';

  private Name(string value) => Value = value;

  public string Value { get; }

  public static Result<Name> Create(string name)
  {
    if (string.IsNullOrWhiteSpace(name))
    {
      return Result.Failure<Name>(NameErrors.Empty);
    }

    name = name.Trim();

    if (name.Length < MinLength)
    {
      return Result.Failure<Name>(NameErrors.TooShort);
    }

    if (name.Length > MaxLength)
    {
      return Result.Failure<Name>(NameErrors.TooLong);
    }

    name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name);

    var firstAndLastName = name.Split(Space, StringSplitOptions.RemoveEmptyEntries);

    if (firstAndLastName.Length > 2)
    {
      return Result.Failure<Name>(NameErrors.InvalidFormat);
    }

    if (firstAndLastName.Length == 2)
    {
      name = firstAndLastName[0] + Space + firstAndLastName[1];
    }

    return Result.Success(new Name(name));
  }

  public override string ToString()
  {
    return Value.ToString();
  }
}
