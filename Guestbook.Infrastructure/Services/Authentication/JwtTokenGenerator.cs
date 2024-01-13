using Guestbook.Application.Services.Authentication;
using Microsoft.IdentityModel.JsonWebTokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Guestbook.Infrastructure.Services.Authentication;
public class JwtTokenGenerator : IJwtTokenGenerator
{
  public string GenerateToken(Guid userId, string username)
  {
    var claims = new[]
    {
      new Claim(JwtRegisteredClaimNames.Sub,userId.ToString()),
      new Claim(JwtRegisteredClaimNames.UniqueName,username),
      new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
    };

    var token = new JwtSecurityToken(claims: claims);
  }
}
