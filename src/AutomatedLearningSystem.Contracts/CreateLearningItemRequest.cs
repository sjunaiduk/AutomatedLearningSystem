using AutomatedLearningSystem.Contracts.Common;
using AutomatedLearningSystem.Contracts.LearningPaths;

namespace AutomatedLearningSystem.Contracts;

public record CreateLearningItemRequest(string Name,
    string Description,
    CategoryDto Category,
    PriorityDto Priority,
    UserLevelDto UserLevel);