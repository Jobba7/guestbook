using Guestbook.Application.Entries.Commands.CreateEntry;
using Guestbook.Domain.Guests;
using Guestbook.Domain.Guests.Entries;

namespace Guestbook.Application.UnitTests.Entries.Commands.TestUtils;
public static class CreateEntryCommandUtils
{
  public static CreateEntryCommand CreateCommand(Guest guest) => new(guest.Id, Content.From("Test").Value!);
}
