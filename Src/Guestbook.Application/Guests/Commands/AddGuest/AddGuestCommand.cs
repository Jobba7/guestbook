using Guestbook.Application.Abstractions;
using Guestbook.Domain.Guests;

namespace Guestbook.Application.Guests.Commands.AddGuest;
public sealed record AddGuestCommand(string Name) : ICommand<Guest>;
