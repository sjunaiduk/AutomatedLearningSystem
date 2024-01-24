using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Users;
using MediatR;

namespace AutomatedLearningSystem.Application.Users.Commands.CreateUser;

public sealed record CreateUserCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    Role Role
    ) : IRequest<Result>
{ }