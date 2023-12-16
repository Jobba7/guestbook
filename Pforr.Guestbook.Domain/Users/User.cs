using Pforr.Guestbook.Domain.Abstractions;

namespace Pforr.Guestbook.Domain.Users;

public abstract class User : Entity
{
  protected User(Guid id, Name name, Email? email = null) : base(id)
  {
    Name = name;
    Email = email;
  }

  public Name Name { get; private set; }

  public Email? Email { get; private set; }

  public override string ToString()
  {
    return Name.ToString();
  }
}
