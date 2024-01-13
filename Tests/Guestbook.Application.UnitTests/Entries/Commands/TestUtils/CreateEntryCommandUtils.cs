using Guestbook.Application.Entries.Commands.CreateEntry;
using Guestbook.Application.UnitTests.TestUtils.Constants;
using Guestbook.Domain.Guests;

namespace Guestbook.Application.UnitTests.Entries.Commands.TestUtils;
public static class CreateEntryCommandUtils
{
  public static CreateEntryCommand CreateCommand() => new(Constants.Entry.Content, GuestId.New());
}
