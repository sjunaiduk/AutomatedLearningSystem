using System.Reflection;
using AutomatedLearningSystem.Api.Mappings;
using AutomatedLearningSystem.Application.Users.Commands.CreateUser;
using AutomatedLearningSystem.Application.Users.Commands.DeleteUser;
using AutomatedLearningSystem.Application.Users.Queries.GetUser;
using AutomatedLearningSystem.Contracts.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutomatedLearningSystem.Api.Endpoints.Users;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {

        var assembly = Assembly.GetExecutingAssembly();
        var endpoints  = assembly.GetTypes()
            .Where(type => typeof(IEndpoint).IsAssignableFrom(type) 
            && !type.IsInterface)
            .ToList();

        foreach (var type in endpoints)
        {
            var endpoint = (IEndpoint) Activator.CreateInstance(type);
            endpoint.MapEndpoint(app);
        }
    }
}