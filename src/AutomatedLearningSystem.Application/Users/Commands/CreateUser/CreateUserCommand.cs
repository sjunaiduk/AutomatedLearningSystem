using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Users;
using Role = AutomatedLearningSystem.Domain.Users.Role;

namespace AutomatedLearningSystem.Application.Users.Commands.CreateUser;

public sealed record CreateUserCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    Role Role
    ) : ICommand<Result<User>>
{ }