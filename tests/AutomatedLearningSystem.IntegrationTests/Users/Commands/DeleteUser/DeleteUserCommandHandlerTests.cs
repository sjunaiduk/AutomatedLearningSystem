using AutomatedLearningSystem.Application.Users.Commands.DeleteUser;
using AutomatedLearningSystem.Domain.LearningPaths;
using AutomatedLearningSystem.Domain.Questions;
using AutomatedLearningSystem.Domain.Users;
using AutomatedLearningSystem.IntegrationTests.Infrastructure;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using TestCommon.Factories;

namespace AutomatedLearningSystem.IntegrationTests.Users.Commands.DeleteUser;

public class DeleteUserCommandHandlerTests : BaseIntegrationTest
{
    public DeleteUserCommandHandlerTests(IntegrationTestWebApplicationFactory factory) : base(factory)
    {
    }

    [Fact]

    public async Task Handler_ShouldDeleteUserAndLearningPaths_WhenUserHasLearningPaths()
    {
        // Arrange
        var user = DbContext.Set<User>().First();
        var userId = user.Id;
        var question = DbContext.Set<Question>().First();
        var generateLearningPathCommand = GenerateLearningPathCommandFactory.Create(userId, question);
        var deleteUserCommand = new DeleteUserCommand(userId);

        // Act
        
        
        await Sender.Send(generateLearningPathCommand);
        var learningPath = (await DbContext.Set<User>().Include(x => x.LearningPaths)
            .FirstAsync(u => u.Id == userId)).LearningPaths.First();
        await Sender.Send(deleteUserCommand);

        // Assert
        DbContext.Set<User>()
            .FirstOrDefault(u => u.Id == userId)
            .Should().BeNull();
        DbContext.Set<LearningPath>()
            .FirstOrDefault(lp => lp.Id == learningPath.Id)
            .Should().BeNull();

    }
}