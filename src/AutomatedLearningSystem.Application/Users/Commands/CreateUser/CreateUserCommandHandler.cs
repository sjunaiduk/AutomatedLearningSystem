using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Http;

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

        var role = request.Role;
        if (request.Token is not null)
        {
            if (request.Token == "123")
            {
                role = Role.Admin;
            }
        }
        var user = User.Create(
            request.FirstName,
            request.LastName,
            request.Email,
            role,
            request.Password);


        _userRepository.Create(user);

        await _unitOfWork.CommitChangesAsync(cancellationToken);

        return user;

    }
}