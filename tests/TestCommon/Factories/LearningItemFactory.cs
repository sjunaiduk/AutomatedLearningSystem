using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.LearningItems;
using TestCommon.Constants;

namespace TestCommon.Factories;

public static class LearningItemFactory
{
    public static List<LearningItem> CreateMany(Category? category = null,
        Guid? id = null,
        int count = 1,
        string name = LearningItemConstants.Name,
        string description = LearningItemConstants.Description,
        Priority? priority = null,
        DifficultyLevel? difficulty = null)
       
    {
        return Enumerable.Range(0, count)
            .Select(x => LearningItem.Create(name, description, category ?? LearningItemConstants.Category,
               priority ?? LearningItemConstants.Priority,
                difficulty ?? LearningItemConstants.Level,
                
                id ?? Guid.NewGuid()))
            .ToList();
    }
}