using Pforr.Guestbook.Domain.Abstractions;

namespace Pforr.Guestbook.Domain.Users;

public sealed class NameErrors
{
  public static readonly Error TooLong = new("Names.TooLong", $"The name must not be longer than {Name.MaxLength} characters.");

  public static readonly Error Empty = new("Names.Empty", "The name must not be empty");
  internal static readonly Error TooShort;
  internal static readonly Error InvalidFormat;
}
