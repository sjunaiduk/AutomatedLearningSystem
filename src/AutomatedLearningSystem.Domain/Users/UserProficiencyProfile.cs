using AutomatedLearningSystem.Domain.Common;

namespace AutomatedLearningSystem.Domain.Users;
public class UserProficiencyProfile
{
    public DifficultyLevel BackEndLevel { get; set; }
    public DifficultyLevel FrontEndLevel { get; set; }
    public DifficultyLevel DatabaseLevel { get; set; }

}
