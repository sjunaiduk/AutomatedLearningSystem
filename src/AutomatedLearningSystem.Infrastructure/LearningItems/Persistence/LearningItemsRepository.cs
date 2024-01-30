using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.LearningItems;

namespace AutomatedLearningSystem.Infrastructure.LearningItems.Persistence;

public class LearningItemsRepository : ILearningItemsRepository
{
    public Task<List<LearningItem>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}