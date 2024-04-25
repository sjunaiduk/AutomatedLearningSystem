using AutomatedLearningSystem.Api.Mappings;
using AutomatedLearningSystem.Application.LearningPaths.Queries.GetLearningPaths;
using AutomatedLearningSystem.Application.Users.Queries.GetUser;
using AutomatedLearningSystem.Domain.UserLearningItems;
using MediatR;

namespace AutomatedLearningSystem.Api.Endpoints.LearningPaths;

public class GetLearningPathsReport : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {

        app.MapGet("api/reports", async (ISender sender) =>
        {
            var query = new GetLearningPathsQuery();
            var learningPaths = await sender.Send(query);

            List<UserProgressReportDto> reports = new List<UserProgressReportDto>();


            foreach (var path in learningPaths)
            {

                var userQuery = new GetUserQuery(path.UserId);
                var user = await sender.Send(userQuery);
                var report = new UserProgressReportDto
                {
                    LearningPathId = path.Id,
                    LearningPathName = path.Name,
                    UserId = path.UserId,
                    UserName = user.Value.FirstName, // Assuming the User entity is loaded
                    PercentageProgress = CalculateProgress(path.UserLearningItems)
                };

                reports.Add(report);

            }
            return Results.Ok(reports);

        });
    }
    private double CalculateProgress(List<UserLearningItem> items)
    {
        if (items.Count == 0)
            return 0.0;

        int completedCount = items.Count(item => item.Completed);
        return (double)completedCount / items.Count * 100;
    }
}



public class UserProgressReportDto
{
    public Guid LearningPathId { get; set; }
    public string LearningPathName { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public double PercentageProgress { get; set; }
}


