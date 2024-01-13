using Guestbook.Application.Abstractions;
using Guestbook.Domain.Entries;
using Guestbook.Domain.Guests;

namespace Guestbook.Application.Entries.Commands.CreateEntry;
public sealed record CreateEntryCommand(string Content, GuestId GuestId) : ICommand<Entry>;
