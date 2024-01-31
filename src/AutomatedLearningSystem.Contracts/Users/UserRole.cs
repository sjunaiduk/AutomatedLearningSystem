using System.Text.Json.Serialization;

namespace AutomatedLearningSystem.Contracts.Users;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserRole
{
    Admin = 0,
    Student = 1
}

