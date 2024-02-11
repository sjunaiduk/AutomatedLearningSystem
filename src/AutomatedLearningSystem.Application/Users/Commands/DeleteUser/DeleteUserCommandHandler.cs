using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Users;
using MediatR;

namespace AutomatedLearningSystem.Application.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result>
{

    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;
    public DeleteUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IUserContext userContext)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _userContext = userContext;
    }

    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null)
        {
            return UserErrors.NotFound;
        }

        if (!_userContext.IsAdmin && user.Id != _userContext.Id)
        {
            return UserErrors.UnAuthorized;
        }

        _userRepository.Delete(user);

        await _unitOfWork.CommitChangesAsync(cancellationToken);

        return Result.Success;

    }
}