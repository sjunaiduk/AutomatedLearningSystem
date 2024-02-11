using System.Net;
using System.Net.Http.Json;
using AutomatedLearningSystem.Api.Endpoints;
using AutomatedLearningSystem.Contracts.AnswersForQuestions;
using AutomatedLearningSystem.Contracts.Common;
using AutomatedLearningSystem.Contracts.LearningPaths;
using AutomatedLearningSystem.Contracts.Questionnaire;
using AutomatedLearningSystem.Contracts.Users;
using AutomatedLearningSystem.Domain.LearningItems;
using AutomatedLearningSystem.Domain.LearningPaths;
using AutomatedLearningSystem.Domain.Questions;
using AutomatedLearningSystem.Domain.Users;
using AutomatedLearningSystem.FunctionalTests.Infrastructure;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using TestCommon.Constants;
using TestCommon.Factories;

namespace AutomatedLearningSystem.FunctionalTests.LearningPaths;

public class GetLearningPathsTest(FunctionalTestWebApplicationFactory factory) : BaseFunctionalTest(factory)
{
    [Fact]

    public async void GetLearningPaths_ShouldReturnOk()
    {
        // Act

        var result = await HttpClient.GetAsync(Routes.LearningPaths.GetAll);

        // Assert

        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]

    public async void GetLearningPaths_ShouldReturnLearningPaths_WhenLearningPathsExist()
    {
        // Arrange
        await SetAdminCookie();
        var question = await DbContext.Set<Question>().FirstAsync();
        var answers = AnswerForQuestionFactory.CreateMany(question, 1, AdminUser!.Id);
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

        var generateLearningPathResult =  await HttpClient.PostAsJsonAsync($"/api/users/{AdminUser!.Id}/learning-paths", request);
        generateLearningPathResult.StatusCode.Should().Be(HttpStatusCode.Created);

        // Act
        var learningPaths = await HttpClient.GetFromJsonAsync<LearningPathsResponse>(Routes.LearningPaths.GetAll);

        // Assert
        learningPaths?.LearningPaths.Count.Should().NotBe(0);
        learningPaths?.LearningPaths.Any(lp => lp.LearningItems.Count == 0).Should().BeFalse();
        learningPaths?.LearningPaths.Any(lp => lp.Id == default).Should().BeFalse();


    }


    [Fact]

    public async void GetLearningPaths_ShouldReturnLearningItems_WhenLearningPathsExist()
    {
        // Arrange
        await SetAdminCookie();
        var question = await DbContext.Set<Question>().FirstAsync();
        var answers = AnswerForQuestionFactory.CreateMany(question, 1, AdminUser!.Id);
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

        var generateLearningPathResult =
            await HttpClient.PostAsJsonAsync($"/api/users/{AdminUser.Id}/learning-paths", request);
        generateLearningPathResult.StatusCode.Should().Be(HttpStatusCode.Created);

        // Act
        var response = await HttpClient.GetFromJsonAsync<LearningPathsResponse>(Routes.LearningPaths.GetAll);

        // Assert
        response?.LearningPaths.Any(lp => lp.LearningItems.Count == 0).Should().BeFalse();
        response?.LearningPaths.SelectMany(lp => lp.LearningItems).All(li =>
            li is not
            {
                Description: null,
                Name: null
            })
            .Should().BeTrue();


    }
}