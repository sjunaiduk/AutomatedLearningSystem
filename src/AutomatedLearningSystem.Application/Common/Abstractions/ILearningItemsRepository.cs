using AutomatedLearningSystem.Domain.LearningItems;

namespace AutomatedLearningSystem.Application.Common.Abstractions;

public interface ILearningItemsRepository
{
    Task<List<LearningItem>> GetAllAsync(CancellationToken cancellationToken = default);
    void Create(LearningItem newItem);

    Task<LearningItem?> GetByIdAsync(Guid id);

    void Delete(LearningItem item);
}