using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.LearningPaths;

namespace AutomatedLearningSystem.Infrastructure.LearningPaths.Persistence;

public class LearningPathsRepository : ILearningPathRepository
{
    public Task Create(LearningPath path)
    {
        throw new NotImplementedException();
    }
}