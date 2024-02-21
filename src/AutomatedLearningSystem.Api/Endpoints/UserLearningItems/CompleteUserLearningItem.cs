using AutomatedLearningSystem.Api.Mappings;
using AutomatedLearningSystem.Application.UserLearningItems.Commands.CompleteUserLearningItem;
using MediatR;

namespace AutomatedLearningSystem.Api.Endpoints.UserLearningItems;

public class CompleteUserLearningItem : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(Routes.UserLearningItems.Update,
            async (ISender sender, Guid userLearningItemId, CancellationToken token) =>
            {
                var command = new CompleteUserLearningItemCommand(userLearningItemId);
                var result = await sender.Send(command, token);
                return result.MatchAll(() => Results.Ok(),
                    errors => errors.ToProblemDetails());

            });
    }
}