namespace Guestbook.Application.Services.Authentication;

public sealed record AuthenticationResult(Guid Id, string Name, string Token);
