using AutomatedLearningSystem.Api.Mappings;
using AutomatedLearningSystem.Application.Users.Commands.CreateUser;
using AutomatedLearningSystem.Contracts;
using AutomatedLearningSystem.Contracts.Users;
using MediatR;

namespace AutomatedLearningSystem.Api.Endpoints.Auth;

public class Register : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(Routes.Register, async (HttpContext context, ISender sender,
            RegisterRequest request) =>
        {
            var command = new CreateUserCommand(request.FirstName,
                request.LastName,
                request.Email,
                request.Password,
                Domain.Users.Role.Student,
                request.Token);

            var registerResult
                = await sender.Send(command);

            if (registerResult
                .IsFailure)
            {
                return registerResult
                    ?.FirstError?.ToProblemDetails();
            }

            return Results.Created();

        });
    }
}