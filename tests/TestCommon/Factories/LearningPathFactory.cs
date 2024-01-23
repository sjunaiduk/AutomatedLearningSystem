using AutomatedLearningSystem.Domain.LearningItems;
using AutomatedLearningSystem.Domain.LearningPaths;
using TestCommon.Constants;

namespace TestCommon.Factories;

public static class LearningPathFactory
{
    public static LearningPath Create(int learningItemsCount = 1)
    {
        var learningPath = LearningPath.CreateLearningPath().Value;
        var learningItems = LearningItemFactory.Create(count: learningItemsCount);

        learningItems.Select(item => learningPath.AddLearningItem(item));

        return learningPath;
    }
}