﻿using FluentAssertions;
using Guestbook.Application.Entries.Commands.CreateEntry;
using Guestbook.Domain.Entries;

namespace Guestbook.Application.UnitTests.TestUtils.Entries.Extensions;
public static partial class EntryExtension
{
  public static void ValidateCreatedFrom(this Entry entry, CreateEntryCommand command)
  {
    entry.Text.Should().Be(command.Content);
    entry.GuestId.Should().Be(command.GuestId);
  }
}
