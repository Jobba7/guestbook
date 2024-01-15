using Guestbook.Application.Services;
using Guestbook.Application.Services.Authentication;
using Guestbook.Domain.Guests;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Guestbook.Infrastructure.Services.Authentication;
internal sealed class JwtTokenGenerator : IJwtTokenGenerator
{
  private readonly IClock clock;

  internal JwtTokenGenerator(IClock clock) => this.clock = clock;

  public string GenerateToken(Guest guest)
  {
    var tokenHandler = new JsonWebTokenHandler();

    var key = Encoding.ASCII.GetBytes("key");

    var tokenDescriptor = new SecurityTokenDescriptor()
    {
      Subject = new ClaimsIdentity(new[]
      {
        new Claim(JwtRegisteredClaimNames.Sub, guest.Id.Value.ToString()),
        new Claim(JwtRegisteredClaimNames.Name, guest.Name),
      }),
      Expires = clock.Now.AddDays(1).UtcDateTime,
      SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
    };

    var token = tokenHandler.CreateToken(tokenDescriptor);

    return token;
  }
}
