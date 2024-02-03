using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Questions;

namespace AutomatedLearningSystem.Application.Questions.Queries.GetQuestions;

public record GetQuestionsQuery() : IQuery<IEnumerable<Question>> {}