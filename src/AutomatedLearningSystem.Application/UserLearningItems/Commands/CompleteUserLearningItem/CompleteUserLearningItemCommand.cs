namespace AutomatedLearningSystem.Application.UserLearningItems.Commands.CompleteUserLearningItem;

using AutomatedLearningSystem.Domain.Common;

public record CompleteUserLearningItemCommand(Guid UserLearningItemId) : ICommand<Result> { }