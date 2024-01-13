using Guestbook.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Guestbook.Application;
public static class DependencyInjection
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddScoped<IAuthenticationService, AuthenticationService>();

    services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

    return services;
  }
}
