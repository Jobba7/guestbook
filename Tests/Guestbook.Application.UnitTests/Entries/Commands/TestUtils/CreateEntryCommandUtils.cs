using Guestbook.Application.Entries.Commands.CreateEntry;
using Guestbook.Domain.Entries;
using Guestbook.Domain.Guests;

namespace Guestbook.Application.UnitTests.Entries.Commands.TestUtils;
public static class CreateEntryCommandUtils
{
  public static CreateEntryCommand CreateCommand(Guest guest) => new(guest.Id, Content.From("Test").Value!);
}
