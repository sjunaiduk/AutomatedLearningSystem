using AutomatedLearningSystem.Contracts.AnswersForQuestions;
using AutomatedLearningSystem.Contracts.Common;

namespace AutomatedLearningSystem.Contracts.Questionnaire;

public class QuestionnaireData
{
    public List<AnswerForQuestionFromUi> Answers { get; init; }
    public UserProficiencyProfileUi Profile { get; init; }

    public string LearningPathName { get; init; }
}