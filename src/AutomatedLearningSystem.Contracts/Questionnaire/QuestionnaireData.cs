using AutomatedLearningSystem.Contracts.AnswersForQuestions;
using AutomatedLearningSystem.Contracts.Common;

namespace AutomatedLearningSystem.Contracts.Questionnaire;

public class QuestionnaireData
{
    public List<AnswerForQuestionFromUi> Answers { get; init; } = null!;
    public UserProficiencyProfileUi Profile { get; init; } = null!;

    public string LearningPathName { get; init; } = null!;
}