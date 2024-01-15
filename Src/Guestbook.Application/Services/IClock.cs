namespace Guestbook.Application.Services;
public interface IClock
{
  DateTimeOffset Now { get; }
}
