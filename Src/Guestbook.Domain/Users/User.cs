using Guestbook.Domain.Abstractions;

namespace Guestbook.Domain.Users;

public sealed class User : AggregateRoot<UserId>
{
  private User(UserId id, string name) : base(id)
  {
    this.Name = name;
  }

  public string Name { get; private set; }

  public static User Create(string name)
  {
    return new(UserId.New(), name);
  }

  public override string ToString()
  {
    return Name;
  }
}
