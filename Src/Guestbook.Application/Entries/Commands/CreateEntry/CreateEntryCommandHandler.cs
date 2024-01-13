using Guestbook.Application.Abstractions;
using Guestbook.Domain.Abstractions;
using Guestbook.Domain.Entries;

namespace Guestbook.Application.Entries.Commands.CreateEntry;
public sealed class CreateEntryCommandHandler(IEntryRepository entryRepository, IUnitOfWork unitOfWork) : ICommandHandler<CreateEntryCommand, Entry>
{
  private readonly IEntryRepository entryRepository = entryRepository;
  private readonly IUnitOfWork unitOfWork = unitOfWork;

  public async Task<Result<Entry>> Handle(CreateEntryCommand command, CancellationToken cancellationToken = default)
  {
    var entry = Entry.Create(command.Content, command.GuestId);

    entryRepository.Add(entry);

    await unitOfWork.SaveChanges(cancellationToken);

    return Result.Success(entry);
  }
}
