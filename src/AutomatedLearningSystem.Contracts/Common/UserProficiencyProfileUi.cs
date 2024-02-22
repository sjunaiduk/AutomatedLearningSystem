using System.Text.Json.Serialization;

namespace AutomatedLearningSystem.Contracts.Common;

public class UserProficiencyProfileUi
{
    public UserLevel Frontend { get; init; }
    public UserLevel Backend { get; init; }
    public UserLevel Database { get; init; }

}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserLevel
{
    Beginner = 0,
    Intermediate = 1,
    Advanced = 2,
}