using Guestbook.Application.Abstractions;
using Guestbook.Domain.Guests;

namespace Guestbook.Application.Guests.Commands.CreateGuest;
public sealed record CreateGuestCommand(string Name) : ICommand<Guest>;
