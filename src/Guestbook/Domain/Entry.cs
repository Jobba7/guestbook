namespace Guestbook.Domain;

public class Entry
{
  public Guid Id { get; private init; }

  public string Content { get; private set; }

  public Guid Author { get; private init; }

  private Entry(Guid id, string content, Guid author)
  {
    Id = id;
    Content = content;
    Author = author;
  }

  public static Entry Create(string content, Guid author)
  {
    return new Entry(Guid.NewGuid(), content, author);
  }
}
