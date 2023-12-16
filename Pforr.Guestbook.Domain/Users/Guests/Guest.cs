using Pforr.Guestbook.Domain.Entries;

namespace Pforr.Guestbook.Domain.Users.Guests;

public sealed class Guest : User
{
  private readonly List<Entry> entries = [];

  private Guest(Guid id, Name name, Email? email = null) : base(id, name, email) { }

  public IEnumerable<Entry> Entries => entries.AsReadOnly();

  public bool HasEntryOn(DateOnly? day) => day is not null && entries.Any(entry => entry.Visited == day);
}
