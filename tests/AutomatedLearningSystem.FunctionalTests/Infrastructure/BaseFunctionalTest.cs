using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using AutomatedLearningSystem.Api.Endpoints;
using AutomatedLearningSystem.Contracts.Login;
using AutomatedLearningSystem.Domain.Users;
using AutomatedLearningSystem.Infrastructure.Common.Persistence;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AutomatedLearningSystem.FunctionalTests.Infrastructure;

public class BaseFunctionalTest : IClassFixture<FunctionalTestWebApplicationFactory>
{

    protected HttpClient HttpClient { get; }
    protected AutomatedLearningSystemDbContext DbContext { get; }

    protected User? AdminUser { get; private set; }

    protected BaseFunctionalTest(FunctionalTestWebApplicationFactory factory)
    {
        HttpClient =
            factory.CreateClient(new WebApplicationFactoryClientOptions()
            {
                AllowAutoRedirect = false,

            });
        var scope = factory.Services.CreateScope();

        DbContext = scope.ServiceProvider.GetRequiredService<AutomatedLearningSystemDbContext>();

    }

    protected async Task SetAdminCookie()
    {
        var admin = await DbContext.Set<User>().FirstAsync(u => u.Role == Role.Admin);
        AdminUser = admin;
        var loginRequest = new LoginRequest()
        {
            Email = admin.Email,
            Password = admin.Password
        };
        var login = await HttpClient.PostAsJsonAsync(Routes.Login, loginRequest);

        if (login.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidOperationException(
                $"Request to login endpoint failed in call to {nameof(SetAdminCookie)}");
        }

    }




}