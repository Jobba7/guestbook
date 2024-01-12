using Guestbook.Application.Abstractions;
using Guestbook.Domain.Abstractions;
using Guestbook.Domain.Guests;

namespace Guestbook.Application.Guests.Commands.CreateGuest;

public sealed class CreateGuestCommandHandler(IGuestRepository guestRepository) : ICommandHandler<CreateGuestCommand, Guest>
{
  private readonly IGuestRepository guestRepository = guestRepository;

  public async Task<Result<Guest>> Handle(CreateGuestCommand command, CancellationToken cancellationToken)
  {
    var guest = Guest.Create(command.Name);

    await guestRepository.Add(guest, cancellationToken);

    return Result.Success(guest);
  }
}
