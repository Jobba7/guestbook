namespace Guestbook.Domain.Guests;
public interface IGuestRepository
{
  Task Add(Guest guest, CancellationToken cancellationToken = default);

  Task<Guest?> GetById(GuestId id, CancellationToken cancellationToken = default);
}
