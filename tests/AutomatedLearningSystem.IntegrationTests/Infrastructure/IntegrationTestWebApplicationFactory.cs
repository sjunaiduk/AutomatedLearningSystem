﻿using System.Security.Claims;
using System.Text.Encodings.Web;
using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Infrastructure.Common.Persistence;
using AutomatedLearningSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AutomatedLearningSystem.IntegrationTests.Infrastructure;

public class IntegrationTestWebApplicationFactory : WebApplicationFactory<Program>
{
    private readonly string _dbName = Guid.NewGuid().ToString();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>

        {
            services.RemoveAll<DbContextOptions<AutomatedLearningSystemDbContext>>();

            services.AddDbContext<AutomatedLearningSystemDbContext>(opt =>
            {
                opt.UseSqlite($"Data Source={_dbName}.db");
                opt.EnableSensitiveDataLogging();
            });

            services.AddSingleton<IAuthenticationSchemeProvider, MockSchemeProvider>();

            services.AddScoped<IUserContext>(_ =>
                new UserContext(new HttpContextAccessor())
                {
                        Id = Guid.NewGuid(),
                    Role = "admin"

                });
        });
    }

    public WebApplicationFactory<Program> WithMockedClaims(string role, Guid userId)
    {
        return WithWebHostBuilder(c =>
        {
            c.ConfigureTestServices(services =>
            {
                services.AddScoped<IUserContext>(_ => new MockUserContext {Id = userId, Role = role});
            });
        });
    }

    public class MockUserContext : IUserContext
    {
        public Guid Id { get; set; }
        public string Role { get; set; }
        public bool IsAdmin => Role == "admin";
    }
  


    protected override void Dispose(bool disposing)
    {
        var scope = Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AutomatedLearningSystemDbContext>();
        dbContext.Database.EnsureDeleted();
    }
}


public class MockSchemeProvider : AuthenticationSchemeProvider
{
    public MockSchemeProvider(IOptions<AuthenticationOptions> options) : base(options)
    {
    }

    protected MockSchemeProvider(IOptions<AuthenticationOptions> options, IDictionary<string, AuthenticationScheme> schemes) : base(options, schemes)
    {
    }

    public override Task<AuthenticationScheme?> GetSchemeAsync(string name)
    {
        var scheme = new AuthenticationScheme("cookie",
            "cookie",
            typeof(TestAuthHandler));

        return Task.FromResult(scheme)!;
    }
}

public class TestAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{

    public TestAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder) : base(options,
        logger,
        encoder)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var claims = new List<Claim> { new(ClaimTypes.Role, "student") };
        var identity = new ClaimsIdentity(claims, "cookie");
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, "cookie");

        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}