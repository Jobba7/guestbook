using Guestbook.Domain.Abstractions;

namespace Guestbook.Domain.Guests;

public static class GuestErrors
{
  public static readonly Error AlreadyEntryOnDate = new("Entries.AlreadyExistsWithDate", $"Guest only have one entry per day");
  public static readonly Error EntryNotFound = new("Entries.EntryNotFound", $"Entry not found");
  public static readonly Error NotFound = new("Guests.NotFound", $"Guest not found");
}