using AutomatedLearningSystem.Domain.Common;

namespace AutomatedLearningSystem.Application.LearningItems.Commands;

public record DeleteLearningItemCommand(Guid LearningItemId) : ICommand<Result>;