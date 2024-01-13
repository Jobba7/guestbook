using FluentAssertions;
using Guestbook.Application.Abstractions;
using Guestbook.Application.Guests.Commands.CreateGuest;
using Guestbook.Application.UnitTests.Guests.Commands.TestUtils;
using Guestbook.Application.UnitTests.TestUtils.Guests.Extensions;
using Guestbook.Domain.Guests;
using Moq;

namespace Guestbook.Application.UnitTests.Guests.Commands.CreateGuest;
public class CreateEntryCommandHandlerTests
{
  private readonly Mock<IGuestRepository> mockGuestRepository;
  private readonly Mock<IUnitOfWork> mockUnitOfWork;
  private readonly CreateGuestCommandHandler handler;
  private readonly CancellationToken cancellation;

  public CreateEntryCommandHandlerTests()
  {
    mockGuestRepository = new Mock<IGuestRepository>();
    mockUnitOfWork = new Mock<IUnitOfWork>();
    handler = new CreateGuestCommandHandler(mockGuestRepository.Object, mockUnitOfWork.Object);
    cancellation = CancellationToken.None;
  }

  [Fact]
  public async Task HandleCreateGuestCommand_WhenGuestIsValid_ShouldCreateAndReturnGuest()
  {
    // Arrange
    var createGuestCommand = CreateGuestCommandUtils.CreateCommand();

    // Act
    var result = await handler.Handle(createGuestCommand, cancellation);

    // Assert
    Assert.NotNull(result.Value);
    result.IsSuccess.Should().BeTrue();
    result.Value.ValidateCreatedFrom(createGuestCommand);
    mockGuestRepository.Verify(m => m.Add(result.Value), Times.Once());
    mockUnitOfWork.Verify(m => m.SaveChanges(cancellation), Times.Once());
  }
}
