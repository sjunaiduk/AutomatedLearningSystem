namespace AutomatedLearningSystem.Contracts.Users;

public class UserResponse
{
    public Guid Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public string Password { get; init; } = null!;
    public RoleDto Role { get; init; }


}