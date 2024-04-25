using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.LearningItems;

namespace AutomatedLearningSystem.Application.LearningItems;

public record GetLearningItemsQuery() : IQuery<Result<List<LearningItem>>>;