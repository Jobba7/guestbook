using Guestbook.Domain.Guests;

namespace Guestbook.Application.Services.Authentication;
public interface IJwtTokenGenerator
{
  string GenerateToken(Guest guest);
}
