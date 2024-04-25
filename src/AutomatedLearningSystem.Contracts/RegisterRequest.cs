using AutomatedLearningSystem.Contracts.Users;

namespace AutomatedLearningSystem.Contracts;

public record RegisterRequest(string FirstName,
    string LastName,
    string Email,
    string Password,
    string? Token);