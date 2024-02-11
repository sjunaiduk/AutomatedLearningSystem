using AutomatedLearningSystem.Domain.LearningPaths;
using TestCommon.Constants;

namespace TestCommon.Factories;

public static class LearningPathFactory
{
    public static LearningPath Create(int learningItemsCount = 1, string name = LearningPathConstants.Name)
    {
        var learningPath = LearningPath.CreateLearningPath(name);
        var learningItems = LearningItemFactory.CreateMany(count: learningItemsCount);

        learningItems.Select(item => learningPath.AddLearningItem(item));

        return learningPath;
    }
}