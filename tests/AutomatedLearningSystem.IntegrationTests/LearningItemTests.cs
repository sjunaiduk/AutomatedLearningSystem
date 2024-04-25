using AutomatedLearningSystem.Application.LearningItems.Commands;
using AutomatedLearningSystem.Application.Users.Commands.DeleteUser;
using AutomatedLearningSystem.Domain.LearningItems;
using AutomatedLearningSystem.Domain.LearningPaths;
using AutomatedLearningSystem.Domain.Questions;
using AutomatedLearningSystem.IntegrationTests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using TestCommon.Factories;
using AutomatedLearningSystem.Application.LearningItems.Commands.CreateLearningItem;

namespace AutomatedLearningSystem.IntegrationTests;

public class LearningItemTests : BaseIntegrationTest
{
    public LearningItemTests(IntegrationTestWebApplicationFactory factory) :
        base(factory, "admin", Guid.NewGuid())
    {
    }

    [Fact]

    public async Task Handler_ShouldDeleteLearningItem_WhenLearningItemExists()
    {
        // Arrange
        var learningItem = DbContext.Set<LearningItem>().First();


        var deleteLearningItemCommand = new DeleteLearningItemCommand(learningItem.Id);

        //// Act


        var result = await Sender.Send(deleteLearningItemCommand);
        var deletedLearningItem = (await DbContext.Set<LearningItem>()
            .FirstOrDefaultAsync(x => x.Id == learningItem.Id));


        // Assert
        result.FirstError.Should().BeNull();
        result.IsSuccess.Should().BeTrue();

        deletedLearningItem.Should().BeNull();

    }

    [Fact]

    public async Task Handler_ShouldCreateLearningItem()
    {
        // Arrange
        var learningItem = LearningItemFactory.CreateMany().First();


        var command = new CreateLearningItemCommand(learningItem.Name,
            "xyz",
            learningItem.Category,
            learningItem.Priority,
            learningItem.UserLevel);

        //// Act


        var result = await Sender.Send(command);
        var createdLearningItem = (await DbContext.Set<LearningItem>()
            .FirstOrDefaultAsync(x => x.Description == "xyz"));


        // Assert
        result.FirstError.Should().BeNull();
        result.IsSuccess.Should().BeTrue();

        createdLearningItem.Should().NotBeNull();

    }

}