using System.Net.Http.Json;
using AutomatedLearningSystem.Api.Endpoints;
using AutomatedLearningSystem.Contracts.Login;
using AutomatedLearningSystem.Domain.Users;
using AutomatedLearningSystem.FunctionalTests.Infrastructure;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace AutomatedLearningSystem.FunctionalTests.Auth;

public class LogoutTests(FunctionalTestWebApplicationFactory factory) : BaseFunctionalTest(factory) {

    [Fact]
       public async void LoginOutEndpoint_WhenLoggedOut_ShouldNotAuthenticateUserOnSubsequentRequests() {
        // Arrange
        var user = await DbContext.Set<User>().FirstAsync();
        var loginRequest = new LoginRequest()
        {
            Email = user.Email,
            Password = user.Password
        };
        await HttpClient.PostAsJsonAsync(Routes.Login, loginRequest);

        // Act
        await HttpClient.GetAsync(Routes.Logout);
        var response = await HttpClient.GetAsync(Routes.User.GetAll);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);


    }

}