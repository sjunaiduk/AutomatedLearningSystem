using AutomatedLearningSystem.Domain.Common;

namespace AutomatedLearningSystem.Domain.Questions;

public class Question
{

    public Guid Id { get; private set; }
    public string Description { get; private set; } = null!;

    public Category Category { get; private set; }


    private Question() { }

    private Question(Guid id,
        string description,
        Category category)
    {
        Id = id;
        Description = description;
        Category = category;
    }

    public static Question Create(string description,
        Category category,
        Guid? id = null)
    {
        return new Question(id ?? Guid.NewGuid(),
            description,
            category);
    }
}