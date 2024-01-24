using AutomatedLearningSystem.Domain.Users;

namespace AutomatedLearningSystem.Application.Common.Abstractions;

public interface IUserRepository
{
    Task CreateAsync(User  user, CancellationToken token = default);
    Task<User?> GetByIdAsync(Guid id, CancellationToken token = default);

}