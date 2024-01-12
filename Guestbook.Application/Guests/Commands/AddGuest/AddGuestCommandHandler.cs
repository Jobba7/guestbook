using Guestbook.Application.Abstractions;
using Guestbook.Domain.Abstractions;
using Guestbook.Domain.Guests;

namespace Guestbook.Application.Guests.Commands.AddGuest;

internal sealed class AddGuestCommandHandler(IGuestRepository guestRepository) : ICommandHandler<AddGuestCommand, Guest>
{
  private readonly IGuestRepository guestRepository = guestRepository;

  public async Task<Result<Guest>> Handle(AddGuestCommand command, CancellationToken cancellationToken = default)
  {
    var guest = Guest.Create(command.Name);

    await guestRepository.Add(guest, cancellationToken);

    return Result.Success(guest);
  }
}
