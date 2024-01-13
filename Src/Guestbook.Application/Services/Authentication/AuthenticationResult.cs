namespace Guestbook.Application.Services.Authentication;

public sealed record AuthenticationResult(Guid Id, string Username, string Token);
