using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.LearningItems;
using MediatR;

namespace AutomatedLearningSystem.Application.LearningItems;

public class GetLearningItemsQueryHandler : IRequestHandler<GetLearningItemsQuery, Result<List<LearningItem>>>
{
    private readonly ILearningItemsRepository _learningItemsRepository;

    public GetLearningItemsQueryHandler(ILearningItemsRepository learningItemsRepository)
    {
        _learningItemsRepository = learningItemsRepository;
    }

    public async Task<Result<List<LearningItem>>> Handle(GetLearningItemsQuery request, CancellationToken cancellationToken)
    {
        var items = await _learningItemsRepository.GetAllAsync(cancellationToken);
        return items;
    }
}