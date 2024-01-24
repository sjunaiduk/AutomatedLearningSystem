using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.Users;
using AutomatedLearningSystem.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AutomatedLearningSystem.Infrastructure.Common;

public class EmailService : IEmailService
{
    private readonly AutomatedLearningSystemDbContext _dbContext;

    public EmailService(AutomatedLearningSystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> IsEmailUniqueAsync(string email, CancellationToken token)
    {
        var user = await _dbContext.Set<User>()
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync(token);

        return user is null;

    }
}