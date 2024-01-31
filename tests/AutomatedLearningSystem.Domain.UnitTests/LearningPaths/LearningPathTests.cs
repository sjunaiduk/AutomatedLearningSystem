using AutomatedLearningSystem.Domain.LearningPaths;
using FluentAssertions;
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
        var learningPath = LearningPath.CreateLearningPath();

        // Act
        var results = learningItems.Select(x => learningPath.AddLearningItem(x))
            .ToList();


        // Assert 
        results.Select(r => r.IsSuccess).Should().AllBeEquivalentTo(true);

    }


    [Fact]
    public void LearningPath_WhenDuplicateLearningItemsSupplied_ShouldReturnError()
    {
        // Arrange
        var learningItems = LearningItemFactory.CreateMany(count: 2, id: LearningItemConstants.Id);
        var learningPath = LearningPath.CreateLearningPath();

        // Act
        var results = learningItems.Select(x => learningPath.AddLearningItem(x))
            .ToList()
            .Last();


        // Assert 
        results.FirstError.Should().Be(LearningPathErrors.Conflict);

    }
}