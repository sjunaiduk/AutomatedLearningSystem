using System.Security.Claims;
using AutomatedLearningSystem.Application.Common.Abstractions;

namespace AutomatedLearningSystem.Infrastructure.Identity;

public class AuthenticatedUserProvider : IAuthenticatedUserProvider
{
    private readonly AuthenticatedUser _user = new();
    public AuthenticatedUser GetAuthenticatedUser()
    {
        return _user;
    }

    public void SetAuthenticatedUser(List<Claim> claims)
    {
        _user.Id = Guid.TryParse((claims.SingleOrDefault(c => c.Type == "sub")?.Value), out var result) ? result :null;
        _user.Role = claims.SingleOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
    }
}