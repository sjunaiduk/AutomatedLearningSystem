using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Users;
using TestCommon.Constants;

namespace TestCommon.Factories;

public static class UserProficiencyProfileFactory
{
    public static UserProficiencyProfile Create(UserLevel? frontendLevel = null,
        UserLevel? backendLevel = null,
        UserLevel? databaseLevel = null)
    {
        return new UserProficiencyProfile
        {
            FrontEndLevel = frontendLevel ?? UserProficiencyProfileConstants.FrontEndLevel,
            BackEndLevel = backendLevel ?? UserProficiencyProfileConstants.BackEndLevel,
            DatabaseLevel = databaseLevel ?? UserProficiencyProfileConstants.DatabaseLevel
        };
    }
}