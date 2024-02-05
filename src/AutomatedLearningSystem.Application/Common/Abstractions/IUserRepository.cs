using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Users;

namespace AutomatedLearningSystem.Application.Common.Abstractions;

public interface IUserRepository
{
    void Create(User user);
    Task<User?> GetByIdAsync(Guid id, CancellationToken token = default);

    Task<List<User>> GetAllAsync(CancellationToken token = default);
    void Delete(User user);

    Task<User?> LoginAsync(string requestEmail, string requestPassword);
}