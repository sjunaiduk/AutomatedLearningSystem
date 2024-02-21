using AutomatedLearningSystem.Domain.LearningPaths;
using FluentAssertions;
using TestCommon;
using TestCommon.Constants;
using TestCommon.Factories;

namespace AutomatedLearningSystem.Domain.UnitTests.LearningPaths;

public class LearningPathTests
{
    [Fact]
    public void LearningPath_WhenValidLearningItemsSupplied_ShouldCreateLearningPath()
    {
        // Arrange
        var learningItems = LearningItemFactory.CreateMany(count: 10);
        var learningPath = LearningPathFactory.Create();
        var userLearningItems = UserLearningItemFactory.CreateMany(learningItems);

        // Act
        var results = userLearningItems.Select(learningPath.AddLearningItem)
            .ToList();


        // Assert 
        results.Select(r => r.IsSuccess).Should().AllBeEquivalentTo(true);

    }


    [Fact]
    public void LearningPath_WhenDuplicateLearningItemsSupplied_ShouldReturnError()
    {
        // Arrange
        var learningPath = LearningPathFactory.Create();
        var learningItems = LearningItemFactory.CreateMany(count: 2, id: LearningItemConstants.Id);
        var userLearningItems = UserLearningItemFactory.CreateMany(learningItems);
        // Act
        var results = userLearningItems.Select(learningPath.AddLearningItem)
            .ToList()
            .Last();


        // Assert 
        results.FirstError.Should().Be(LearningPathErrors.Conflict);

    }
}