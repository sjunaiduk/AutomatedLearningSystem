using AutomatedLearningSystem.Domain.Common;

namespace AutomatedLearningSystem.Application.LearningItems.Commands.CreateLearningItem;

public record CreateLearningItemCommand(
    string Name,
    string Description,
    Category Category,
    Priority Priority,
    UserLevel UserLevel) : ICommand<Result>;

