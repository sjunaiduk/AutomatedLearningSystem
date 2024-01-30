using AutomatedLearningSystem.Domain.Common;

namespace TestCommon.Constants;

public static class QuestionConstants
{
    public static Guid Id { get; } = Guid.NewGuid();
    public const string Description = "Question Description";
    public static Category Category { get; } = Category.Database;
}