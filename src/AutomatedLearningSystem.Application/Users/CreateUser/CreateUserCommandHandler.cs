using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Users;
using MediatR;

namespace AutomatedLearningSystem.Application.Users.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
{
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IEmailService emailService)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _emailService = emailService;
    }

    public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {

        var isEmailUnique = await _emailService.IsEmailUniqueAsync(request.Email);

        if (!isEmailUnique)
        {
            return UserErrors.DuplicateEmail;
        }
        
        var user = User.Create(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Role,
            request.Password);


        await _userRepository.CreateAsync(user, cancellationToken);

        await _unitOfWork.CommitChangesAsync(cancellationToken);

        return Result.Success;

    }
}