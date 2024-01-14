using Guestbook.Application.Services.Authentication;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Guestbook.Infrastructure.Services.Authentication;
public class JwtTokenGenerator : IJwtTokenGenerator
{
  public string GenerateToken(Guid userId, string username)
  {
    var tokenHandler = new JsonWebTokenHandler();

    var key = Encoding.ASCII.GetBytes("key");

    var tokenDescriptor = new SecurityTokenDescriptor()
    {
      Subject = new ClaimsIdentity(new[]
      {
         new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
         new Claim(JwtRegisteredClaimNames.Name, username),
      }),
      Expires = DateTime.UtcNow.AddDays(1),
      SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
    };

    var token = tokenHandler.CreateToken(tokenDescriptor);

    return token;
  }
}
