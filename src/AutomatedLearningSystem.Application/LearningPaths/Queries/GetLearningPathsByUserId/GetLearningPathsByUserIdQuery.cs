using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.LearningPaths;

namespace AutomatedLearningSystem.Application.LearningPaths.Queries.GetLearningPathsByUserId;

public record GetLearningPathsByUserIdQuery(Guid UserId) : IQuery<Result<List<LearningPath>>> { }