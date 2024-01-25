using AutomatedLearningSystem.Domain.Common;

namespace TestCommon.Constants;

public static class LearningItemConstants
{
    public static Guid Id = Guid.NewGuid();
    public const string Name = "Learning Item";
    public const string Description = "Learning Item Description";
    public static Category Category = Category.Backend;
    public static DifficultyLevel DifficultyLevel = DifficultyLevel.Beginner;
    public static Priority Priority = Priority.Low;

}