using AutomatedLearningSystem.Application.Users.Commands.CreateUser;
using AutomatedLearningSystem.Contracts.Users.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace AutomatedLearningSystem.Api.Endpoints.Users;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost(Routes.UserRoutes.UserBase, async ([FromBody] CreateUserRequest request,
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
    }
}