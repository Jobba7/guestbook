using Guestbook.Application.Abstractions;
using Guestbook.Domain.Abstractions;
using Guestbook.Domain.Guests;

namespace Guestbook.Application.Guests.Commands.CreateGuest;

public sealed class CreateGuestCommandHandler(IGuestRepository guestRepository, IUnitOfWork unitOfWork) : ICommandHandler<CreateGuestCommand, Guest>
{
  private readonly IGuestRepository guestRepository = guestRepository;
  private readonly IUnitOfWork unitOfWork = unitOfWork;

  public async Task<Result<Guest>> Handle(CreateGuestCommand command, CancellationToken cancellationToken = default)
  {
    var guest = Guest.Create(command.Name);

    guestRepository.Add(guest);

    await unitOfWork.SaveChanges(cancellationToken);

    return Result.Success(guest);
  }
}
