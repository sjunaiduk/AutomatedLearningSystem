namespace AutomatedLearningSystem.Domain.Common;

public interface IEmailService
{
    Task<bool> IsEmailUniqueAsync(string email);
}