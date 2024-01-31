using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Application.Users.Commands.CreateUser;
using AutomatedLearningSystem.Domain.Users;
using FluentAssertions;
using NSubstitute;
using TestCommon.Factories;

namespace AutomatedLearningSystem.Application.UnitTests.Users.CreateUser;

public class CreateUserCommandHandlerTests
{
    private readonly IUserRepository _userRepositoryMock = Substitute.For<IUserRepository>();
    private readonly IUnitOfWork _unitOfWorkMock = Substitute.For<IUnitOfWork>();
    private readonly IEmailService _emailServiceMock = Substitute.For<IEmailService>();

    [Fact]
    public async void Handler_WhenUserEmailUnique_ShouldCreateUser()
    {
        // Arrange
        _emailServiceMock.IsEmailUniqueAsync(Arg.Any<string>()).Returns(true);
        var handler = new CreateUserCommandHandler(_userRepositoryMock,
            _unitOfWorkMock,
            _emailServiceMock);
        var command = UserCommandsFactory.CreateUserCommandFactory.Create();

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.IsSuccess.Should().BeTrue();

    }

    [Fact]
    public async void Handler_WhenUserEmailExists_ShouldNotCreateUser()
    {
        // Arrange
        _emailServiceMock.IsEmailUniqueAsync(Arg.Any<string>()).Returns(false);
        var handler = new CreateUserCommandHandler(_userRepositoryMock,
            _unitOfWorkMock,
            _emailServiceMock);
        var command = UserCommandsFactory.CreateUserCommandFactory.Create();

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.FirstError.Should().Be(UserErrors.DuplicateEmail);
        result.IsFailure.Should().BeTrue();

    }
}