using System.ComponentModel.Design.Serialization;
using System.Text.Json.Serialization;

namespace AutomatedLearningSystem.Domain.Users;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Role
{
    Admin = 0,
    Student = 1,
}