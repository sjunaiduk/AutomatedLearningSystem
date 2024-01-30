using System.Dynamic;
using AutomatedLearningSystem.Domain.Questions;
using AutomatedLearningSystem.Domain.Users;

namespace AutomatedLearningSystem.Domain.Answers;

public class AnswerForQuestion
{

    private const int _minScale = 1;
    private const int _maxScale = 5;
    public Guid Id { get; private set; }

    public Guid UserId { get; private set; }
    // set to protected and only allow unit test project to set this.
    internal Question Question { get; set; } = null!;

    public Guid QuestionId { get; private set; }
    public int Answer { get; private set; }

    public DateTimeOffset AddedDateTime { get; private set; }


  
    private AnswerForQuestion()
    {

    }

    private AnswerForQuestion(int answer, Guid questionId, Guid userId)
    {
        Answer = answer;
        AddedDateTime = DateTimeOffset.Now;
        QuestionId = questionId;
        UserId = userId;

    }

    
    public static AnswerForQuestion Create(int response, Guid questionId,
        Guid userId)
    {
        if (response < _minScale || response > _maxScale)
        {
            throw new ArgumentException($"User answer is not in the range {_minScale}" +
                                        $"-{_maxScale}");
        }

        return new AnswerForQuestion(response, questionId,
            userId);
    }

}