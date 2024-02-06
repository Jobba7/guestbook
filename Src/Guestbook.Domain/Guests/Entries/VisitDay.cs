using Guestbook.Domain.Abstractions;

namespace Guestbook.Domain.Guests.Entries;

public sealed class VisitDay : ValueObject
{
  private VisitDay(DateOnly date)
  {
    Date = date;
  }

  public DateOnly Date { get; private init; }

  public static Result<VisitDay> From(DateOnly date)
  {
    if (date > DateOnly.FromDateTime(DateTime.Now))
    {
      return Result.Failure<VisitDay>(EntryErrors.VisitDateInFuture);
    }

    return Result.Success(new VisitDay(date));
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Date;
  }
}
