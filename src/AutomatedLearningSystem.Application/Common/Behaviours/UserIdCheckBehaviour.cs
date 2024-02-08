using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Users;
using MediatR;

namespace AutomatedLearningSystem.Application.Common.Behaviours;

public class UserIdCheckBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
        where TRequest : IRequest<TResponse>
        where TResponse : Result
{
    private IAuthenticatedUserProvider _authenticatedUserProvider;

    public UserIdCheckBehaviour(IAuthenticatedUserProvider authenticatedUserProvider)
    {
        _authenticatedUserProvider = authenticatedUserProvider;
    }

    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var type = typeof(TRequest);
        var userId = type.GetProperties()
            .SingleOrDefault(p => p.Name == "UserId" && 
                                  Guid.TryParse(p.GetValue(request).ToString(), out var result));

        if (userId is not null)
        {
            var authenticatedUser = _authenticatedUserProvider.GetAuthenticatedUser();

            if (authenticatedUser.Id != (Guid)userId.GetValue(request)! && authenticatedUser.Role != "admin")
            {
                return (dynamic)UserErrors.UnAuthorized;
            }
        }
      

        return await next();
        
    }
}