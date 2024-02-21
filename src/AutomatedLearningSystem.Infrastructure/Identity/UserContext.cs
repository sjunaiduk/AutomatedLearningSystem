using System.Security.Claims;
using AutomatedLearningSystem.Application.Common.Abstractions;
using Microsoft.AspNetCore.Http;

namespace AutomatedLearningSystem.Infrastructure.Identity;


public class UserContext : IUserContext
{

    public UserContext(IHttpContextAccessor accessor, Guid? id = null, string? role = null)
    {
        if (id is not null)
        {
            Id = (Guid)id;
        }
        else
        {
            Id = Guid.TryParse(accessor.HttpContext?.User.FindFirst("sub")?.Value, out var result)
                ? result
                : throw new InvalidOperationException("Cannot access user context of unauthenticated user");

        }

        if (role is not null)
        {
            Role = role;
            return;
        }
        var roleFromContext = accessor.HttpContext?.User.FindFirst(ClaimTypes.Role)?.Value;

        Role = roleFromContext ?? throw new InvalidOperationException("Cannot access user context of unauthenticated user");
    }

   
    public Guid Id { get; set; }

    public string Role { get; set; }

    public bool IsAdmin => Role == "admin";

}