using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.Questions;
using MediatR;

namespace AutomatedLearningSystem.Application.Questions.Queries.GetQuestions;

public class GetQuestionsQueryHandler(IQuestionRepository _questionRepository) : 
    IRequestHandler<GetQuestionsQuery, IEnumerable<Question>>
{
    public async Task<IEnumerable<Question>> Handle(GetQuestionsQuery request, CancellationToken cancellationToken)
    {
        return await _questionRepository.GetAllAsync(cancellationToken);

    }
}