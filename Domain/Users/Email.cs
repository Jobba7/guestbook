using Guestbook.Domain.Abstractions;
using System.Net.Mail;

namespace Guestbook.Domain.Users;

public sealed class Email
{
  private Email(string address)
  {
    this.Address = address;
    this.Confirmed = false;
  }

  public string Address { get; private set; }

  public bool Confirmed { get; private set; }

  public static Result<Email> Create(string? email)
  {
    if (string.IsNullOrWhiteSpace(email))
    {
      return Result.Failure<Email>(EmailErrors.Empty);
    }

    if (!MailAddress.TryCreate(email, out var result))
    {
      return Result.Failure<Email>(EmailErrors.InvalidFormat);
    }

    return Result.Success(new Email(result.Address));
  }

  public void Confirm() => this.Confirmed = true;

  public Result TryChange(string? email)
  {
    var result = Create(email);

    if (result.IsSuccess)
    {
      this.Address = result.Value.Address;
      this.Confirmed = false;
    }

    return result;
  }
}
