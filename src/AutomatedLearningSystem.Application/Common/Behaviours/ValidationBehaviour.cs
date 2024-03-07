using System.Windows.Input;
using AutomatedLearningSystem.Domain.Common;
using FluentValidation;
using MediatR;

namespace AutomatedLearningSystem.Application.Common.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
where TRequest : ICommand<TResponse> where TResponse : Result
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        

        var results = _validators.Select(validator =>
                validator.Validate(request))
            .Where(result => result.IsValid == false)
            .SelectMany(res => res.Errors)
            .Select(error => new Error(error.ErrorCode, error.ErrorMessage,
                ErrorType.Validation))
            .ToList();

        if (!results.Any())
        {
            return await next();
        }

        return (dynamic) results;


    }
}