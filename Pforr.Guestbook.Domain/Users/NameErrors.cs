using Guestbook.Domain.Abstractions;

namespace Guestbook.Domain.Users;

public sealed class NameErrors
{
  public static readonly Error TooLong = new("Names.TooLong", $"The name must not be longer than {Name.MaxLength} characters");

  public static readonly Error Empty = new("Names.Empty", "The name must not be empty");

  public static readonly Error TooShort = new("Names.TooShort", $"The name must be at least {Name.MinLength} characters long");

  public static readonly Error InvalidFormat = new("Names.InvalidFormat", "The name has an invalid format");
}
