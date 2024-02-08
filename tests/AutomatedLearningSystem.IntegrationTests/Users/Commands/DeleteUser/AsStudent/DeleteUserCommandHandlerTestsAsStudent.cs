using AutomatedLearningSystem.Application.Users.Commands.DeleteUser;
using AutomatedLearningSystem.Domain.Users;
using AutomatedLearningSystem.IntegrationTests.Infrastructure;
using FluentAssertions;

namespace AutomatedLearningSystem.IntegrationTests.Users.Commands.DeleteUser.AsStudent;

public class DeleteUserCommandHandlerTestsAsStudent : BaseIntegrationTest
{

    // Mock user claims
    public DeleteUserCommandHandlerTestsAsStudent(IntegrationTestWebApplicationFactory factory) : base(factory, "student",
        Guid.NewGuid())
    {
    }


    [Fact]

    public async void Handler_ShouldNotDeleteUser_WhenUserIsStudentAndTriesToDeleteDifferentUser()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var command = new DeleteUserCommand(userId);

        // Act
        var result = await Sender.Send(command);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.FirstError.Should().Be(UserErrors.UnAuthorized);
    }
}