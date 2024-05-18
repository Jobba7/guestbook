namespace Guestbook.Domain;

public class Guest
{
  public Guid Id { get; private init; }

  public string Name { get; private set; }

  public IReadOnlyList<Guid> Entries => entries.AsReadOnly();

  private readonly List<Guid> entries;

  private Guest(Guid id, string name, List<Guid> entries)
  {
    Id = id;
    Name = name;
    this.entries = entries;
  }

  public static Guest Create(string name)
  {
    return new Guest(Guid.NewGuid(), name, new List<Guid>());
  }
}
