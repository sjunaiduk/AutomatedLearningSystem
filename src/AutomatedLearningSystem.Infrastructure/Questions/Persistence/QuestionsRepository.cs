using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.Questions;
using AutomatedLearningSystem.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AutomatedLearningSystem.Infrastructure.Questions.Persistence;

public class QuestionsRepository : IQuestionRepository
{

    private readonly AutomatedLearningSystemDbContext _db;

    public QuestionsRepository(AutomatedLearningSystemDbContext db)
    {
        _db = db;
    }

    public Task<List<Question>> GetAllAsync(CancellationToken token = default)
    {
        return _db.Set<Question>()
            .ToListAsync(token);
    }

    public Task<Question?> GetByIdAsync(Guid answerQuestionId)
    {
        return _db.Set<Question>()
            .Where(x => x.Id == answerQuestionId)
            .FirstOrDefaultAsync();
    }
}