using Pforr.Guestbook.Domain.Abstractions;

namespace Pforr.Guestbook.Domain.Entries;

public sealed record EntryId(Guid Value) : EntityId(Value);

