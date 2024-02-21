using System.Reflection.Metadata.Ecma335;
using AutomatedLearningSystem.Domain.LearningItems;
using AutomatedLearningSystem.Domain.LearningPaths;
using AutomatedLearningSystem.Domain.UserLearningItems;

namespace TestCommon;

public static class UserLearningItemFactory
{
    public static List<UserLearningItem> CreateMany(List<LearningItem> learningItems)
    {
        return learningItems.Select(li =>
        UserLearningItem.Create(li)).ToList();
    }
}