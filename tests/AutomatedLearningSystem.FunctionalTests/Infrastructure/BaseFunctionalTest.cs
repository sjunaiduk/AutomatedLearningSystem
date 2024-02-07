using System.Security.Claims;
using AutomatedLearningSystem.Infrastructure.Common.Persistence;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace AutomatedLearningSystem.FunctionalTests.Infrastructure;

public class BaseFunctionalTest : IClassFixture<FunctionalTestWebApplicationFactory>
{

    private readonly WebApplicationFactory<Program> _factory;
    protected HttpClient HttpClient { get; private set; }
    protected AutomatedLearningSystemDbContext DbContext { get; private set; }

    protected BaseFunctionalTest(FunctionalTestWebApplicationFactory factory,  List<Claim>? claims = null)
    {
        _factory = factory;

        if (claims is not null)
        {
           _factory = factory.WithMockedClaims(claims);
        }


        
        HttpClient =
            _factory.CreateClient(new WebApplicationFactoryClientOptions()
            {
                AllowAutoRedirect = false

            });
        var scope = factory.Services.CreateScope();

        DbContext = scope.ServiceProvider.GetRequiredService<AutomatedLearningSystemDbContext>();

    }



}