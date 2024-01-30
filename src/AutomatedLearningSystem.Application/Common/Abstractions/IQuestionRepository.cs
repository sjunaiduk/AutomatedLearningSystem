using AutomatedLearningSystem.Domain.Questions;

namespace AutomatedLearningSystem.Application.Common.Abstractions;

public interface IQuestionRepository
{
    Task<List<Question>> GetAllAsync(CancellationToken token = default);
    Task<Question?> GetByIdAsync(Guid answerQuestionId);
}