using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.UserLearningItems;
using MediatR;

namespace AutomatedLearningSystem.Application.UserLearningItems.Commands.CompleteUserLearningItem;

public class CompleteUserLearningItemCommandHandler : IRequestHandler<CompleteUserLearningItemCommand, Result>
{
    private readonly IUserLearningItemRepository _userLearningItemRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;

    public CompleteUserLearningItemCommandHandler(IUserLearningItemRepository userLearningItemRepository, IUnitOfWork unitOfWork, IUserContext userContext)
    {
        _userLearningItemRepository = userLearningItemRepository;
        _unitOfWork = unitOfWork;
        _userContext = userContext;
    }

    public async Task<Result> Handle(CompleteUserLearningItemCommand request, CancellationToken cancellationToken)
    {
        var userLearningItem = await _userLearningItemRepository.GetByIdForUserAsync(_userContext.Id,
            request.UserLearningItemId,
            cancellationToken);

        if (userLearningItem == null)
        {
            return UserLearningItemErrors.NotFound;
        }
        userLearningItem.Complete();
        _userLearningItemRepository.Update(userLearningItem);
        var affected = await _unitOfWork.CommitChangesAsync(cancellationToken);
        if (affected != 1)
        {
            throw new InvalidOperationException();
        }
        return Result.Success;
    }
}