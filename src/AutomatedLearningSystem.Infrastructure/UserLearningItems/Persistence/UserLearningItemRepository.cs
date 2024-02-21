using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.LearningPaths;
using AutomatedLearningSystem.Domain.UserLearningItems;
using AutomatedLearningSystem.Domain.Users;
using AutomatedLearningSystem.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AutomatedLearningSystem.Infrastructure.UserLearningItems.Persistence;

public class UserLearningItemRepository : IUserLearningItemRepository
{
    private readonly DbSet<User> _users;
    private readonly DbSet<UserLearningItem> _userLearningItems;

    public UserLearningItemRepository(AutomatedLearningSystemDbContext dbContext)
    {
        dbContext = dbContext;
        _users = dbContext.Set<User>();
        _userLearningItems = dbContext.Set<UserLearningItem>();
    }

    public Task<UserLearningItem?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return _userLearningItems.FirstOrDefaultAsync(uli => uli.Id == id, token);
    }

    public Task<UserLearningItem?> GetByIdForUserAsync(Guid userId, Guid id, CancellationToken token = default)
    {
       return  _users.Where(u => u.Id == userId)
            .Include(u => u.LearningPaths)
            .ThenInclude(lp => lp.UserLearningItems)
            .SelectMany(u => u.LearningPaths.SelectMany(lp => lp.UserLearningItems))
            .FirstOrDefaultAsync(uli => uli.Id == id, cancellationToken: token);
    }

    public void Update(UserLearningItem userLearningItem)
    {
        _userLearningItems.Update(userLearningItem);
    }
}