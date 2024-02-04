namespace Guestbook.Domain.Guests;
public interface IGuestRepository
{
  void Add(Guest guest);

  Task<Guest?> GetById(GuestId id, CancellationToken cancellationToken = default);
}
