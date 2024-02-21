using AutomatedLearningSystem.Domain.UserLearningItems;

namespace AutomatedLearningSystem.Application.Common.Abstractions;

public interface IUserLearningItemRepository
{

    Task<UserLearningItem?> GetByIdAsync(Guid id, CancellationToken token = default);

    Task<UserLearningItem?> GetByIdForUserAsync(Guid userId, Guid id, CancellationToken token = default);
    void Update(UserLearningItem userLearningItem);
}