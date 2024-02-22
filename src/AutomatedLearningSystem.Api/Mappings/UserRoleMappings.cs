using AutomatedLearningSystem.Contracts.Users;
using AutomatedLearningSystem.Domain.Users;
namespace AutomatedLearningSystem.Api.Mappings;

public static class UserRoleMappings
{
    public static Role MapToDomainRole(this RoleDto roleDto)
    {
        return roleDto switch
        {
            RoleDto.Student => Role.Student,
            RoleDto.Admin => Role.Admin,
            _ => throw new ArgumentOutOfRangeException(nameof(roleDto), roleDto, null)
        };
    }

    public static RoleDto MapToUiRole(this Role userRole)
    {
        return userRole switch
        {
            Role.Admin => RoleDto.Admin,
            Role.Student => RoleDto.Student,
            _ => throw new ArgumentOutOfRangeException(nameof(userRole), userRole, null)

        };
    }
}