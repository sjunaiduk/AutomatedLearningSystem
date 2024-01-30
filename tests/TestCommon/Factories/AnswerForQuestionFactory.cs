using AutomatedLearningSystem.Domain.Answers;
using AutomatedLearningSystem.Domain.Questions;
using TestCommon.Constants;

namespace TestCommon.Factories;

public static class AnswerForQuestionFactory
{
    public static AnswerForQuestion Create(
        Question question,
        int answer = AnswerForQuestionConstants.Answer,
        Guid? userId = null)
    {
        var result = AnswerForQuestion.Create(answer,
            question.Id,
            userId ?? AnswerForQuestionConstants.UserId);
        result.Question = question;

        return result;
    }

    public static List<AnswerForQuestion> CreateMany(
        Question? question = null,
        int answer = AnswerForQuestionConstants.Answer,
        Guid? userId = null,
        int count = 5)
    {
        return Enumerable.Range(0, count)
            .Select(x => Create(question ?? QuestionFactory.Create(),
                answer,
                userId ?? AnswerForQuestionConstants.UserId))
            .ToList();
    }
}