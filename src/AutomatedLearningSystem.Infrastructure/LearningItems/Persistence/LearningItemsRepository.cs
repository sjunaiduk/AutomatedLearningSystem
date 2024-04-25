using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.LearningItems;
using AutomatedLearningSystem.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AutomatedLearningSystem.Infrastructure.LearningItems.Persistence;

public class LearningItemsRepository : ILearningItemsRepository
{
    private readonly AutomatedLearningSystemDbContext _db;

    public LearningItemsRepository(AutomatedLearningSystemDbContext db)
    {
        _db = db;
    }

    public Task<List<LearningItem>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _db.Set<LearningItem>()
            .ToListAsync(cancellationToken);
    }

    public void Create(LearningItem newItem)
    {
        _db.Set<LearningItem>()
            .Add(newItem);
    }

    public Task<LearningItem?> GetByIdAsync(Guid id)
    {
        return _db.Set<LearningItem>()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public void Delete(LearningItem item)
    {
        _db.Set<LearningItem>().Remove(item);
    }
}