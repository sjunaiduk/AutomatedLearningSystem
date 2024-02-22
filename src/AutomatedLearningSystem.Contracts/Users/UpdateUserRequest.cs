﻿namespace AutomatedLearningSystem.Contracts.Users;

public class UpdateUserRequest
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public RoleDto? Role { get; set; }
}