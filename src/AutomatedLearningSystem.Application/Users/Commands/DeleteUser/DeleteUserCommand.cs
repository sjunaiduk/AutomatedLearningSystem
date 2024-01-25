using AutomatedLearningSystem.Domain.Common;

namespace AutomatedLearningSystem.Application.Users.Commands.DeleteUser;

public record DeleteUserCommand(Guid Id) : ICommand<Result> {}