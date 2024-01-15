namespace Guestbook.Application.Services.Authentication;

public interface IAuthenticationService
{
  Task<AuthenticationResult> Register(string name, CancellationToken cancellationToken = default);
}
