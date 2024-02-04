using Guestbook.Domain.Abstractions;

namespace Guestbook.Domain.Guests;

public static class GuestErrors
{
  public static readonly Error AlreadyEntryOnDate = new("Entries.AlreadyExistsWithDate", $"Guest only have one entry per day");
}