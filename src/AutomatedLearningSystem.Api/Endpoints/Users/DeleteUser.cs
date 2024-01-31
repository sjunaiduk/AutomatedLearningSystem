using AutomatedLearningSystem.Api.Mappings;
using AutomatedLearningSystem.Application.Users.Commands.DeleteUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutomatedLearningSystem.Api.Endpoints.Users;

public class DeleteUser : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(Routes.User.Delete, async ([FromRoute] Guid id,
            ISender sender) =>
        {
            DeleteUserCommand command = new(id);

            var result = await sender.Send(command);

            return result.MatchAll(
                Results.NoContent,
                errors => errors.ToProblemDetails());
        });

    }
}