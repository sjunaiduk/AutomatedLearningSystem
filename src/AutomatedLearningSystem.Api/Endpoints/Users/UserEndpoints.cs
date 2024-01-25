using AutomatedLearningSystem.Application.Users.Commands.CreateUser;
using AutomatedLearningSystem.Application.Users.Commands.DeleteUser;
using AutomatedLearningSystem.Contracts.Users.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutomatedLearningSystem.Api.Endpoints.Users;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost(Routes.UserRoutes.Create, async ([FromBody] CreateUserRequest request,
            ISender sender) =>
        {
            CreateUserCommand command = new(request.FirstName,
                request.LastName,
                request.Email,
                request.Password,
                request.Role.MapToRole());

            var result = await sender.Send(command);

            return result.MatchAll(
                Results.NoContent,
                errors => errors.ToProblemDetails());
        });

        app.MapDelete(Routes.UserRoutes.Delete, async ([FromRoute] Guid id,
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