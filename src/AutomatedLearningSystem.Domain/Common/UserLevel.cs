using System.Text.Json.Serialization;

namespace AutomatedLearningSystem.Domain.Common;


[JsonConverter(typeof(JsonStringEnumConverter))]

public enum UserLevel
{
    Beginner = 0,
    Intermediate = 1,
    Advanced = 2,
}