using Guestbook.Domain.Abstractions;

namespace Guestbook.Domain.Users;

public abstract class User<TId> : Entity<TId>
    where TId : notnull
{
  protected User(TId id, Name name, Email? email = null) : base(id)
  {
    this.Name = name;
    this.Email = email;
  }

  public Name Name { get; private set; }

  public Email? Email { get; private set; }

  public override string ToString()
  {
    return this.Name.ToString();
  }
}
