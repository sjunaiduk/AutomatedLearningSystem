using AutomatedLearningSystem.Api.Mappings;
using AutomatedLearningSystem.Application.Users.Queries.GetUsers;
using AutomatedLearningSystem.Contracts.Users;
using AutomatedLearningSystem.Infrastructure.Identity;
using MediatR;

namespace AutomatedLearningSystem.Api.Endpoints.Users;

public class GetUsers : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {

        app.MapGet(Routes.User.GetAll, async (ISender sender) =>
        {
            var query = new GetUsersQuery();
            var result = await sender.Send(query);
            return Results.Ok(result.Value.Select(user =>

                new UserResponse
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    RoleDto = user.Role.MapToUiRole(),
                    Password = user.Password
                })
            );

        }).RequireAuthorization(AuthConstants.Policies.Privileged);
    }
}