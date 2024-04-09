using AutomatedLearningSystem.Domain.Common;

namespace AutomatedLearningSystem.Domain.UserLearningItems;

public static class UserLearningItemErrors
{
    public static Error NotFound =>
        new("UserLearningItem.NotFound", "UserLearningItem was not found.", ErrorType.NotFound);
}