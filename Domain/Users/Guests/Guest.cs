using Guestbook.Domain.Abstractions;
using Guestbook.Domain.Entries;
using System.Diagnostics.CodeAnalysis;

namespace Guestbook.Domain.Users.Guests;

public sealed class Guest : User<GuestId>
{
  private readonly List<Entry> entries = [];

  private Guest(Name name, Email? email = null) : base(new GuestId(Guid.NewGuid()), name, email) { }

  public IEnumerable<Entry> Entries => entries.AsReadOnly();

  public static Guest Create(Name name, Email? email = null)
  {
    return new Guest(name, email);
  }

  public Result<Entry> AddEntry(Content content, DateOnly? visitDate = null)
  {
    if (HasEntryOn(visitDate))
    {
      return Result.Failure<Entry>(GuestErrors.AlreadyExistsWithDate(this, visitDate.Value));
    }

    var result = Entry.Create(content, Id, visitDate);

    if (result.IsFailure)
    {
      return result;
    }

    entries.Add(result.Value);

    return result;
  }

  private bool HasEntryOn([NotNullWhen(true)] DateOnly? date)
  {
    return date is not null && entries
      .Where(entry => entry.Visited != null)
      .Any(entry => entry.Visited == date);
  }
}
