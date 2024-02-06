using Guestbook.Application.Abstractions;
using Guestbook.Domain.Guests;
using Guestbook.Domain.Guests.Entries;

namespace Guestbook.Application.Guests.Commands.CreateEntry;
public sealed record CreateEntryCommand(GuestId GuestId, Content Content, VisitDay? VisitDay = null) : ICommand<Entry>;
