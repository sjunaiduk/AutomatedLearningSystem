using AutomatedLearningSystem.Contracts.AnswersForQuestions;
using AutomatedLearningSystem.Contracts.Common;

namespace AutomatedLearningSystem.Contracts.Questionnaire;

public class QuestionnaireData
{
    public List<AnswerForQuestionDto> Answers { get; init; } = null!;
    public UserProficiencyProfileDto Profile { get; init; } = null!;

    public string LearningPathName { get; init; } = null!;
}