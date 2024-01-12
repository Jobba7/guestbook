using FluentAssertions;
using Guestbook.Application.Guests.Commands.CreateGuest;
using Guestbook.Application.UnitTests.Guests.Commands.TestUtils;
using Guestbook.Application.UnitTests.TestUtils.Guests.Extensions;
using Guestbook.Domain.Guests;
using Moq;

namespace Guestbook.Application.UnitTests.Guests.Commands.CreateGuest;
public class CreateGuestCommandHandlerTests
{
  private readonly Mock<IGuestRepository> mockGuestRepository;
  private readonly CreateGuestCommandHandler handler;
  private readonly CancellationToken ct;

  public CreateGuestCommandHandlerTests()
  {
    mockGuestRepository = new Mock<IGuestRepository>();
    handler = new CreateGuestCommandHandler(mockGuestRepository.Object);
    ct = default;
  }

  [Fact]
  public async Task HandleCreateGuestCommand_WhenGuestIsValid_ShouldCreateAndReturnGuest()
  {
    // Arrange
    var createGuestCommand = CreateGuestCommandUtils.CreateCommand();

    // Act
    var result = await handler.Handle(createGuestCommand, ct);

    // Assert
    Assert.NotNull(result.Value);
    result.IsSuccess.Should().BeTrue();
    result.Value.ValidateCreatedFrom(createGuestCommand);
    mockGuestRepository.Verify(m => m.Add(result.Value, ct), Times.Once());
  }
}
