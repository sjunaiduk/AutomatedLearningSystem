using MediatR;

namespace AutomatedLearningSystem.Domain.Common;

public interface IQuery<out TResult> : IRequest<TResult> { }