using Guestbook.Application.Abstractions;
using Guestbook.Domain.Abstractions;
using Guestbook.Domain.Guests;
using Guestbook.Domain.Guests.Entries;

namespace Guestbook.Application.Entries.Commands.CreateEntry;
public sealed class CreateEntryCommandHandler(IGuestRepository guestRepository, IUnitOfWork unitOfWork) : ICommandHandler<CreateEntryCommand, Entry>
{
  public async Task<Result<Entry>> Handle(CreateEntryCommand command, CancellationToken cancellationToken = default)
  {
    var guest = await guestRepository.GetById(command.GuestId, cancellationToken);

    if (guest is null)
    {
      return Result.Failure<Entry>(GuestErrors.NotFound);
    }

    var result = guest.CreateEntry(command.Content, command.VisitDay);

    if (result.IsFailure)
    {
      return result;
    }

    guestRepository.Update(guest);

    await unitOfWork.SaveChanges(cancellationToken);

    return result;
  }
}
