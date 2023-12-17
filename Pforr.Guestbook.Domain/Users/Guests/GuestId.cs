using Pforr.Guestbook.Domain.Abstractions;

namespace Pforr.Guestbook.Domain.Users.Guests;

public sealed record GuestId(Guid Value) : EntityId(Value);
