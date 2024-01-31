using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Users;

namespace AutomatedLearningSystem.Application.Users.Queries.GetUser;

public record GetUserQuery(Guid Id) : IQuery<Result<User>> { }