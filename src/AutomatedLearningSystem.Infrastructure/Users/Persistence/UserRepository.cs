using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.Users;
using AutomatedLearningSystem.Infrastructure.Common.Persistence;

namespace AutomatedLearningSystem.Infrastructure.Users.Persistence;

public class UserRepository : IUserRepository
{
    private readonly AutomatedLearningSystemDbContext _dbContext;

    public UserRepository(AutomatedLearningSystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Create(User user)
    {
        _dbContext.Set<User>().Add(user);
    }

    public Task<User?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}