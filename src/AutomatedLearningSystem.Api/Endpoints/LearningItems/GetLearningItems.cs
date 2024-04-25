using AutomatedLearningSystem.Api.Mappings;
using AutomatedLearningSystem.Application.LearningItems;
using AutomatedLearningSystem.Application.LearningItems.Commands;
using AutomatedLearningSystem.Application.LearningItems.Commands.CreateLearningItem;
using AutomatedLearningSystem.Application.LearningPaths.Queries.GetLearningPaths;
using AutomatedLearningSystem.Contracts;
using AutomatedLearningSystem.Contracts.Common;
using AutomatedLearningSystem.Contracts.LearningPaths;
using AutomatedLearningSystem.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutomatedLearningSystem.Api.Endpoints.LearningItems;

public class GetLearningItems : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {

        app.MapGet(Routes.LearningItems.GetAll, async (ISender sender) =>
        {
            var query = new GetLearningItemsQuery();
            var learningItems = await sender.Send(query);
            return Results.Ok(learningItems);

        });

   
    }
}