using AutomatedLearningSystem.Application.Questions.Queries.GetQuestions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AutomatedLearningSystem.Api.Endpoints.Questions;

public class GetQuestions : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(Routes.Questions.GetAll, async (ISender sender, CancellationToken token) =>
        {
            GetQuestionsQuery query = new();
            var questions = await sender.Send(query, token);
            return Results.Ok(questions);
        });
    }
}