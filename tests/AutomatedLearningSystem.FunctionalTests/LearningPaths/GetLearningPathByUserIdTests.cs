using System.Net;
using System.Net.Http.Json;
using AutomatedLearningSystem.Contracts.AnswersForQuestions;
using AutomatedLearningSystem.Contracts.Common;
using AutomatedLearningSystem.Contracts.LearningPaths;
using AutomatedLearningSystem.Contracts.Questionnaire;
using AutomatedLearningSystem.Domain.Questions;
using AutomatedLearningSystem.Domain.Users;
using AutomatedLearningSystem.FunctionalTests.Infrastructure;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using TestCommon.Constants;
using TestCommon.Factories;

namespace AutomatedLearningSystem.FunctionalTests.LearningPaths;



public class GetLearningPathByUserIdTests(FunctionalTestWebApplicationFactory factory) : BaseFunctionalTest(factory)
{

    [Fact]

    public async void GetLearningPathsForUserId_ShouldReturnLearningPaths_WhenLearningPathsExist()
    {
        // Arrange
        await SetAdminCookie();
        var question = await DbContext.Set<Question>().FirstAsync();
        var answers = AnswerForQuestionFactory.CreateMany(question, 1, AdminUser!.Id);
        var request = new QuestionnaireData
        {
            Profile = new UserProficiencyProfileDto()
            {
                Backend = default,
                Database = default,
                Frontend = default
            },
            Answers = answers.Select(a => new AnswerForQuestionDto()
            {
                Answer = a.Answer,
                QuestionId = a.QuestionId
            }).ToList(),
            LearningPathName = LearningPathConstants.Name
        };

        var generateLearningPathResult = await HttpClient.PostAsJsonAsync($"/api/users/{AdminUser!.Id}/learning-paths", request);
        generateLearningPathResult.StatusCode.Should().Be(HttpStatusCode.Created);

        // Act
        var learningPaths = await HttpClient.GetFromJsonAsync<List<LearningPathResponse>>($"/api/users/{AdminUser.Id}/learning-paths");
        // Assert
        learningPaths?.Count.Should().NotBe(0);
        learningPaths?.Any(lp => lp.UserLearningItems.Count == 0).Should().BeFalse();
        learningPaths?.Any(lp => lp.Id == default).Should().BeFalse();
        learningPaths!.Any(lp => lp.Name == LearningPathConstants.Name).Should()
            .BeTrue();


    }

    [Fact]

    public async Task GetLearningPathByUserId_ShouldReturnEmptyArray_WhenNoLearningPathsExist()
    {
        // Arrange
        var nonAdmin = await DbContext.Set<User>().FirstAsync(user => user.Role != Role.Admin);

        // Act
        var nonAdminLearningPaths = await HttpClient.GetFromJsonAsync<List<LearningPathResponse>>($"/api/users/{nonAdmin.Id}/learning-paths");

        // Assert
        nonAdminLearningPaths!.Count.Should().Be(0);


    }


}
