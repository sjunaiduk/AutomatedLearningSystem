using System.Reflection;

namespace AutomatedLearningSystem.Api.Endpoints.Users;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {

        var assembly = Assembly.GetExecutingAssembly();
        var endpoints = assembly.GetTypes()
            .Where(type => typeof(IEndpoint).IsAssignableFrom(type)
            && !type.IsInterface)
            .ToList();

        foreach (var type in endpoints)
        {
            var endpoint = (IEndpoint)Activator.CreateInstance(type);
            endpoint.MapEndpoint(app);
        }
    }
}