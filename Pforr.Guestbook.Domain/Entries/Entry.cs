using Pforr.Guestbook.Domain.Abstractions;
using Pforr.Guestbook.Domain.Users.Guests;

namespace Pforr.Guestbook.Domain.Entries;

public sealed class Entry : Entity<EntryId>
{
  private Entry(EntryId id, Content content, Guest author, DateOnly? visited = null) : base(id)
  {
    Content = content;
    Author = author;
    Visited = visited;
  }

  public Content Content { get; private set; }

  public Guest Author { get; private set; }

  public DateOnly? Visited { get; private set; }

  public static Result<Entry> Create(Content content, Guest author, DateOnly? visitDate = null)
  {
    if (InFuture(visitDate))
    {
      return Result.Failure<Entry>(GuestErrors.VisitDateInFuture(visitDate));
    }

    if (author.HasEntryOn(visitDate))
    {
      return Result.Failure<Entry>(GuestErrors.AlreadyExistsWithDate(author, visitDate));
    }

    return Result.Success(new Entry(new EntryId(Guid.NewGuid()), content, author, visitDate));
  }

  private static bool InFuture(DateOnly? visitDate) => visitDate is not null && visitDate > DateOnly.FromDateTime(DateTime.Now);
}
