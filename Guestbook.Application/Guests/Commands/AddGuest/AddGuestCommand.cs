using Guestbook.Application.Abstractions;

namespace Guestbook.Application.Guests.Commands.AddGuest;
public sealed record AddGuestCommand(string Name) : ICommand;
