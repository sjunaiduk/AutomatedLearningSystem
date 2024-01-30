using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.Questions;

namespace AutomatedLearningSystem.Infrastructure.Questions.Persistence;

public class QuestionsRepository : IQuestionRepository
{
    public Task<List<Question>> GetAllAsync(CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<Question?> GetByIdAsync(Guid answerQuestionId)
    {
        throw new NotImplementedException();
    }
}