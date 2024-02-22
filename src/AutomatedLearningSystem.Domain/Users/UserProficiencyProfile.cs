using AutomatedLearningSystem.Domain.Common;

namespace AutomatedLearningSystem.Domain.Users;
public class UserProficiencyProfile
{
    public Common.UserLevel BackEndLevel { get; set; }
    public Common.UserLevel FrontEndLevel { get; set; }
    public Common.UserLevel DatabaseLevel { get; set; }

}
