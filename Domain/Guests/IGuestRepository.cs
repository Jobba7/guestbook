namespace Guestbook.Domain.Guests;
public interface IGuestRepository
{
  Task AddAsync(Guest guest, CancellationToken cancellationToken = default);

  Task<Guest?> GetByIdAsync(GuestId id, CancellationToken cancellationToken = default);
}
