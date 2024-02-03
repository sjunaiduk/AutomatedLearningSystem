﻿using AutomatedLearningSystem.Api.Mappings;
using AutomatedLearningSystem.Application.LearningPaths.Commands.GenerateLearningPath;
using AutomatedLearningSystem.Contracts.Questionnaire;
using AutomatedLearningSystem.Domain.Answers;
using MediatR;

namespace AutomatedLearningSystem.Api.Endpoints.LearningPaths;

public class GenerateLearningPath : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(Routes.User.LearningPaths.Create, async (Guid userId, ISender sender, QuestionnaireData request) =>
        {
            var answers = request.Answers.Select(x => 
                    AnswerForQuestion.Create(x.Answer, x.QuestionId, userId))
            .ToList();
            var profile = request.Profile.ToUserProficiencyProfile();
            GenerateLearningPathCommand command = new(userId, answers, profile);

            var result = await sender.Send(command);

            return result.MatchAll(Results.Created, errors => errors.ToProblemDetails());
        });
    }

 
}
