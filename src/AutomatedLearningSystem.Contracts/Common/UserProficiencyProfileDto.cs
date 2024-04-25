namespace AutomatedLearningSystem.Contracts.Common;

public class UserProficiencyProfileDto
{
    public UserLevelDto Frontend { get; init; }
    public UserLevelDto Backend { get; init; }
    public UserLevelDto Database { get; init; }

}