using Guestbook.Domain.Abstractions;

namespace Guestbook.Domain.Users.Guests;

public sealed record GuestId(Guid Value) : EntityId(Value);
