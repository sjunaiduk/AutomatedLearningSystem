using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.LearningPaths;
using AutomatedLearningSystem.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AutomatedLearningSystem.Infrastructure.LearningPaths.Persistence;

public class LearningPathsRepository : ILearningPathRepository
{

    private readonly DbSet<LearningPath> _learningPaths;

    public LearningPathsRepository(AutomatedLearningSystemDbContext db)
    {
        _learningPaths = db.Set<LearningPath>();
    }

    public void Create(LearningPath path)
    {
        _learningPaths
            .Add(path);
    }

    public void DeleteRange(List<LearningPath> userLearningPaths)
    {
        _learningPaths
            .RemoveRange(userLearningPaths);
    }

    public Task<List<LearningPath>> GetAll()
    {
        return _learningPaths
            .Select(x => x)
            .Include(lp => lp.LearningItems)
            .ToListAsync();
    }
}