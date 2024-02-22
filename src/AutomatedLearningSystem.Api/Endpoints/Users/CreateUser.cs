using AutomatedLearningSystem.Api.Mappings;
using AutomatedLearningSystem.Application.Users.Commands.CreateUser;
using AutomatedLearningSystem.Contracts.Users;
using AutomatedLearningSystem.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutomatedLearningSystem.Api.Endpoints.Users;

public class CreateUser : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(Routes.User.Create, async ([FromBody] CreateUserRequest request,
            ISender sender) =>
        {
            CreateUserCommand command = new(request.FirstName,
                request.LastName,
                request.Email,
                request.Password,
                request.RoleDto.MapToDomainRole());

            var result = await sender.Send(command);

            return result.MatchAll(
                user => Results.CreatedAtRoute("GetUser", new { id = user.Id }),
                errors => errors.ToProblemDetails());
        });
    }
}