using AutomatedLearningSystem.Contracts.Users;

namespace AutomatedLearningSystem.Contracts.Login;

public class LoginResponse
{
    public Guid Id { get; set; }
    public UserRole Role { get; set; }

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

}