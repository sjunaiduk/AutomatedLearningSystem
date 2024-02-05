using System.Security.Claims;
using System.Text.Encodings.Web;
using AutomatedLearningSystem.Infrastructure.Common.Persistence;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AutomatedLearningSystem.FunctionalTests.Infrastructure;

public class FunctionalTestWebApplicationFactory : WebApplicationFactory<Program>
{

    private readonly string _dbName = Guid.NewGuid().ToString();
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll<DbContextOptions<AutomatedLearningSystemDbContext>>();

            services.AddDbContext<AutomatedLearningSystemDbContext>(opt =>
            {
                opt.UseSqlite($"Data Source=test-{_dbName}.db");

            });

            services.AddSingleton<IAuthenticationSchemeProvider, MockSchemeProvider>();

        });
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
        return Task.FromResult(new AuthenticationScheme("cookie",
            "cookie",
            typeof(MockAuthHandler)))!;
    }
}

public class MockAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public MockAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
    {
    }

    public MockAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder) : base(options, logger, encoder)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var claim = new Claim(ClaimTypes.Role, "admin");
        var claims = new List<Claim> { claim };

        var identity = new ClaimsIdentity(claims, "cookie");
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, "cookie");
        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}