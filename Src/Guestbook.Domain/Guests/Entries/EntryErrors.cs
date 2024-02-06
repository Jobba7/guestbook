using Guestbook.Domain.Abstractions;

namespace Guestbook.Domain.Guests.Entries;

public static class EntryErrors
{
  public static readonly Error EmptyContent = new("Entries.EmptyContent", "Content must not be empty");
  public static readonly Error NotFound = new("Entries.NotFound", "Entry not found");
  public static readonly Error VisitDateInFuture = new("Entries.VisitDateInFuture", $"Visit date must not be in future");
}
