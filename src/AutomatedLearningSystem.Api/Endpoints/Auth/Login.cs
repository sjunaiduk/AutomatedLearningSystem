using System.Security.Claims;
using AutomatedLearningSystem.Api.Mappings;
using AutomatedLearningSystem.Application.Auth.Login;
using AutomatedLearningSystem.Application.Users.Queries.GetUser;
using AutomatedLearningSystem.Contracts.Login;
using AutomatedLearningSystem.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Authentication;

namespace AutomatedLearningSystem.Api.Endpoints.Auth;

public class Login : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/auth/login", async (HttpContext context, ISender sender, 
            LoginRequest request) =>
        {
            var query = new LoginQuery(request.Email, request.Password);
            var result = await sender.Send(query);

            if (result.IsFailure)
            {
                return result?.FirstError?.ToProblemDetails();
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role, result.Value.Role switch
                {
                    Role.Admin => "admin",
                    Role.Student => "student",
                    _ => throw new InvalidOperationException()
                })
            };
            var identity = new ClaimsIdentity(claims, "cookie");
            var principal = new ClaimsPrincipal(identity);
            await context.SignInAsync("cookie", principal);
            return Results.Ok();
        });
    }
}