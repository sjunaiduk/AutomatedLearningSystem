using AutomatedLearningSystem.Domain.LearningItems;
using AutomatedLearningSystem.Domain.LearningPaths;
using TestCommon.Constants;

namespace TestCommon.Factories;

public static class LearningPathFactory
{
    public static LearningPath Create(int learningItemsCount = 1)
    {
        var learningPath = LearningPath.CreateLearningPath();
        var learningItems = LearningItemFactory.CreateMany(count: learningItemsCount);

        learningItems.Select(item => learningPath.AddLearningItem(item));

        return learningPath;
    }
}