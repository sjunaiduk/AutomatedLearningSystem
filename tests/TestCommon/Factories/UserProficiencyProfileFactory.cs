using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Users;
using TestCommon.Constants;

namespace TestCommon.Factories;

public static class UserProficiencyProfileFactory
{
    public static UserProficiencyProfile Create(DifficultyLevel? frontendLevel = null,
        DifficultyLevel? backendLevel = null,
        DifficultyLevel? databaseLevel = null)
    {
        return new UserProficiencyProfile
        {
            FrontEndLevel = frontendLevel ?? UserProficiencyProfileConstants.FrontEndLevel,
            BackEndLevel = backendLevel ?? UserProficiencyProfileConstants.BackEndLevel,
            DatabaseLevel = databaseLevel ?? UserProficiencyProfileConstants.DatabaseLevel
        };
    }
}