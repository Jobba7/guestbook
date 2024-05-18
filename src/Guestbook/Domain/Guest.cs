namespace Guestbook.Domain;

public class Guest
{
  public Guid Id { get; private init; }

  public string Name { get; private set; }

  private Guest(Guid id, string name)
  {
    Id = id;
    Name = name;
  }

  public static Guest Create(string name)
  {
    return new Guest(Guid.NewGuid(), name);
  }
}
