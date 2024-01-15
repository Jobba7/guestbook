using Guestbook.Application.Services;
using Guestbook.Application.Services.Authentication;
using Guestbook.Infrastructure.Services;
using Guestbook.Infrastructure.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Guestbook.Infrastructure;
public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services)
  {
    services.AddSingleton<IClock, Clock>();

    services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

    return services;
  }
}
