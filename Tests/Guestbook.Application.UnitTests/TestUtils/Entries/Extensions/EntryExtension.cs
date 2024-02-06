using FluentAssertions;
using Guestbook.Application.Entries.Commands.CreateEntry;
using Guestbook.Domain.Guests.Entries;

namespace Guestbook.Application.UnitTests.TestUtils.Entries.Extensions;
public static partial class EntryExtension
{
  public static void ValidateCreatedFrom(this Entry entry, CreateEntryCommand command)
  {
    entry.Content.Should().Be(command.Content);
    entry.GuestId.Should().Be(command.GuestId);
  }
}
