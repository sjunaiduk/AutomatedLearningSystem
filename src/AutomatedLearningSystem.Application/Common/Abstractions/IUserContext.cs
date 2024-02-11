namespace AutomatedLearningSystem.Application.Common.Abstractions;

public interface IUserContext
{
    Guid Id { get; set; }

    string Role { get; set; }

    bool IsAdmin { get; }
}