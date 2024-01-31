using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Questions;
using TestCommon.Constants;

namespace TestCommon.Factories;

public static class QuestionFactory
{
    public static Question Create(Guid? id = null, string? description = null,
        Category? category = null)
    {
        return Question.Create(description ?? QuestionConstants.Description,
            category ?? QuestionConstants.Category,
            id ?? Guid.NewGuid());
    }
}