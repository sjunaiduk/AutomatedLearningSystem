using AutomatedLearningSystem.Domain.Common;

namespace TestCommon.Constants;

public static class LearningItemConstants
{
    public static Guid Id { get; } = Guid.NewGuid();
    public const string Name = "Learning Item";
    public const string Description = "Learning Item Description";
    public static Category Category { get; } = Category.Backend;
    public static DifficultyLevel Level { get; } = DifficultyLevel.Beginner;
    public static Priority Priority { get; } = Priority.Low;

}