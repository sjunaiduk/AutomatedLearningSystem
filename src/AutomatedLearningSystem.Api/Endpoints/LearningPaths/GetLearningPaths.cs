using AutomatedLearningSystem.Api.Mappings;
using AutomatedLearningSystem.Application.LearningPaths.Queries.GetLearningPaths;
using MediatR;

namespace AutomatedLearningSystem.Api.Endpoints.LearningPaths;

public class GetLearningPaths : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(Routes.LearningPaths.GetAll, async (ISender sender) =>
        {
            var query = new GetLearningPathsQuery();
            var learningPaths = await sender.Send(query);
            return Results.Ok(learningPaths.ToLearningPathsResponse());

        });
    }
}