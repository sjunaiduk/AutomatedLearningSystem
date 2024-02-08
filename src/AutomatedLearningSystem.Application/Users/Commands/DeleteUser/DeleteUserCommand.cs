using AutomatedLearningSystem.Domain.Common;

namespace AutomatedLearningSystem.Application.Users.Commands.DeleteUser;

public record DeleteUserCommand(Guid UserId) : ICommand<Result> { }