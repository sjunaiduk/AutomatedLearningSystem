using AutomatedLearningSystem.Domain.Common;

namespace AutomatedLearningSystem.Domain.LearningItems;

public class LearningItem
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;

    public string Description { get; private set; } = null!;

    public Category Category { get; private set; }

    public Priority Priority { get; private set; }

    public UserLevel UserLevel { get; private set; }

    // for use during in memory learning path personalization
    public decimal Score { get; set; } = 1;

    private LearningItem()
    {

    }

    private LearningItem(string name, string description, Category category,
        Priority priority,
        UserLevel level,
        Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        Name = name;
        Description = description;
        Category = category;
        Priority = priority;
        UserLevel = level;

    }

    public static LearningItem Create(string name, string description, Category category,
        Priority priority,
        UserLevel role,
        Guid? id = null)
    {
        return new LearningItem(name, description, category, priority,
            role,
             id);
    }
}