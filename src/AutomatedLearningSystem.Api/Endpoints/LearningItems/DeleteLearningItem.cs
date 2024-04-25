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

public class DeleteLearningItem : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {

    

        app.MapDelete($"/api/learning-items/{{id:guid}}", async ([FromRoute]Guid id, ISender sender) =>
        {
            var command = new DeleteLearningItemCommand(id);
            var result = await sender.Send(command);

            if (result.IsFailure)
            {
                return result?.FirstError!.ToProblemDetails();
            };

            return Results.NoContent();

        });

        
    }
}