using AutomatedLearningSystem.Domain.LearningPaths;
using FluentAssertions;
using TestCommon.Factories;

namespace AutomatedLearningSystem.Domain.UnitTests.LearningPaths;

public class LearningPathTests  
{
    [Fact]

    public void LearningPath_WhenValidLearningItemsSupplied_ShouldCreateLearningPath()
    {
        // Arrange
        var learningItems = LearningItemFactory.Create(count: 10);
        var learningPath = LearningPath.CreateLearningPath();

        // Act
        var results = learningItems.Select(x => learningPath.AddLearningItem(x))
            .ToList();


        // Assert 
        results.Select(r => r.IsSuccess).Should().AllBeEquivalentTo(true);

    }
}