using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Users;

namespace AutomatedLearningSystem.Application.Users.Queries.GetUsers;

public record GetUsersQuery() : IQuery<Result<IEnumerable<User>>> { }