using Guestbook.Application.Services;

namespace Guestbook.Infrastructure.Services;
internal sealed class Clock : IClock
{
  public DateTimeOffset Now => DateTimeOffset.Now;
}
