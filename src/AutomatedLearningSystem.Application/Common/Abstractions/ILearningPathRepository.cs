using AutomatedLearningSystem.Domain.LearningPaths;

namespace AutomatedLearningSystem.Application.Common.Abstractions;

public interface ILearningPathRepository
{
    void Create(LearningPath path);
    void DeleteRange(List<LearningPath> userLearningPaths);
    Task<List<LearningPath>> GetAll();

    Task<List<LearningPath>> GetAllByUserId(Guid UserId);
}