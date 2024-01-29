using AutomatedLearningSystem.Application.Users.Queries.GetUsers;
using AutomatedLearningSystem.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AutomatedLearningSystem.Api.Endpoints.Users;

public class GetUsers : IEndpoint
{

    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {

        app.MapGet(Routes.User.GetAll, async (ISender sender) =>
        {
            var query = new GetUsersQuery();
            var result = await sender.Send(query);
            return Results.Ok(result.Value);

        });
    }
}