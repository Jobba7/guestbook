using FluentAssertions;
using Guestbook.Application.Guests.Commands.CreateGuest;
using Guestbook.Domain.Guests;

namespace Guestbook.Application.UnitTests.TestUtils.Guests.Extensions;
public static partial class GuestExtension
{
  public static void ValidateCreatedFrom(this Guest guest, CreateGuestCommand command)
  {
    guest.Name.Should().Be(command.Name);
    guest.Entries.Should().BeEmpty();
  }
}
