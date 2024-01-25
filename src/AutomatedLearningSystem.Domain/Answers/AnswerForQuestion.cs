using System.Dynamic;
using AutomatedLearningSystem.Domain.Questions;

namespace AutomatedLearningSystem.Domain.Answers;

public class AnswerForQuestion
{

    private const int _minScale = 1;
    private const int _maxScale = 5;
    public Guid Id { get; private set; }


    // set to protected and only allow unit test project to set this.
    public Question Question { get; set; } = null!;

    public int Response { get; private set; }

    public DateTimeOffset AddedDateTime { get; private set; }


  
    private AnswerForQuestion()
    {

    }

    private AnswerForQuestion(int response)
    {
        Response = response;
        AddedDateTime = DateTimeOffset.Now;

    }

    
    public static AnswerForQuestion Create(int response)
    {
        if (response < _minScale || response > _maxScale)
        {
            throw new ArgumentException($"User answer is not in the range {_minScale}" +
                                        $"-{_maxScale}");
        }

        return new AnswerForQuestion(response);
    }

}