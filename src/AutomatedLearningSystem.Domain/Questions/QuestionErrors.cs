using AutomatedLearningSystem.Domain.Common;

namespace AutomatedLearningSystem.Domain.Questions;

public static class QuestionErrors
{
    public static Error NotFound => new("Question.NotFound", "Question was not found", ErrorType.NotFound);
}