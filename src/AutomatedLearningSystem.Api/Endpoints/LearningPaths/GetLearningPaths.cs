using AutomatedLearningSystem.Api.Mappings;
using AutomatedLearningSystem.Application.LearningPaths.Queries.GetLearningPaths;
using MediatR;

namespace AutomatedLearningSystem.Api.Endpoints.LearningPaths;

public class GetLearningPaths : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {

        // TODO! Create endpoint for all learning paths, and one for a specific user
        app.MapGet(Routes.User.LearningPaths.GetAll, async (ISender sender) =>
        {
            var query = new GetLearningPathsQuery();
            var learningPaths = await sender.Send(query);
            return Results.Ok(learningPaths.ToLearningPathsResponse());

        });
    }
}