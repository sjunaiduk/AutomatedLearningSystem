using AutomatedLearningSystem.Domain.Common;

namespace AutomatedLearningSystem.Domain.LearningPaths;

public static class LearningPathErrors
{
    public static Error Conflict =>
        new("LearningPath.Conflict",
            "A duplicate learning item was added to the learning path",
            ErrorType.Conflict);

    public static Error LearningPathLimitReached => new("LearningPath.LimitReached",
        "Learning item count has reached the limit",
        ErrorType.Validation);
}