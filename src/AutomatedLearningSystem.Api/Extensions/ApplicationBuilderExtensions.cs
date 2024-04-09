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
                        faker.PickRandomParam(Domain.Users.Role.Admin, Domain.Users.Role.Student),
                        faker.Random.AlphaNumeric(10));
                })
                .ToList();

            dbContext.Set<User>()
                .AddRange(users);

            dbContext.Set<User>()
                .Add(User.Create("john", "doe",
                "doe@gmail.com",
                Domain.Users.Role.Admin,
                "password"));
            dbContext.Set<User>()
           .Add(User.Create("john", "doe",
           "john@gmail.com",
           Domain.Users.Role.Student,
           "password"));
        }

        var anyQuestions = dbContext.Set<Question>()
            .Any();

        if (!anyQuestions)
        {
            string[] possibleQuestions = [
    "Rate your interest in backend development.",
    "Rate your interest in frontend development.",
    "Rate your proficiency with database management and operations.",
    "Rate your comfort level with cloud services and operations.",
    "Rate your enthusiasm for learning new backend technologies.",
    "Rate your enthusiasm for adopting new frontend frameworks and libraries.",
    "Rate your comfort level with designing and implementing API services.",
    "Rate your proficiency in handling server-side scripting and programming.",
    "Rate your interest in serverless architecture in cloud environments.",
    "Rate your experience with deploying applications on cloud platforms.",
            ];

            var questions = Enumerable.Range(0, 9)
                .Select(x =>
                {
                    var faker = new Faker();
                    return Question.Create(possibleQuestions[x],
                        x switch
                        {
                            <= 2 => Category.Database,
                            <= 5 => Category.Frontend,
                            <= 9 => Category.Backend,
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
                        faker.PickRandom<UserLevel>());
                }).ToList();

            dbContext.Set<LearningItem>()
                .AddRange(learningItems);
        }





        dbContext.SaveChanges();

    }
}