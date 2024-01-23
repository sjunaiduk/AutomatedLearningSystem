using AutomatedLearningSystem.Domain.LearningItems;
using TestCommon.Constants;

namespace TestCommon.Factories;

public static class LearningItemFactory
{
    public static List<LearningItem> Create(Category? category = null,
        Guid? id = null,
        int count = 1,
        string name = LearningItemConstants.Name,
        string description = LearningItemConstants.Description)
       
    {
        return Enumerable.Range(0, count)
            .Select(x => LearningItem.Create(name, description, category ?? LearningItemConstants.Category,
                id ?? Guid.NewGuid()).Value)
            .ToList();
    }
}