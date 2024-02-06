namespace Guestbook.Application.Guests.Queries;
public sealed class EntryReadModel
{
  public int Id { get; set; }

  public string Content { get; set; } = string.Empty;

  public DateOnly? Visited { get; set; }

  public DateTime Created { get; set; }

  public DateTime? Updated { get; set; }

  public Guid GuestId { get; set; }
}
