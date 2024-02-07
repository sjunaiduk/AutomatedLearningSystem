using AutomatedLearningSystem.Contracts.Common;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Users;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using InvalidOperationException = System.InvalidOperationException;

namespace AutomatedLearningSystem.Api.Mappings;

public static class ProficiencyProfileMappings
{
    public static UserProficiencyProfile ToUserProficiencyProfile(this UserProficiencyProfileUi profile)
    {
        DifficultyLevel dbLevel = GetDifficultyLevel(profile.Database);
        DifficultyLevel frontendLevel = GetDifficultyLevel(profile.Frontend);
        DifficultyLevel backendLevel = GetDifficultyLevel(profile.Backend);

        return new UserProficiencyProfile()
        {
            DatabaseLevel = dbLevel,
            FrontEndLevel = frontendLevel,
            BackEndLevel = backendLevel
        };

    }

    public static DifficultyLevel GetDifficultyLevel(UserLevel level)
    {
        return level switch
        {
            UserLevel.Beginner => DifficultyLevel.Beginner,
            UserLevel.Intermediate => DifficultyLevel.Intermediate,
            UserLevel.Advanced => DifficultyLevel.Advanced,
            _ => throw new InvalidOperationException()

        };
    }
}