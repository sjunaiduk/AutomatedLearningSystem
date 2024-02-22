using System.Text.Json.Serialization;

namespace AutomatedLearningSystem.Contracts.Common;

public class UserProficiencyProfileDto
{
    public UserLevelDto Frontend { get; init; }
    public UserLevelDto Backend { get; init; }
    public UserLevelDto Database { get; init; }

}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserLevelDto
{
    Beginner = 0,
    Intermediate = 1,
    Advanced = 2,
}