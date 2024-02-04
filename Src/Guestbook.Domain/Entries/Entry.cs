using Guestbook.Domain.Abstractions;
using Guestbook.Domain.Guests;

namespace Guestbook.Domain.Entries;

public sealed class Entry : AggregateRoot<EntryId>
{
  private Entry(EntryId id, Content content, VisitDay visited, DateTime created, GuestId guestId) : base(id)
  {
    Content = content;
    Visited = visited;
    Created = created;
    GuestId = guestId;
  }

  public Content Content { get; private set; }

  public VisitDay Visited { get; private set; }

  public DateTime Created { get; private init; }

  public DateTime? Updated { get; private set; }

  public GuestId GuestId { get; private init; }

  public static Entry Create(Content content, VisitDay visited, GuestId guestId)
  {
    return new(EntryId.New(), content, visited, DateTime.Now, guestId);
  }

  public void Update(Content content)
  {
    Content = content;
  }

  public void Update(VisitDay visited)
  {
    Visited = visited;
  }
}
