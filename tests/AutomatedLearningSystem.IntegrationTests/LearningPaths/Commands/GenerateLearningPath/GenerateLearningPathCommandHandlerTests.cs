using AutomatedLearningSystem.Domain.Questions;
using AutomatedLearningSystem.Domain.Users;
using AutomatedLearningSystem.IntegrationTests.Infrastructure;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using TestCommon.Factories;

namespace AutomatedLearningSystem.IntegrationTests.LearningPaths.Commands.GenerateLearningPath
{
    public class GenerateLearningPathCommandHandlerTests : BaseIntegrationTest
    {
        public GenerateLearningPathCommandHandlerTests(IntegrationTestWebApplicationFactory factory) : base(factory)
        {
        }

        [Fact]

        public async Task Generate_WhenValidData_ShouldCreateLearningPath()
        {
            // Arrange
            var user = await DbContext.Set<User>().FirstAsync();
            var question = await DbContext.Set<Question>().FirstAsync();
            var answers = AnswerForQuestionFactory.CreateMany(question, 1, user.Id);
            var profile = UserProficiencyProfileFactory.Create();
            var command = GenerateLearningPathCommandFactory.Create(user.Id, question, answers, profile);

            // Act
            var result = await Sender.Send(command);

            // Assert
            user.LearningPaths.Count.Should().Be(1);
            DbContext.Set<User>().Include(x => x.LearningPaths)
                .First(x => x.Id == user.Id)
                .LearningPaths.Count.Should().Be(1);
            result.IsSuccess.Should().BeTrue();
        }
    }
}
