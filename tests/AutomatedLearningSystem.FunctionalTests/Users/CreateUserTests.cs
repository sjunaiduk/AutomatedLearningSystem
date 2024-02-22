using AutomatedLearningSystem.Api.Endpoints;
using AutomatedLearningSystem.Contracts.Users;
using AutomatedLearningSystem.FunctionalTests.Infrastructure;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;

namespace AutomatedLearningSystem.FunctionalTests.Users;

public class CreateUserTests(FunctionalTestWebApplicationFactory factory) : BaseFunctionalTest(factory)
{
    [Fact]
    public async void Create_WhenValidUser_ShouldCreateUser()
    {
        // Arrange

        var createUserRequest = new CreateUserRequest(
            "First Name",
            "Last Name",
            "test@gmail.com",
            "password",
            RoleDto.Student);

        // Act
        
        var result = await HttpClient.PostAsJsonAsync(Routes.User.Create,
            createUserRequest);

        // Assert


        result.StatusCode.Should().Be(HttpStatusCode.Created);

    }
}