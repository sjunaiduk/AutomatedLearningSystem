using MediatR;

namespace AutomatedLearningSystem.Domain.Common;

public interface ICommand : IRequest
{
    
}

public interface ICommand<out TResponse> : IRequest<TResponse>
{

}