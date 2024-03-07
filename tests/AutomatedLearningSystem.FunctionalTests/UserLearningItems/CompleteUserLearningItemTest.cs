using AutomatedLearningSystem.Contracts.AnswersForQuestions;
using AutomatedLearningSystem.Contracts.Common;
using AutomatedLearningSystem.Contracts.Questionnaire;
using AutomatedLearningSystem.Domain.Questions;
using AutomatedLearningSystem.FunctionalTests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using AutomatedLearningSystem.Domain.Users;
using FluentAssertions;
using TestCommon.Constants;
using TestCommon.Factories;

namespace AutomatedLearningSystem.FunctionalTests.UserLearningItems;

public class CompleteUserLearningItemTest : BaseFunctionalTest
{
    public CompleteUserLearningItemTest(FunctionalTestWebApplicationFactory factory) : base(factory)
    {
    }

    [Fact]

    public async void CompleteUserLearningItem_WhenLearningItemCompleted_CompletedPropertyShouldBeTrue()
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

        await HttpClient.PostAsJsonAsync($"/api/users/{AdminUser!.Id}/learning-paths", request);

        var userLearningItem = await DbContext.Set<User>()
            .Where(u => u.Id == AdminUser.Id)
            .Include(u => u.LearningPaths)
            .ThenInclude(lp => lp.UserLearningItems)
            .SelectMany(u => u.LearningPaths.SelectMany(lp => lp.UserLearningItems))
            .FirstAsync();

        // Act
        await HttpClient.PutAsync($"/api/user-learning-items/{userLearningItem.Id}", default);

        // Assert
        await DbContext.Entry(userLearningItem).ReloadAsync();
        userLearningItem.Completed.Should().BeTrue();


    }


}