using AutomatedLearningSystem.Domain.Answers;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.LearningItems.Services;
using FluentAssertions;
using TestCommon.Factories;

namespace AutomatedLearningSystem.Domain.UnitTests.LearningItems.Services;

public class LearningItemsGeneratorServiceTests
{
    [Fact]

    public void Generate_WhenUserPrefersACategory_ShouldIncludeCategoryInFinalList()
    {
        // We are setting our rating for a Database question to 5
        // For 3 other backend questions we rate it a 2.
        // Proficiency profile is beginner.
        // We expect the first topic to be generated to be a database topic.


        // Arrange
        var preferredLearningItem = LearningItemFactory.CreateMany(category: Category.Database);
        var otherLearningItems = LearningItemFactory.CreateMany(category: Category.Backend, count: 3);
        var allLearningItems = preferredLearningItem.Concat(otherLearningItems).ToList();

        var databaseQuestion = QuestionFactory.Create(category: Category.Database);
        var otherQuestion = QuestionFactory.Create(category: Category.Backend);

        var databaseQuestionAnswer = AnswerForQuestionFactory.Create(databaseQuestion, answer: 5);
        var allAnswers = AnswerForQuestionFactory.CreateMany(otherQuestion,
            answer: 2,
            count: 3);
        allAnswers.Add(databaseQuestionAnswer);


        var userProfile = UserProficiencyProfileFactory.Create();

        // Act

        var personalizedItems = LearningItemsGeneratorService.Generate(allAnswers,
            allLearningItems,
            userProfile);


        // Assert
        var firstItem = personalizedItems.First();

        firstItem.Id.Should().Be(preferredLearningItem.First().Id);

    }

    [Fact]

    public void Generate_LearningItemDifficultyGreaterThanOrEqualToUserProfile_ShouldBeInFinalList()
    {

        // We are setting our rating for every question to 3
        // We have one database learning item with advanced difficulty (User is Advanced)
        // We have backend learning items with Beginner difficulty (User is Intermediate)
        // The advanced learning item should be first.


        // Arrange
        var preferredLearningItem = LearningItemFactory.CreateMany(category: Category.Database,
            difficulty: DifficultyLevel.Advanced);
        var otherLearningItems = LearningItemFactory.CreateMany(category: Category.Backend, count: 3,
            difficulty: DifficultyLevel.Beginner);
        var allLearningItems = preferredLearningItem.Concat(otherLearningItems).ToList();

        var databaseQuestion = QuestionFactory.Create(category: Category.Database);
        var otherQuestion = QuestionFactory.Create(category: Category.Backend);

        var databaseQuestionAnswer = AnswerForQuestionFactory.Create(databaseQuestion, answer: 3);
        var allAnswers = AnswerForQuestionFactory.CreateMany(otherQuestion,
            answer: 3,
            count: 3);
        allAnswers.Add(databaseQuestionAnswer);


        var userProfile = UserProficiencyProfileFactory.Create(databaseLevel: DifficultyLevel.Advanced,
            backendLevel: DifficultyLevel.Intermediate,
            frontendLevel: DifficultyLevel.Intermediate);

        // Act

        var personalizedItems = LearningItemsGeneratorService.Generate(allAnswers,
            allLearningItems,
            userProfile);


        // Assert
        var firstItem = personalizedItems.First();

        firstItem.Id.Should().Be(preferredLearningItem.First().Id);


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
        var preferredLearningItem = LearningItemFactory.CreateMany(category: Category.Database,
            difficulty: DifficultyLevel.Advanced);
        var otherLearningItems = LearningItemFactory.CreateMany(category: Category.Backend, count: 3,
            difficulty: DifficultyLevel.Intermediate,
            priority: Priority.High);
        var allLearningItems = preferredLearningItem.Concat(otherLearningItems).ToList();

        var databaseQuestion = QuestionFactory.Create(category: Category.Database);
        var otherQuestion = QuestionFactory.Create(category: Category.Backend);

        var databaseQuestionAnswer = AnswerForQuestionFactory.Create(databaseQuestion, answer: 3);
        var allAnswers = AnswerForQuestionFactory.CreateMany(otherQuestion,
            answer: 3,
            count: 3);
        allAnswers.Add(databaseQuestionAnswer);


        var userProfile = UserProficiencyProfileFactory.Create(databaseLevel: DifficultyLevel.Advanced,
            backendLevel: DifficultyLevel.Intermediate);

        // Act

        var personalizedItems = LearningItemsGeneratorService.Generate(allAnswers,
            allLearningItems,
            userProfile);


        // Assert
        var firstItem = personalizedItems.First();

        firstItem.Id.Should().NotBe(preferredLearningItem.First().Id);
        firstItem.Category.Should().Be(Category.Backend);

    }

    [Fact]

    public void Generate_WeHaveMoreThanRequiredLearningItems_ShouldIncludeOnlyMaxLearningItems()
    {

        // Arrange
        var preferredLearningItem = LearningItemFactory.CreateMany(category: Category.Database,
            difficulty: DifficultyLevel.Advanced);
        var otherLearningItems = LearningItemFactory.CreateMany(category: Category.Backend, count: 20,
            difficulty: DifficultyLevel.Intermediate,
            priority: Priority.High);
        var allLearningItems = preferredLearningItem.Concat(otherLearningItems).ToList();

        var databaseQuestion = QuestionFactory.Create(category: Category.Database);
        var otherQuestion = QuestionFactory.Create(category: Category.Backend);

        var databaseQuestionAnswer = AnswerForQuestionFactory.Create(databaseQuestion, answer: 3);
        var allAnswers = AnswerForQuestionFactory.CreateMany(otherQuestion,
            answer: 3,
            count: 3);
        allAnswers.Add(databaseQuestionAnswer);


        var userProfile = UserProficiencyProfileFactory.Create(databaseLevel: DifficultyLevel.Advanced,
            backendLevel: DifficultyLevel.Intermediate);

        // Act

        var personalizedItems = LearningItemsGeneratorService.Generate(allAnswers,
            allLearningItems,
            userProfile);


        // Assert
        var firstItem = personalizedItems.First();

        firstItem.Id.Should().NotBe(preferredLearningItem.First().Id);
        firstItem.Category.Should().Be(Category.Backend);
        personalizedItems.Count.Should().Be(10);

    }



    [Fact]

    public void Generate_ShouldOrderByPriority()
    {

        // Arrange
        var databaseLearningItems = LearningItemFactory.CreateMany(category: Category.Database,
            difficulty: DifficultyLevel.Advanced,
            priority: Priority.Low);
        var backendLearningItems = LearningItemFactory.CreateMany(category: Category.Backend,
            difficulty: DifficultyLevel.Intermediate,
            priority: Priority.Medium);
        var frontendLearningItems = LearningItemFactory.CreateMany(category: Category.Frontend,
            count: 1,
            priority: Priority.High);
        var allLearningItems = databaseLearningItems.Concat(backendLearningItems)
            .Concat(frontendLearningItems)
            .ToList();

        var databaseQuestion = QuestionFactory.Create(category: Category.Database);
        var backendQuestion = QuestionFactory.Create(category: Category.Backend);
        var frontendQuestion = QuestionFactory.Create(category: Category.Frontend);


        var databaseQuestionAnswer = AnswerForQuestionFactory.Create(databaseQuestion, answer: 3);
        var backendQuestionAnswer = AnswerForQuestionFactory.Create(backendQuestion, answer: 3);
        var frontendQuestionAnswer = AnswerForQuestionFactory.Create(frontendQuestion, answer: 3);

        var allAnswers = new List<AnswerForQuestion>
            { databaseQuestionAnswer, backendQuestionAnswer, frontendQuestionAnswer };


        var userProfile = UserProficiencyProfileFactory.Create(databaseLevel: DifficultyLevel.Advanced,
            backendLevel: DifficultyLevel.Intermediate);

        // Act

        var personalizedItems = LearningItemsGeneratorService.Generate(allAnswers,
            allLearningItems,
            userProfile);


        // Assert
        var firstItem = personalizedItems.First();
        var secondItem = personalizedItems.Skip(1).First();
        var thirdItem = personalizedItems.Skip(2).First();
        firstItem.Category.Should().Be(Category.Frontend);
        secondItem.Category.Should().Be(Category.Backend);
        thirdItem.Category.Should().Be(Category.Database);

    }
}