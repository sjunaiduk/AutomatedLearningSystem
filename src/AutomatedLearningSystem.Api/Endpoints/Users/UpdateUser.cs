using AutomatedLearningSystem.Api.Mappings;
using AutomatedLearningSystem.Application.Users.Commands.UpdateUser;
using AutomatedLearningSystem.Contracts.Users;
using AutomatedLearningSystem.Infrastructure.Identity;
using MediatR;

namespace AutomatedLearningSystem.Api.Endpoints.Users;

public class UpdateUser : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(Routes.User.Update, async (UpdateUserRequest request,
            Guid id,
        ISender sender) =>
        {
            UpdateUserCommand command = new(
                id,
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password,
                request.Role?.MapToDomainRole());

            var result = await sender.Send(command);

            return result.MatchAll(
                Results.NoContent,
                errors => errors.ToProblemDetails());
        }).RequireAuthorization(AuthConstants.Policies.Protected);
    }
}