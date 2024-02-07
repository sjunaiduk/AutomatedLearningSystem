using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.LearningPaths;
using MediatR;

namespace AutomatedLearningSystem.Application.LearningPaths.Queries.GetLearningPaths;

public class GetLearningPathsQueryHandler : IRequestHandler<GetLearningPathsQuery, List<LearningPath>>
{

    private readonly ILearningPathRepository _learningPathRepository;

    public GetLearningPathsQueryHandler(ILearningPathRepository learningPathRepository)
    {
        _learningPathRepository = learningPathRepository;
    }

    public async Task<List<LearningPath>> Handle(GetLearningPathsQuery request, CancellationToken cancellationToken)
    {
        var result = await _learningPathRepository.GetAll();

        return result;
    }
}