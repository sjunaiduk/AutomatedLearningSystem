namespace AutomatedLearningSystem.Contracts.Users;

public class UserProficiencyProfile
{
    public UserLevel Frontend { get; init; }
    public UserLevel Backend { get; init; }
    public UserLevel Database { get; init; }


}

public enum UserLevel
{
    Beginner = 0,
    Intermediate = 1,
    Advanced = 2,
}