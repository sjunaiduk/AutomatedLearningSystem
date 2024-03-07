using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AutomatedLearningSystem.Application.Common.Behaviours;
using FluentValidation;
using MediatR;

namespace AutomatedLearningSystem.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
        });
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}