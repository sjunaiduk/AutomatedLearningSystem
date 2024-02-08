using MediatR;

namespace AutomatedLearningSystem.Domain.Common;

public interface ICommand<out TResponse> : IRequest<TResponse>
{

}