using AutomatedLearningSystem.Application.Common.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AutomatedLearningSystem.Infrastructure.Middlewares;

public class AuthenticatedUserProviderMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var userProviderService =
            context.RequestServices.GetRequiredService(
                typeof(IAuthenticatedUserProvider)) as IAuthenticatedUserProvider;

        userProviderService!.SetAuthenticatedUser(context.User.Claims.ToList());

        await next(context);

    }
}