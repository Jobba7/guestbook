using Guestbook.Application.Abstractions;
using Guestbook.Domain.Guests;

namespace Guestbook.Application.Services.Authentication;
public class AuthenticationService : IAuthenticationService
{
  private readonly IGuestRepository guestRepository;
  private readonly IUnitOfWork unitOfWork;
  private readonly IJwtTokenGenerator jwtTokenGenerator;

  public AuthenticationService(IGuestRepository guestRepository, IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenGenerator)
  {
    this.guestRepository = guestRepository;
    this.unitOfWork = unitOfWork;
    this.jwtTokenGenerator = jwtTokenGenerator;
  }

  public async Task<AuthenticationResult> Register(string name, CancellationToken cancellationToken = default)
  {
    var guest = Guest.Create(name);

    guestRepository.Add(guest);

    await unitOfWork.SaveChanges(cancellationToken);

    var token = jwtTokenGenerator.GenerateToken(guest);

    return new(guest.Id.Value, guest.Name, token);
  }
}
