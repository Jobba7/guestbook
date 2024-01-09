using Guestbook.Domain.Abstractions;
using Guestbook.Domain.Users.Guests;

namespace Guestbook.Domain.Entries;

public sealed class Entry : Entity<EntryId>
{
  private Entry(Content content, GuestId authorId, DateOnly? visited = null) : base(new EntryId(Guid.NewGuid()))
  {
    Content = content;
    AuthorId = authorId;
    Visited = visited;
  }

  public Content Content { get; private set; }

  public GuestId AuthorId { get; private set; }

  public DateOnly? Visited { get; private set; }

  public static Result<Entry> Create(Content content, GuestId authorId, DateOnly? visitDate = null)
  {
    if (InFuture(visitDate))
    {
      return Result.Failure<Entry>(GuestErrors.VisitDateInFuture(visitDate));
    }

    return Result.Success(new Entry(content, authorId, visitDate));
  }

  private static bool InFuture(DateOnly? visitDate) => visitDate is not null && visitDate > today;

  private static readonly DateOnly today = DateOnly.FromDateTime(DateTime.Now);
}
