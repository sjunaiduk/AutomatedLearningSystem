namespace AutomatedLearningSystem.Application.Common.Abstractions;

public interface IEmailService
{
    Task<bool> IsEmailUniqueAsync(string email, CancellationToken token = default);
}