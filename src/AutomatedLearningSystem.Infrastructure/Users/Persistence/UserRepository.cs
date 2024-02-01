using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.Users;
using AutomatedLearningSystem.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

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
        return _dbContext.Set<User>()
            .Include(x => x.LearningPaths)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(token);
    }

    public void Delete(User user)
    {
        _dbContext.Set<User>()
            .Remove(user);
    }

    public async Task<List<User>> GetAllAsync(CancellationToken token = default)
    {
        return await _dbContext.Set<User>()
            .ToListAsync(token);
    }
}