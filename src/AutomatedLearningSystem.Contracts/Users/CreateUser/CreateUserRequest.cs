namespace AutomatedLearningSystem.Contracts.Users.CreateUser;

public record CreateUserRequest(string FirstName,
    string LastName,
    string Email,
    string Password,
    UserRole Role);