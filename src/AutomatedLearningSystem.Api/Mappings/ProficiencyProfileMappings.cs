using AutomatedLearningSystem.Contracts.Common;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Users;
using InvalidOperationException = System.InvalidOperationException;

namespace AutomatedLearningSystem.Api.Mappings;

public static class ProficiencyProfileMappings
{
    public static UserProficiencyProfile ToUserProficiencyProfile(this UserProficiencyProfileDto profile)
    {
        UserLevel dbLevel = GetDifficultyLevel(profile.Database);
        UserLevel frontendLevel = GetDifficultyLevel(profile.Frontend);
        UserLevel backendLevel = GetDifficultyLevel(profile.Backend);

        return new UserProficiencyProfile
        {
            DatabaseLevel = dbLevel,
            FrontEndLevel = frontendLevel,
            BackEndLevel = backendLevel
        };

    }

    public static UserLevel GetDifficultyLevel(UserLevelDto levelDto)
    {
        return levelDto switch
        {
            UserLevelDto.Beginner => UserLevel.Beginner,
            UserLevelDto.Intermediate => UserLevel.Intermediate,
            UserLevelDto.Advanced => UserLevel.Advanced,
            _ => throw new InvalidOperationException()

        };
    }
}