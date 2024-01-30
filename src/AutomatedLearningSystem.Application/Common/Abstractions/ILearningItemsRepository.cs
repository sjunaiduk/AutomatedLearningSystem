using AutomatedLearningSystem.Domain.LearningItems;

namespace AutomatedLearningSystem.Application.Common.Abstractions;

public interface ILearningItemsRepository
{
    Task<List<LearningItem>> GetAllAsync(CancellationToken  cancellationToken = default);
}