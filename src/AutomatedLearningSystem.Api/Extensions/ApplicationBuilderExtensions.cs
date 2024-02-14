using System.Runtime.InteropServices;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.LearningItems;
using AutomatedLearningSystem.Domain.Questions;
using AutomatedLearningSystem.Domain.Users;
using AutomatedLearningSystem.Infrastructure.Common.Persistence;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace AutomatedLearningSystem.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static async Task ApplyMigrations(this IApplicationBuilder app)
    {

        var scope = app.ApplicationServices.CreateScope();
        var dbContext = scope.ServiceProvider
            .GetRequiredService<AutomatedLearningSystemDbContext>();
        await dbContext.Database.MigrateAsync();



    }

    public static void SeedData(this IApplicationBuilder app)
    {
        var scope = app.ApplicationServices.CreateScope();
        var dbContext = scope.ServiceProvider
            .GetRequiredService<AutomatedLearningSystemDbContext>();

        var anyUsers = dbContext.Set<User>()
            .Any();

        if (!anyUsers)
        {
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

            dbContext.Set<User>()
                .Add(User.Create("john","doe",
                "doe@gmail.com",
                Role.Admin,
                "password"));
        }

        var anyQuestions = dbContext.Set<Question>()
            .Any();

        if (!anyQuestions)
        {
            var questions = Enumerable.Range(0, 6)
                .Select(x =>
                {
                    var faker = new Faker();
                    return Question.Create(faker.Lorem.Sentence(),
                        x switch
                        {
                            <=2 => Category.Database,
                            <= 4 => Category.Frontend,
                            <= 6 => Category.Backend,
                            _ => throw new InvalidOperationException()
                        });
                })
                .ToList();

            dbContext.Set<Question>()
                .AddRange(questions);
        }

        var anyLearningItems = dbContext.Set<LearningItem>()
            .Any();

        if (!anyLearningItems)
        {
            var learningItems = Enumerable.Range(0, 20)
                .Select(x =>
                {
                    var faker = new Faker();
                    return LearningItem.Create(faker.Lorem.Word(),
                        faker.Lorem.Sentence(),
                        faker.PickRandom<Category>(),
                        faker.PickRandom<Priority>(),
                        faker.PickRandom<DifficultyLevel>());
                }).ToList();

            dbContext.Set<LearningItem>()
                .AddRange(learningItems);
        }





        dbContext.SaveChanges();

    }
}