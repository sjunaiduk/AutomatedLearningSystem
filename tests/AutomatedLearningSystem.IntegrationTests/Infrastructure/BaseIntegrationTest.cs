using AutomatedLearningSystem.Infrastructure.Common.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AutomatedLearningSystem.IntegrationTests.Infrastructure;

public class BaseIntegrationTest : IClassFixture<IntegrationTestWebApplicationFactory>
{
    protected readonly ISender Sender;
    protected readonly AutomatedLearningSystemDbContext DbContext;
    public BaseIntegrationTest(IntegrationTestWebApplicationFactory factory)
    {
        var scope = factory.Services.CreateScope();
        Sender = scope.ServiceProvider.GetRequiredService<ISender>();
        DbContext = scope.ServiceProvider.GetRequiredService<AutomatedLearningSystemDbContext>();

    }

}