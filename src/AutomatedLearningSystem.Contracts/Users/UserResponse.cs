namespace AutomatedLearningSystem.Contracts.Users;

public class UserResponse
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public RoleDto RoleDto { get; init; }


}