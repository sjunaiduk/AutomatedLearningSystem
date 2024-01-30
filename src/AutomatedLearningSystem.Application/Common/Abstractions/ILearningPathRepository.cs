using AutomatedLearningSystem.Domain.LearningPaths;

namespace AutomatedLearningSystem.Application.Common.Abstractions;

public interface ILearningPathRepository
{
    Task Create(LearningPath  path);
}