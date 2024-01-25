using AutomatedLearningSystem.Domain.Common;

namespace AutomatedLearningSystem.Domain.LearningItems;

public class LearningItem
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;

    public string Description { get; private set; } = null!;

    public Category Category { get; private set; }

    public Priority Priority { get; private set; }

    public DifficultyLevel DifficultyLevel { get; private set; }

    // for use during in memory learning path personalization
    public decimal Score { get; set; } = 1;

    private LearningItem()
    {

    }

    private LearningItem(string name, string description, Category category,
        Priority priority,
        DifficultyLevel difficultyLevel,
        Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        Name = name;
        Description = description;
        Category = category;
        Priority = priority;
        DifficultyLevel = difficultyLevel;

    }

    public static LearningItem Create(string name, string description, Category category,
        Priority priority,
        DifficultyLevel difficultyLevel,
        Guid? id = null)
    {
        return new LearningItem( name,  description,  category, priority,
            difficultyLevel,
             id);
    }
}