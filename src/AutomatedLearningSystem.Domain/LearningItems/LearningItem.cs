using AutomatedLearningSystem.Domain.Common;

namespace AutomatedLearningSystem.Domain.LearningItems;

public class LearningItem
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;

    public string Description { get; private set; } = null!;

    public Category Category { get; private set; }

    private LearningItem()
    {

    }

    private LearningItem(string name, string description, Category category,
        Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        Name = name;
        Description = description;
        Category = category;

    }

    public static LearningItem Create(string name, string description, Category category,
        Guid? id = null)
    {
        return new LearningItem( name,  description,  category,
             id);
    }
}