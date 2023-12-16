namespace Pforr.Guestbook.Domain.Abstractions;

public sealed record Error(string Code, string? Description = null)
{
  public static implicit operator Result(Error error) => Result.Failure(error);
}
