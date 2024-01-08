using Pforr.Guestbook.Domain.Abstractions;
using Pforr.Guestbook.Domain.Users.Guests;

namespace Pforr.Guestbook.Domain.Entries;

public static class GuestErrors
{
  public static readonly Error EmptyContent = new("Entries.EmptyContent", "Content must not be empty");

  public static Error VisitDateInFuture(DateOnly? visitDate) =>
    new("Entries.VisitDateInFuture", $"The visit date {visitDate} must not be in the future");

  public static Error AlreadyExistsWithDate(Guest author, DateOnly visitDate) =>
    new("Entries.AlreadyExistsWithDate", $"The Guest {author} may only have one entry per day {visitDate}");
}
