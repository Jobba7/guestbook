using Guestbook.Domain.Abstractions;

namespace Guestbook.Domain.Guests;

public static class GuestErrors
{
  public static readonly Error AlreadyEntryOnDate = new("Guests.AlreadyEntryOnDate", $"Guest only have one entry per day");
  public static readonly Error NotFound = new("Guests.NotFound", $"Guest not found");
}