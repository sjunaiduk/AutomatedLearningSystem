using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.LearningItems;
using AutomatedLearningSystem.Domain.Questions;
using AutomatedLearningSystem.Domain.Users;
using AutomatedLearningSystem.Infrastructure.Common.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AutomatedLearningSystem.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static async Task ApplyMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AutomatedLearningSystemDbContext>();
        await dbContext.Database.MigrateAsync();
    }

    public static void SeedData(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AutomatedLearningSystemDbContext>();

        SeedUsers(dbContext);
        SeedQuestions(dbContext);
        SeedLearningItems(dbContext);

        dbContext.SaveChanges();
    }

    private static void SeedUsers(AutomatedLearningSystemDbContext dbContext)
    {
        if (!dbContext.Set<User>().Any())
        {
            var users = new List<User>
            {
                User.Create("john", "doe", "doe@gmail.com", Domain.Users.Role.Admin, "password"),
                User.Create("john", "doe", "john@gmail.com", Domain.Users.Role.Student, "password")
            };
            dbContext.Set<User>().AddRange(users);
        }
    }

    private static void SeedQuestions(AutomatedLearningSystemDbContext dbContext)
    {
        if (!dbContext.Set<Question>().Any())
        {
            var questions = new List<Question>
            {
                Question.Create("I plan to significantly improve my error handling in backend development this year.", Category.Backend),
                Question.Create("I am committed to learning new frontend frameworks within the next six months.", Category.Frontend),
                Question.Create("I will take active steps to enhance my database optimization skills this year.", Category.Database),
                Question.Create("Mastering cloud infrastructure management is one of my top priorities for professional development.", Category.Backend),
                Question.Create("I intend to learn backend scaling techniques thoroughly over the next year.", Category.Backend),
                Question.Create("Integrating modern frontend tools into my projects is crucial for my development as a programmer.", Category.Frontend),
                Question.Create("Developing RESTful APIs effectively is a target I have set for myself this quarter.", Category.Backend),
                Question.Create("Advancing my script debugging skills is a major goal for me by the end of the year.", Category.Backend),
                Question.Create("Adopting serverless architectures in my upcoming projects is something I strongly aspire to.", Category.Backend),
                Question.Create("Setting clear milestones for deploying applications on cloud platforms is important for my career progression.", Category.Backend),
            };
            dbContext.Set<Question>().AddRange(questions);
        }
    }


    private static void SeedLearningItems(AutomatedLearningSystemDbContext dbContext)
    {
        if (!dbContext.Set<LearningItem>().Any())
        {
            var learningItems = new List<LearningItem>
        {
            LearningItem.Create("Intro to SQL", "Understand the fundamentals of SQL queries and data manipulation.", Category.Database, Priority.High, UserLevel.Beginner),
            LearningItem.Create("Advanced React Techniques", "Explore advanced concepts in React, including hooks and state management.", Category.Frontend, Priority.Medium, UserLevel.Advanced),
            LearningItem.Create("Node.js Performance Optimization", "Learn to optimize Node.js applications for better performance.", Category.Backend, Priority.High, UserLevel.Intermediate),
            LearningItem.Create("Cloud Services for Beginners", "An introduction to using AWS, Azure, and Google Cloud for beginners.", Category.Backend, Priority.Low, UserLevel.Beginner),
            LearningItem.Create("Responsive Web Design", "Learn how to create websites that work on any device.", Category.Frontend, Priority.Medium, UserLevel.Intermediate),
            LearningItem.Create("API Design Principles", "Master the art of designing scalable and maintainable APIs.", Category.Backend, Priority.High, UserLevel.Intermediate),
            LearningItem.Create("Microservices Architecture", "Understand the fundamentals and advantages of using microservices.", Category.Backend, Priority.Medium, UserLevel.Advanced),
            LearningItem.Create("Data Structures in Java", "Explore key data structures and their applications in Java.", Category.Backend, Priority.High, UserLevel.Intermediate),
            LearningItem.Create("Understanding Asynchronous JavaScript", "Learn about asynchronous programming in JavaScript using callbacks, promises, and async/await.", Category.Frontend, Priority.High, UserLevel.Intermediate),
            LearningItem.Create("Introduction to TypeScript", "Get started with TypeScript and learn how to improve JavaScript code reliability.", Category.Frontend, Priority.Medium, UserLevel.Beginner),
            LearningItem.Create("Advanced CSS Techniques", "Dive deeper into CSS to create sophisticated web designs and animations.", Category.Frontend, Priority.Low, UserLevel.Advanced),
            LearningItem.Create("Security Best Practices for Web Applications", "Learn about securing web applications from common vulnerabilities.", Category.Backend, Priority.High, UserLevel.Advanced),
            LearningItem.Create("Containerization with Docker", "Learn how to use Docker for deploying applications in containers.", Category.Backend, Priority.Medium, UserLevel.Intermediate),
            LearningItem.Create("Serverless Frameworks and Applications", "Explore how to build and deploy serverless applications using various frameworks.", Category.Backend, Priority.Medium, UserLevel.Advanced),
            LearningItem.Create("NoSQL Databases", "Understand when and how to use NoSQL databases effectively.", Category.Database, Priority.Medium, UserLevel.Intermediate),
            LearningItem.Create("GraphQL for API Development", "Learn how GraphQL can improve API development over REST APIs.", Category.Backend, Priority.Medium, UserLevel.Advanced),
            LearningItem.Create("Automated Testing for Continuous Integration", "Implement automated testing to improve software quality and deployment cycles.", Category.Backend, Priority.High, UserLevel.Intermediate),
            LearningItem.Create("Scalable Architecture for Growth", "Learn strategies to scale applications efficiently as your user base grows.", Category.Backend, Priority.High, UserLevel.Advanced),
            LearningItem.Create("Progressive Web Apps", "Build progressive web apps that deliver a native app-like experience.", Category.Frontend, Priority.Medium, UserLevel.Intermediate),
            LearningItem.Create("Machine Learning Basics for Developers", "Get an introduction to machine learning concepts applicable in software development.", Category.Backend, Priority.Low, UserLevel.Beginner)
        };
            dbContext.Set<LearningItem>().AddRange(learningItems);
        }
    }

}
