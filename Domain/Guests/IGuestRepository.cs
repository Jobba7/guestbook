namespace Guestbook.Domain.Guests;
public interface IGuestRepository
{
  Task Add(Guest guest, CancellationToken cancellationToken);

  Task<Guest?> GetById(GuestId id, CancellationToken cancellationToken);
}
