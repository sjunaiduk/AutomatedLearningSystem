using AutomatedLearningSystem.Domain.Users;
using AutomatedLearningSystem.Infrastructure.Common.Persistence;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace AutomatedLearningSystem.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        var scope = app.ApplicationServices.CreateScope();
        var dbContext = scope.ServiceProvider
            .GetRequiredService<AutomatedLearningSystemDbContext>();

        dbContext.Database.Migrate();
    }

    public static void SeedData(this IApplicationBuilder app)
    {
        var scope = app.ApplicationServices.CreateScope();
        var dbContext = scope.ServiceProvider
            .GetRequiredService<AutomatedLearningSystemDbContext>();

        var userCount = dbContext.Set<User>()
            .Count();

        if (userCount > 0)
        {
            return;
        }

        var users = Enumerable.Range(0, 10)
            .Select(x =>
            {
                var faker = new Faker();
                return User.Create(faker.Person.FirstName,
                    faker.Person.LastName, // Changed from FirstName to LastName for more realistic data
                    faker.Person.Email,
                    Role.Admin,
                    faker.Random.AlphaNumeric(10));
            })
            .ToList();

        dbContext.Set<User>()
            .AddRange(users);

        dbContext.SaveChanges();

    }
}