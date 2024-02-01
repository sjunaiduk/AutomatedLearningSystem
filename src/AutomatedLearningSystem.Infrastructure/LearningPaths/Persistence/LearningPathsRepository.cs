using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.LearningPaths;
using AutomatedLearningSystem.Infrastructure.Common.Persistence;

namespace AutomatedLearningSystem.Infrastructure.LearningPaths.Persistence;

public class LearningPathsRepository : ILearningPathRepository
{

    private readonly AutomatedLearningSystemDbContext _db;

    public LearningPathsRepository(AutomatedLearningSystemDbContext db)
    {
        _db = db;
    }

    public void Create(LearningPath path)
    {
        _db.Set<LearningPath>()
            .Add(path);
    }

    public void DeleteRange(List<LearningPath> userLearningPaths)
    {
        _db.Set<LearningPath>()
            .RemoveRange(userLearningPaths);
    }
}