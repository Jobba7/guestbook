using Guestbook.Domain.Abstractions;

namespace Guestbook.Domain.Users;

public static class EmailErrors
{
  public static readonly Error Empty = new("Emails.Empty", "The email must not be empty");

  public static readonly Error InvalidFormat = new("Emails.InvalidFormat", "The format of the email is invalid");
}
