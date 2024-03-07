using AutomatedLearningSystem.Api.Mappings;
using AutomatedLearningSystem.Application.Users.Queries.GetUser;
using AutomatedLearningSystem.Contracts.Users;
using AutomatedLearningSystem.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutomatedLearningSystem.Api.Endpoints.Users;

public class GetUser : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(Routes.User.Get, async ([FromRoute] Guid id, ISender sender) =>
        {
            var query = new GetUserQuery(id);

            var result = await sender.Send(query);

            return result.MatchAll(user => Results.Ok(
                    new UserResponse
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Role = user.Role.MapToUiRole()
                    }),
                errors => errors.ToProblemDetails());
        }).WithName("GetUser")
        .RequireAuthorization(AuthConstants.Policies.Privileged);
    }
}