﻿using AutomatedLearningSystem.Api.Mappings;
using AutomatedLearningSystem.Application.LearningPaths.Commands.GenerateLearningPath;
using AutomatedLearningSystem.Contracts.Questionnaire;
using AutomatedLearningSystem.Domain.Answers;
using AutomatedLearningSystem.Infrastructure.Identity;
using MediatR;

namespace AutomatedLearningSystem.Api.Endpoints.LearningPaths;

public class GenerateLearningPath : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(Routes.User.LearningPaths.Create,
            async (HttpContext context,
                Guid userId,
                ISender sender,
                QuestionnaireData request,
                ILogger<GenerateLearningPath> Logger) =>
        {
            Logger.LogInformation("Generating learning path");
            var answers = request.Answers.Select(x =>
                    AnswerForQuestion.Create(x.Answer, x.QuestionId, userId))
            .ToList();
            var profile = request.Profile.ToUserProficiencyProfile();
            GenerateLearningPathCommand command = new(userId, answers, profile, request.LearningPathName);

            var result = await sender.Send(command);

            return result.MatchAll(Results.Created, errors => errors.ToProblemDetails());
        }).RequireAuthorization(AuthConstants.Policies.Protected); ;
    }


}

