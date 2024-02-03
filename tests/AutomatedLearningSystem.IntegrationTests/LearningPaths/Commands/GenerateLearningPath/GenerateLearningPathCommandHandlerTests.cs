using AutomatedLearningSystem.Domain.LearningPaths;
using AutomatedLearningSystem.Domain.Questions;
using AutomatedLearningSystem.Domain.Users;
using AutomatedLearningSystem.IntegrationTests.Infrastructure;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using TestCommon.Factories;

namespace AutomatedLearningSystem.IntegrationTests.LearningPaths.Commands.GenerateLearningPath
{
    public class GenerateLearningPathCommandHandlerTests(IntegrationTestWebApplicationFactory factory) : BaseIntegrationTest(factory)
    {

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

        [Fact]
        public async Task Generate_ShouldReturnError_WhenLearningPathCountReachesLimit()
        {
            // Arrange
            var user = await DbContext.Set<User>().FirstAsync();
            var question = await DbContext.Set<Question>().FirstAsync();
            var answers = AnswerForQuestionFactory.CreateMany(question, 1, user.Id);
            var profile = UserProficiencyProfileFactory.Create();
            var command = GenerateLearningPathCommandFactory.Create(user.Id, question, answers, profile);

            // Act
            await Sender.Send(command);
            await Sender.Send(command);
            await Sender.Send(command);
            var result = await Sender.Send(command);


            // Assert
            result.IsFailure.Should().BeTrue();
            result.FirstError.Should().Be(LearningPathErrors.LearningPathLimitReached);
        }
    }
}
