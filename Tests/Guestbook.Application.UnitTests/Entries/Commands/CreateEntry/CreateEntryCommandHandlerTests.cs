using FluentAssertions;
using Guestbook.Application.Abstractions;
using Guestbook.Application.Guests.Commands.CreateEntry;
using Guestbook.Application.UnitTests.Entries.Commands.TestUtils;
using Guestbook.Application.UnitTests.TestUtils.Entries.Extensions;
using Guestbook.Application.UnitTests.TestUtils.Guests.Extensions;
using Guestbook.Domain.Guests;
using Moq;

namespace Guestbook.Application.UnitTests.Entries.Commands.CreateEntry;
public class CreateEntryCommandHandlerTests
{
  private readonly Mock<IGuestRepository> mockGuestRepository;
  private readonly Mock<IUnitOfWork> mockUnitOfWork;
  private readonly CreateEntryCommandHandler handler;
  private readonly CancellationToken cancellation;

  public CreateEntryCommandHandlerTests()
  {
    mockGuestRepository = new Mock<IGuestRepository>();
    mockUnitOfWork = new Mock<IUnitOfWork>();
    handler = new CreateEntryCommandHandler(mockGuestRepository.Object, mockUnitOfWork.Object);
    cancellation = CancellationToken.None;
  }

  [Fact]
  public async Task HandleCreateEntryCommand_WhenEntryIsValid_ShouldCreateAndReturnEntry()
  {
    // Arrange
    var guest = Guest.Create("Guest Name");
    mockGuestRepository.Setup(o => o.GetById(guest.Id, cancellation)).Returns(Task.FromResult((Guest?)guest));
    var createEntryCommand = CreateEntryCommandUtils.CreateCommand(guest);

    // Act
    var result = await handler.Handle(createEntryCommand, cancellation);

    // Assert
    Assert.NotNull(result.Value);
    result.IsSuccess.Should().BeTrue();
    result.Value.ValidateCreatedFrom(createEntryCommand);
    mockGuestRepository.Verify(m => m.Update(guest), Times.Once());
    mockUnitOfWork.Verify(m => m.SaveChanges(cancellation), Times.Once());
  }
}
