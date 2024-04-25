using System.Text.Json.Serialization;

namespace AutomatedLearningSystem.Contracts.Common;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserLevelDto
{
    Beginner = 0,
    Intermediate = 1,
    Advanced = 2,
}