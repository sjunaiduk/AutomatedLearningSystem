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
}