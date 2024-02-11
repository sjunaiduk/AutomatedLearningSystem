using AutomatedLearningSystem.Domain.Answers;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Users;

namespace AutomatedLearningSystem.Application.LearningPaths.Commands.GenerateLearningPath;

public record GenerateLearningPathCommand(Guid UserId,
    List<AnswerForQuestion> AnswersForQuestions,
    UserProficiencyProfile Profile,
    string LearningPathName) : ICommand<Result>
{ }