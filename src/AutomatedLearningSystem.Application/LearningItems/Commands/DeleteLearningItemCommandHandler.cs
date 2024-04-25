using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.Common;
using MediatR;

namespace AutomatedLearningSystem.Application.LearningItems.Commands;

public class DeleteLearningItemCommandHandler : IRequestHandler<DeleteLearningItemCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILearningItemsRepository _itemsRepository;

    public DeleteLearningItemCommandHandler(IUnitOfWork unitOfWork, ILearningItemsRepository itemsRepository)
    {
        _unitOfWork = unitOfWork;
        _itemsRepository = itemsRepository;
    }

    public async Task<Result> Handle(DeleteLearningItemCommand request, CancellationToken cancellationToken)
    {
        var learningItem = await _itemsRepository.GetByIdAsync(request.LearningItemId);
        if (learningItem is null)
        {
            return Error.NotFound();
        }

        _itemsRepository.Delete(learningItem);

        await _unitOfWork.CommitChangesAsync(cancellationToken);

        return Result.Success;
    }
}


