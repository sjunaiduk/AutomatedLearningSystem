using System.Text.Json.Serialization;

namespace AutomatedLearningSystem.Domain.Common;


[JsonConverter(typeof(JsonStringEnumConverter))]

public enum Priority
{
    Low = 0, Medium = 1,
    High = 2
}