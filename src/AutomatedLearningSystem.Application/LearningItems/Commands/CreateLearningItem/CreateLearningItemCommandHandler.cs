using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.LearningItems;
using AutomatedLearningSystem.Domain.Users;
using MediatR;

namespace AutomatedLearningSystem.Application.LearningItems.Commands.CreateLearningItem;

public class CreateLearningItemCommandHandler : IRequestHandler<CreateLearningItemCommand, Result>
{

    private readonly ILearningItemsRepository _learningItemsRepository;
    private readonly IUserContext _userContext;
    private readonly IUnitOfWork _unitOfWork;

    public CreateLearningItemCommandHandler(ILearningItemsRepository learningItemsRepository, IUserContext userContext, IUnitOfWork unitOfWork)
    {
        _learningItemsRepository = learningItemsRepository;
        _userContext = userContext;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateLearningItemCommand request, CancellationToken cancellationToken)
    {
        if (_userContext.IsAdmin is false)
        {
            return UserErrors.UnAuthorized;
        }

        var learningItem = LearningItem.Create(request.Name,
            request.Description,
            request.Category,
            request.Priority,
            request.UserLevel);
        _learningItemsRepository.Create(learningItem);
        await _unitOfWork.CommitChangesAsync(cancellationToken);

        return Result.Success;
    }
}