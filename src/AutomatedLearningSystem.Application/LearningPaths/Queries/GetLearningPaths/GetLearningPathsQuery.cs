using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.LearningPaths;

namespace AutomatedLearningSystem.Application.LearningPaths.Queries.GetLearningPaths;

public record GetLearningPathsQuery() : IQuery<List<LearningPath>> {}