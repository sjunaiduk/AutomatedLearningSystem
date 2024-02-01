using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Users;
using MediatR;

namespace AutomatedLearningSystem.Application.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result>
{

    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILearningPathRepository _learningPathRepository;
    public DeleteUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, ILearningPathRepository learningPathRepository)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _learningPathRepository = learningPathRepository;
    }

    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

        if (user is null)
        {
            return UserErrors.NotFound;
        }

        _userRepository.Delete(user);
       // _learningPathRepository.DeleteRange(user.LearningPaths);

        await _unitOfWork.CommitChangesAsync(cancellationToken);

        return Result.Success;

    }
}