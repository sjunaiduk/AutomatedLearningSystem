using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Users;
using MediatR;

namespace AutomatedLearningSystem.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<User>>
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

    public async Task<Result<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {

        var isEmailUnique = await _emailService.IsEmailUniqueAsync(request.Email, cancellationToken);

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


        _userRepository.Create(user);

        await _unitOfWork.CommitChangesAsync(cancellationToken);

        return user;

    }
}