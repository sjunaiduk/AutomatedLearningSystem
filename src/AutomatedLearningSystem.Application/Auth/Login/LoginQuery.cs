using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Users;

namespace AutomatedLearningSystem.Application.Auth.Login;

public record LoginQuery(string Email, string Password) : IQuery<Result<User>> { }