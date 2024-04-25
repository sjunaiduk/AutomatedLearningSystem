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

public class CreateLearningItem : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {

       

        app.MapPost("/api/learning-items", async (CreateLearningItemRequest request,
            ISender sender) =>
        {
            var domainCategory = request.Category switch
            {
                CategoryDto.Backend => Category.Backend,
                CategoryDto.Frontend => Category.Frontend,
                CategoryDto.Database => Category.Database,
                _ => throw new ArgumentException("Invalid category")
            };

            var domainPriority = request.Priority switch
            {
                PriorityDto.High => Priority.High,
                PriorityDto.Medium => Priority.Medium,
                PriorityDto.Low => Priority.Low,
                _ => throw new ArgumentException("Invalid priority")
            };

            var domainUserLevel = request.UserLevel switch
            {
                UserLevelDto.Beginner => UserLevel.Beginner,
                UserLevelDto.Intermediate => UserLevel.Intermediate,
                UserLevelDto.Advanced => UserLevel.Advanced,
                _ => throw new ArgumentException("Invalid user level")
            };

            var command = new CreateLearningItemCommand(request.Name,
                request.Description,
                domainCategory,
                domainPriority,
                domainUserLevel);

            var result = await sender.Send(command);
            return result.MatchAll(
                Results.Created,
                errors => errors.ToProblemDetails());
        });
    }
}