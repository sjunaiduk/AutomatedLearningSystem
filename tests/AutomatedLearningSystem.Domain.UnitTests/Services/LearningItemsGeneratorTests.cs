using AutomatedLearningSystem.Domain.Answers;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Questions;
using AutomatedLearningSystem.Domain.Services;
using AutomatedLearningSystem.Domain.Users;
using FluentAssertions;
using TestCommon.Constants;
using TestCommon.Factories;

namespace AutomatedLearningSystem.Domain.UnitTests.Services;

public class LearningItemsGeneratorTests
{
    [Fact]

    public void Generate_WhenUserPrefersACategory_ShouldIncludeCategoryInFinalList()
    {
        // Arrange
        var preferredLearningItem = LearningItemFactory.Create(category: Category.Database);
        var otherLearningItems = LearningItemFactory.Create(category: Category.Backend, count: 3);
     

        var answer = AnswerForQuestion.Create(5);
        answer.Question = Question.Create("x", Category.Database);
        var otherQuestion = Question.Create("x", Category.Backend);

        var allAnswers = Enumerable.Range(0, 3)
            .Select(x =>
            {
                var otherAnswer = AnswerForQuestion.Create(2);
                otherAnswer.Question = otherQuestion;
                return otherAnswer;
            }).ToList();

        allAnswers.Add(answer);

        var service = new LearningItemsGenerator();
        var inputItems = preferredLearningItem.Concat(otherLearningItems).ToList();
        var inputAnswers = allAnswers;
        var userProfile = new UserProficiencyProfile
        {
            BackEndLevel = DifficultyLevel.Beginner,
            FrontEndLevel = DifficultyLevel.Beginner,
            DatabaseLevel = DifficultyLevel.Beginner
        };

        // Act

        // the input items are a shallow copy of what we arranged...
        var personalizedItems = service.Generate(inputAnswers,
            inputItems,
            userProfile);

        var firstItem = personalizedItems.First();
        
        // Assert
        firstItem.Id.Should().Be(preferredLearningItem.First().Id);



    }
}