using AutomatedLearningSystem.Contracts.Users;
using AutomatedLearningSystem.Domain.Users;

namespace AutomatedLearningSystem.Api.Endpoints;

public static class UserRoleExtensions
{
    public static Role MapToRole(this UserRole userRole)
    {
        return userRole switch
        {
            UserRole.Student => Role.Student,
            UserRole.Admin => Role.Admin,
            _ => throw new ArgumentOutOfRangeException(nameof(userRole), userRole, null)
        };
    }
}