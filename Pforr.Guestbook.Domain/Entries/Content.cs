using Pforr.Guestbook.Domain.Abstractions;

namespace Pforr.Guestbook.Domain.Entries;

public sealed record Content
{
  private Content(string text, DateTime lastEdited)
  {
    Text = text;
    LastEdited = lastEdited;
  }

  public string Text { get; }

  public DateTime LastEdited { get; }

  public static Result<Content> Create(string text)
  {
    if (string.IsNullOrWhiteSpace(text))
    {
      return Result.Failure<Content>(GuestErrors.EmptyContent);
    }

    return Result.Success(new Content(text.Trim(), DateTime.Now));
  }
}
