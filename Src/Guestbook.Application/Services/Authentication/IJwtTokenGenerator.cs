namespace Guestbook.Application.Services.Authentication;
public interface IJwtTokenGenerator
{
  string GenerateToken(Guid userId, string username);
}
