using System.Net;
using System.Net.Http.Json;
using AutomatedLearningSystem.Api.Endpoints;
using AutomatedLearningSystem.Contracts.Users;
using AutomatedLearningSystem.Contracts.Users.CreateUser;
using AutomatedLearningSystem.FunctionalTests.Infrastructure;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using TestCommon.Constants;

namespace AutomatedLearningSystem.FunctionalTests.Users;

public class CreateUserTests : BaseFunctionalTest
{
    public CreateUserTests(FunctionalTestWebApplicationFactory factory) : base(factory)
    {
    }


    [Fact]
    public async void Create_WhenValidUser_ShouldCreateUser()
    {
        // Arrange

        var createUserRequest = new CreateUserRequest(
            "First Name",
            "Last Name",
            "test@gmail.com",
            "password",
            UserRole.Student);

        // Act

        var result = await HttpClient.PostAsJsonAsync(Routes.UserRoutes.Create,
            createUserRequest);

        // Assert

        result.StatusCode.Should().Be(HttpStatusCode.Created);

    }
}