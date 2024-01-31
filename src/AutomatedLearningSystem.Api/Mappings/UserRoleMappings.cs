using AutomatedLearningSystem.Contracts.Users;
using AutomatedLearningSystem.Domain.Users;
namespace AutomatedLearningSystem.Api.Mappings;

public static class UserRoleMappings
{
    public static Role MapToDomainRole(this UserRole userRole)
    {
        return userRole switch
        {
            UserRole.Student => Role.Student,
            UserRole.Admin => Role.Admin,
            _ => throw new ArgumentOutOfRangeException(nameof(userRole), userRole, null)
        };
    }

    public static UserRole MapToUiRole(this Role userRole)
    {
        return userRole switch
        {
            Role.Admin => UserRole.Admin,
            Role.Student => UserRole.Student,
            _ => throw new ArgumentOutOfRangeException(nameof(userRole), userRole, null)

        };
    }
}