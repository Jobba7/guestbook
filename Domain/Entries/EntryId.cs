using Guestbook.Domain.Abstractions;

namespace Guestbook.Domain.Entries;

public sealed record EntryId(Guid Value) : EntityId(Value);
