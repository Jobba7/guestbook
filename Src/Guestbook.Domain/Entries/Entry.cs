using Guestbook.Domain.Abstractions;
using Guestbook.Domain.Guests;

namespace Guestbook.Domain.Entries;

public sealed class Entry : Entity<EntryId>
{
  private Entry(EntryId id, GuestId guestId, DateTime created, Content content, VisitDay? visited) : base(id)
  {
    Content = content;
    Visited = visited;
    Created = created;
    GuestId = guestId;
  }

  public Content Content { get; private set; }

  public VisitDay? Visited { get; private set; }

  public DateTime Created { get; private init; }

  public DateTime? Updated { get; private set; }

  public GuestId GuestId { get; private init; }

  public static Entry Create(GuestId guestId, Content content, VisitDay? visited = null)
  {
    return new(EntryId.New(), guestId, DateTime.Now, content, visited);
  }

  public void Update(Content content)
  {
    Content = content;
  }

  public void Update(VisitDay? visited)
  {
    Visited = visited;
  }
}
