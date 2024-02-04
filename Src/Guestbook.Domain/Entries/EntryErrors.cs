using Guestbook.Domain.Abstractions;

namespace Guestbook.Domain.Entries;

public static class EntryErrors
{
  public static readonly Error EmptyContent = new("Entries.EmptyContent", "Content must not be empty");
  public static readonly Error NotFound = new("Guests.NotFound", "Guest not found");
  public static readonly Error VisitDateInFuture = new("Entries.VisitDateInFuture", $"Visit date must not be in future");
}
