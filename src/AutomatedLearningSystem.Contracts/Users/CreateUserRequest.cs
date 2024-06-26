﻿namespace AutomatedLearningSystem.Contracts.Users;

public record CreateUserRequest(string FirstName,
    string LastName,
    string Email,
    string Password,
    RoleDto Role,
    string? Token);