using System.Security.Claims;
using AutomatedLearningSystem.Application.Common.Abstractions;
using Microsoft.AspNetCore.Http;

namespace AutomatedLearningSystem.Infrastructure.Identity;


public class UserContext : IUserContext
{

    private readonly IHttpContextAccessor _accessor;
    public UserContext(IHttpContextAccessor accessor, Guid? id = null, string? role = null)
    {
        this._accessor = accessor;
        if (id is not null)
        {
            Id = (Guid)id;
        }
        else
        {
            Id = Guid.TryParse(_accessor.HttpContext?.User.FindFirst("sub")?.Value, out var result)
                ? result
                : throw new InvalidOperationException("Cannot access user context of unauthenticated user");

        }

        if (role is not null)
        {
            Role = role;
            return;
        }
        var roleFromContext = _accessor.HttpContext?.User.FindFirst(ClaimTypes.Role)?.Value;
        if (roleFromContext is null)
        {
            throw new InvalidOperationException("Cannot access user context of unauthenticated user");
        }

        Role = roleFromContext;
    }

   
    public Guid Id { get; set; }

    public string Role { get; set; }

    public bool IsAdmin => Role == "admin";

}