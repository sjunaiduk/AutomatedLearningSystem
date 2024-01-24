using AutomatedLearningSystem.Domain.Users;

namespace AutomatedLearningSystem.Application.Common.Abstractions;

public interface IUserRepository
{
    void Create(User  user);
    Task<User?> GetByIdAsync(Guid id, CancellationToken token = default);

}