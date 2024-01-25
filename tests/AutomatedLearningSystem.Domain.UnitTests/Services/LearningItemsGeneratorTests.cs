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
        // We are setting our rating for a Database question to 5
        // For 3 other backend questions we rate it a 2.
        // Proficiency profile is beginner.
        // We expect the first topic to be generated to be a database topic.


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

    [Fact]

    public void Generate_WhenUserProficiencyLessThanLearningItemDifficulty_ShouldIncludeLearningItemInFinalList()
    {

        // We are setting our rating for every question to 3
        // We have one database learning item with advanced difficulty (User is Advanced)
        // We have backend learning items with Beginner difficulty (User is Intermediate)
        // The advanced learning item should be first.


        // Arrange
        var preferredLearningItem = LearningItemFactory.Create(category: Category.Database,
            difficulty: DifficultyLevel.Advanced).First();
        var otherLearningItems = LearningItemFactory.Create(category: Category.Backend, count: 3,
            difficulty: DifficultyLevel.Beginner);
        otherLearningItems.Add(preferredLearningItem);

        var answer = AnswerForQuestion.Create(3);
        answer.Question = Question.Create("x", Category.Database);
        var otherQuestion = Question.Create("x", Category.Backend);

        var allAnswers = Enumerable.Range(0, 3)
            .Select(x =>
            {
                var otherAnswer = AnswerForQuestion.Create(3);
                otherAnswer.Question = otherQuestion;
                return otherAnswer;
            }).ToList();

        allAnswers.Add(answer);

        var service = new LearningItemsGenerator();
        var inputItems = otherLearningItems;
        var inputAnswers = allAnswers;
        var userProfile = new UserProficiencyProfile
        {
            BackEndLevel = DifficultyLevel.Intermediate,
            FrontEndLevel = DifficultyLevel.Intermediate,
            DatabaseLevel = DifficultyLevel.Advanced
        };

        // Act
        var personalizedItems = service.Generate(inputAnswers,
            inputItems,
            userProfile);

        var firstItem = personalizedItems.First();

        // Assert
        firstItem.Id.Should().Be(preferredLearningItem.Id);

    }




    [Fact]

    public void Generate_WhenItemPriorityIsHigh_ShouldIncludeLearningItemInFinalList()
    {    
        
        // We are setting our rating for every question to 3
        // We have one database learning item with advanced difficulty (User is Advanced)
        // We have backend learning items with Intermediate difficulty (User is Intermediate)
        // User profile matches all available learning items.
        // The backend learning items have HIGH priority
        // The only database learning item SHOULDNT be first.


        // Arrange
        var preferredLearningItem = LearningItemFactory.Create(category: Category.Database,
            difficulty: DifficultyLevel.Advanced).First();
        var otherLearningItems = LearningItemFactory.Create(category: Category.Backend, count: 3,
            priority: Priority.High,
            difficulty: DifficultyLevel.Intermediate);
        otherLearningItems.Add(preferredLearningItem);

        var answer = AnswerForQuestion.Create(3);
        answer.Question = Question.Create("x", Category.Database);
        var otherQuestion = Question.Create("x", Category.Backend);

        var allAnswers = Enumerable.Range(0, 3)
            .Select(x =>
            {
                var otherAnswer = AnswerForQuestion.Create(3);
                otherAnswer.Question = otherQuestion;
                return otherAnswer;
            }).ToList();

        allAnswers.Add(answer);

        var service = new LearningItemsGenerator();
        var inputItems = otherLearningItems;
        var inputAnswers = allAnswers;
        var userProfile = new UserProficiencyProfile
        {
            BackEndLevel = DifficultyLevel.Intermediate,
            FrontEndLevel = DifficultyLevel.Intermediate,
            DatabaseLevel = DifficultyLevel.Advanced
        };

        // Act
        var personalizedItems = service.Generate(inputAnswers,
            inputItems,
            userProfile);

        var firstItem = personalizedItems.First();

        // Assert
        firstItem.Id.Should().NotBe(preferredLearningItem.Id);

    }
}