using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Users;
using MediatR;

namespace AutomatedLearningSystem.Application.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IUserContext _userContext;

    public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IUserContext userContext)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _userContext = userContext;
    }

    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
        if (user is null)
        {
            return UserErrors.NotFound;
        }

        if (!_userContext.IsAdmin && user.Id != _userContext.Id)
        {
            return UserErrors.UnAuthorized;
        }


        user.Update(request.FirstName,
            request.LastName,
            request.Email,
            request.Password,
            request.role);

        await _unitOfWork.CommitChangesAsync(cancellationToken);

        return Result.Success;

    }
}