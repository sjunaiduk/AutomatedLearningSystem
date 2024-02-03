using System.Text.Json.Serialization;

namespace AutomatedLearningSystem.Domain.Common;


[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Category
{
    Backend = 0,
    Frontend = 1,
    Database = 2,
}