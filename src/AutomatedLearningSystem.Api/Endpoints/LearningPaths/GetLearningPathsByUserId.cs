using AutomatedLearningSystem.Api.Mappings;
using AutomatedLearningSystem.Application.LearningPaths.Queries.GetLearningPathsByUserId;
using MediatR;

namespace AutomatedLearningSystem.Api.Endpoints.LearningPaths;

public class GetLearningPathsByUserId : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {

        // TODO! Create endpoint for all learning paths, and one for a specific user
        app.MapGet(Routes.User.LearningPaths.GetAll, async (ISender sender,
        Guid userId) =>
        {
            var query = new GetLearningPathsByUserIdQuery(userId);
            var result = await sender.Send(query);
            return result.MatchAll(learningPaths =>
            Results.Ok(learningPaths.ToLearningPathsResponse()),
            errors => errors.ToProblemDetails());

        });
    }
}