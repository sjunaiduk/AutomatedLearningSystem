using AutomatedLearningSystem.Infrastructure.Common.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace AutomatedLearningSystem.IntegrationTests.Infrastructure;

public class BaseIntegrationTest : IClassFixture<IntegrationTestWebApplicationFactory>
{
    private readonly WebApplicationFactory<Program> _factory;

    protected readonly ISender Sender;
    protected readonly AutomatedLearningSystemDbContext DbContext;
    public BaseIntegrationTest(IntegrationTestWebApplicationFactory factory, string? role = null, Guid? userId = null)
    {
         _factory = factory;

        if (role is not null)
        {
            _factory = factory.WithMockedClaims(role, userId ?? Guid.NewGuid());
        }
        var scope = _factory.Services.CreateScope();
        Sender = scope.ServiceProvider.GetRequiredService<ISender>();
        DbContext = scope.ServiceProvider.GetRequiredService<AutomatedLearningSystemDbContext>();
    }

}