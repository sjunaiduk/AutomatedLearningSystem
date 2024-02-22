using System.Security.Claims;
using AutomatedLearningSystem.Api.Mappings;
using AutomatedLearningSystem.Application.Auth.Login;
using AutomatedLearningSystem.Application.Users.Queries.GetUser;
using AutomatedLearningSystem.Contracts.Login;
using AutomatedLearningSystem.Contracts.Users;
using AutomatedLearningSystem.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using SQLitePCL;

namespace AutomatedLearningSystem.Api.Endpoints.Auth;

public class Login : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(Routes.Login, async (HttpContext context, ISender sender,
            LoginRequest request) =>
        {
            var query = new LoginQuery(request.Email, request.Password);
            var loginResult
             = await sender.Send(query);

            if (loginResult
            .IsFailure)
            {
                return loginResult
                ?.FirstError?.ToProblemDetails();
            }

            var claims = new List<Claim>()
            {
                new(ClaimTypes.Role, loginResult
                .Value.Role switch
                {
                    Role.Admin => "admin",
                    Role.Student => "student",
                    _ => throw new InvalidOperationException()
                }),
                new("sub",loginResult
                .Value.Id.ToString())
            };
            var identity = new ClaimsIdentity(claims, "cookie");
            var principal = new ClaimsPrincipal(identity);
            await context.SignInAsync("cookie", principal);
            var user = loginResult.Value;
            return Results.Ok(new LoginResponse
            {
                Id = user.Id,
                Role = user.Role switch
                {
                    Role.Admin => UserRole.Admin,
                    Role.Student => UserRole.Student,
                    _ => throw new InvalidOperationException()
                },
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email

            });
        });
    }
}