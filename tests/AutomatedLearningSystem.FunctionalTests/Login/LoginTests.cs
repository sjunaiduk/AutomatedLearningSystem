using System.Net.Http.Json;
using System.Security.Claims;
using AutomatedLearningSystem.Api.Endpoints;
using AutomatedLearningSystem.Contracts.Login;
using AutomatedLearningSystem.Domain.Users;
using AutomatedLearningSystem.FunctionalTests.Infrastructure;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace AutomatedLearningSystem.FunctionalTests.Login;

public class LoginTests(FunctionalTestWebApplicationFactory factory) : BaseFunctionalTest(factory)
{
    [Fact]

    public async void LoginEndpoint_WhenValidCredentials_ShouldReturnSetCookieHeaderInResponse()
    {
        // Arrange
        var user = await DbContext.Set<User>().FirstAsync();
        var loginRequest = new LoginRequest()
        {
            Email = user.Email,
            Password = user.Password
        };

        // Act
        var response = await HttpClient.PostAsJsonAsync(Routes.Login, loginRequest);

        // Assert
        response.Headers.Any(header => header.Key == "Set-Cookie").Should().BeTrue();
    }


}