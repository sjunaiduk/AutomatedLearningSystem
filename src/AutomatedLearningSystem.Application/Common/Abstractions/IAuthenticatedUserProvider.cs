using System.Security.Claims;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Users;

namespace AutomatedLearningSystem.Application.Common.Abstractions;

public interface IAuthenticatedUserProvider
{
    AuthenticatedUser GetAuthenticatedUser();

    void SetAuthenticatedUser(List<Claim> claims);
}

public class AuthenticatedUser
{
    public Guid? Id { get; set; }

    public string? Role { get; set; }

}