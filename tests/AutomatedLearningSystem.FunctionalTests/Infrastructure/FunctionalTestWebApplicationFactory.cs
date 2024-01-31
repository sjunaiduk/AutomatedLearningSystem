using AutomatedLearningSystem.Infrastructure.Common.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AutomatedLearningSystem.FunctionalTests.Infrastructure;

public class FunctionalTestWebApplicationFactory : WebApplicationFactory<Program>
{

    private readonly string _dbName = Guid.NewGuid().ToString();
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.RemoveAll<DbContextOptions<AutomatedLearningSystemDbContext>>();

            services.AddDbContext<AutomatedLearningSystemDbContext>(opt =>
            {
                opt.UseSqlite($"Data Source=test-{_dbName}.db");

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