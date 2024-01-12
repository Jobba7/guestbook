using Guestbook.Application.Guests.Commands.CreateGuest;
using Guestbook.Application.UnitTests.TestUtils.Constants;

namespace Guestbook.Application.UnitTests.Guests.Commands.TestUtils;
public static class CreateGuestCommandUtils
{
  public static CreateGuestCommand CreateCommand() => new(Constants.Guest.Name);
}
