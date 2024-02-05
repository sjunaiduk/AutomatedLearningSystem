using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Users;
using MediatR;

namespace AutomatedLearningSystem.Application.Auth.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, Result<User>>
{
    
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<User>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.LoginAsync(request.Email, request.Password);

        if (user is null)
        {
            return UserErrors.NotFound;
        }

        return user;
    }
}