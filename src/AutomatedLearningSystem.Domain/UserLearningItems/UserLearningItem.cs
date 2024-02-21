using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.LearningItems;
using AutomatedLearningSystem.Domain.LearningPaths;

namespace AutomatedLearningSystem.Domain.UserLearningItems;

public class UserLearningItem
{
    public Guid Id { get; init; }

    public LearningItem? LearningItem { get; private set; } 

    public bool Completed { get; private set; }

    public static UserLearningItem Create(LearningItem learningItem,
    Guid? id = null)
    {
        return new(learningItem, id);
    }

    public void Complete()
    {
        Completed = true;
    }
    private UserLearningItem(LearningItem learningItem,
    Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        LearningItem = learningItem;
    }
    private UserLearningItem()
    {

    }

}

public static class UserLearningItemErrors
{
    public static Error NotFound =>
        new("UserLearningItem.NotFound", "UserLearningItem was not found.", ErrorType.NotFound);
}