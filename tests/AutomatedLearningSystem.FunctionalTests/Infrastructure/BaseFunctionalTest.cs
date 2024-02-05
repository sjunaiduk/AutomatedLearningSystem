using AutomatedLearningSystem.Infrastructure.Common.Persistence;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace AutomatedLearningSystem.FunctionalTests.Infrastructure;

public class BaseFunctionalTest : IClassFixture<FunctionalTestWebApplicationFactory>
{

    protected readonly HttpClient HttpClient;
    protected readonly AutomatedLearningSystemDbContext DbContext;
    protected BaseFunctionalTest(FunctionalTestWebApplicationFactory factory)
    {
        HttpClient = factory.CreateClient(new WebApplicationFactoryClientOptions()
        {
            AllowAutoRedirect = false
            
        });
        var scope = factory.Services.CreateScope();
        DbContext = scope.ServiceProvider.GetRequiredService<AutomatedLearningSystemDbContext>();

    }
}