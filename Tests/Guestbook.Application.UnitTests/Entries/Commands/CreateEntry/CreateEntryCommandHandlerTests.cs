using FluentAssertions;
using Guestbook.Application.Abstractions;
using Guestbook.Application.Entries.Commands.CreateEntry;
using Guestbook.Application.UnitTests.Entries.Commands.TestUtils;
using Guestbook.Application.UnitTests.TestUtils.Entries.Extensions;
using Guestbook.Application.UnitTests.TestUtils.Guests.Extensions;
using Guestbook.Domain.Entries;
using Moq;

namespace Guestbook.Application.UnitTests.Entries.Commands.CreateEntry;
public class CreateEntryCommandHandlerTests
{
  private readonly Mock<IEntryRepository> mockEntryRepository;
  private readonly Mock<IUnitOfWork> mockUnitOfWork;
  private readonly CreateEntryCommandHandler handler;
  private readonly CancellationToken cancellation;

  public CreateEntryCommandHandlerTests()
  {
    mockEntryRepository = new Mock<IEntryRepository>();
    mockUnitOfWork = new Mock<IUnitOfWork>();
    handler = new CreateEntryCommandHandler(mockEntryRepository.Object, mockUnitOfWork.Object);
    cancellation = CancellationToken.None;
  }

  [Fact]
  public async Task HandleCreateEntryCommand_WhenEntryIsValid_ShouldCreateAndReturnEntry()
  {
    // Arrange
    var createEntryCommand = CreateEntryCommandUtils.CreateCommand();

    // Act
    var result = await handler.Handle(createEntryCommand, cancellation);

    // Assert
    Assert.NotNull(result.Value);
    result.IsSuccess.Should().BeTrue();
    result.Value.ValidateCreatedFrom(createEntryCommand);
    mockEntryRepository.Verify(m => m.Add(result.Value), Times.Once());
    mockUnitOfWork.Verify(m => m.SaveChanges(cancellation), Times.Once());
  }
}
