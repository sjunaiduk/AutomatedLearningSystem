﻿using System.Net;
using System.Net.Http.Json;
using AutomatedLearningSystem.Contracts.AnswersForQuestions;
using AutomatedLearningSystem.Contracts.Common;
using AutomatedLearningSystem.Contracts.Questionnaire;
using AutomatedLearningSystem.Domain.LearningPaths;
using AutomatedLearningSystem.Domain.Questions;
using AutomatedLearningSystem.Domain.Users;
using AutomatedLearningSystem.FunctionalTests.Infrastructure;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCommon.Constants;
using TestCommon.Factories;

namespace AutomatedLearningSystem.FunctionalTests.LearningPaths;

public class GenerateLearningPathTests : BaseFunctionalTest
{

    public GenerateLearningPathTests(FunctionalTestWebApplicationFactory factory) : base(factory, [ClaimConstants.AdminRole])
    {
    }

    [Fact]
    public async Task Handler_ShouldReturnError_WhenUserHasMaxLearningPaths()
    {
        // Arrange
        var user = await DbContext.Set<User>().FirstAsync();
        var question = await DbContext.Set<Question>().FirstAsync();
        var answers = AnswerForQuestionFactory.CreateMany(question, 1, user.Id);
        var request = new QuestionnaireData
        {
            Profile = new UserProficiencyProfileUi()
            {
                Backend = default,
                Database = default,
                Frontend = default
            },
            Answers = answers.Select(a => new AnswerForQuestionFromUi()
            {
                Answer = a.Answer,
                QuestionId = a.QuestionId
            }).ToList()
        };

        // Act
        await HttpClient.PostAsJsonAsync($"/api/users/{user.Id}/learning-paths", request);
        await HttpClient.PostAsJsonAsync($"/api/users/{user.Id}/learning-paths", request);
        await HttpClient.PostAsJsonAsync($"/api/users/{user.Id}/learning-paths", request);
        var result = await HttpClient.PostAsJsonAsync($"/api/users/{user.Id}/learning-paths", request);

        // Assert

        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var response = await result.Content.ReadFromJsonAsync<ProblemDetails>();
        response.Should().NotBeNull();
        response?.Title.Should().Be(LearningPathErrors.LearningPathLimitReached.Code);
        response?.Detail.Should().Be(LearningPathErrors.LearningPathLimitReached.Description);
    }


}