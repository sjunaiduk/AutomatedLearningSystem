using System.Text.Json.Serialization;

namespace AutomatedLearningSystem.Contracts.Common;


[JsonConverter(typeof(JsonStringEnumConverter))]

public enum PriorityDto
{
    Low = 0, 
    Medium = 1,
    High = 2
}