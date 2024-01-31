using AutomatedLearningSystem.Application.LearningPaths.Commands.GenerateLearningPath;
using AutomatedLearningSystem.Domain.Answers;
using AutomatedLearningSystem.Domain.Questions;
using AutomatedLearningSystem.Domain.Users;

namespace TestCommon.Factories;

public static class GenerateLearningPathCommandFactory
{
    public static GenerateLearningPathCommand Create(Guid? userId = null,
        Question? question = null,
        List<AnswerForQuestion>? answerForQuestions = null,
        UserProficiencyProfile? profile = null)
    {
        return new GenerateLearningPathCommand(userId ?? Guid.NewGuid(),
            answerForQuestions ?? AnswerForQuestionFactory.CreateMany(question ?? QuestionFactory.Create(), count: 20),
            profile ?? UserProficiencyProfileFactory.Create());
    }
}