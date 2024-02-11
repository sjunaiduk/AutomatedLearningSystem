using System.Net.Security;
using System.Security.Claims;
using System.Text.Encodings.Web;
using AutomatedLearningSystem.Infrastructure.Common.Persistence;
using AutomatedLearningSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using static AutomatedLearningSystem.Infrastructure.Identity.AuthConstants;

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

            {
                //services.AddSingleton<IAuthenticationSchemeProvider, MockSchemeProvider>();

                //services.AddSingleton(_ => new MockedClaims()
                //{
                //    Claims = []
                //});
            }
        });
    }

    public WebApplicationFactory<Program> WithMockedClaims(List<Claim> claims)
    {

        return WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddSingleton(_ => new MockedClaims()
                    {
                        Claims = claims
                    });
                });
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
        return Task.FromResult(new AuthenticationScheme(AuthConstants.DefaultCookieScheme,
      AuthConstants.DefaultCookieScheme,
            typeof(MockAuthHandler)))!;
    }
}

public class MockedClaims
{
    public List<Claim> Claims { get; init; } = new();
}
public class MockAuthHandler : CookieAuthenticationHandler
{
    private readonly MockedClaims _mockedClaims;

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {

        var identity = new ClaimsIdentity(_mockedClaims.Claims, AuthConstants.DefaultCookieScheme);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, AuthConstants.DefaultCookieScheme);
        return Task.FromResult(AuthenticateResult.Success(ticket));
    }

    public MockAuthHandler(IOptionsMonitor<CookieAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, MockedClaims mockedClaims) : base(options, logger, encoder, clock)
    {
        _mockedClaims = mockedClaims;
    }

    public MockAuthHandler(IOptionsMonitor<CookieAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, MockedClaims mockedClaims) : base(options, logger, encoder)
    {
        _mockedClaims = mockedClaims;
    }
}