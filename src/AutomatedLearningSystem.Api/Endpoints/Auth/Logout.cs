

using AutomatedLearningSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication;

namespace AutomatedLearningSystem.Api.Endpoints.Auth;

public class Logout : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(Routes.Logout, async (HttpContext ctx) => {
            await ctx.SignOutAsync(AuthConstants.DefaultCookieScheme);
        });
    }
}
