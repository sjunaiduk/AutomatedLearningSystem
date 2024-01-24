using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Infrastructure.Common;
using AutomatedLearningSystem.Infrastructure.Common.Persistence;
using AutomatedLearningSystem.Infrastructure.Users.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AutomatedLearningSystem.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<AutomatedLearningSystemDbContext>(options =>
        {
            options.UseSqlite("Data source = als.db");
        });

        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

}
